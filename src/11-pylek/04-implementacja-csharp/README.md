# 04. Implementacja C#

## Cel rozdziału

Pokazać praktyczną implementację FlyweightFactory w C# z naciskiem na poprawny klucz, niemutowalność i współbieżność.

## Kontekst przykładu

Program symuluje **parser tokenów kodu źródłowego**. Token to słowo kluczowe języka (`int`, `string`, `bool`) — takich tokenów w prawdziwym pliku źródłowym mogą być tysiące, ale unikalnych wartości jest kilkanaście. Bez Pył­ka każde wystąpienie `int` w kodzie tworzyłoby osobny obiekt z tymi samymi danymi. Z Pyłkiem wszystkie wystąpienia `int` wskazują na **jeden wspólny obiekt**.

## Podział stanu

| Stan | Nazwa | Gdzie trzymany | Co zawiera w przykładzie |
|---|---|---|---|
| Wewnętrzny (intrinsic) | wspólny, niemutowalny | w `TokenFlyweight` | `Text` (np. `"int"`), `Category` (np. `"keyword"`) |
| Zewnętrzny (extrinsic) | kontekstowy, zmienny | poza flyweightem, w kliencie | `line`, `column` — pozycja tokenu w pliku |

Stan wewnętrzny jest taki sam dla każdego `"int"` w całym programie. Stan zewnętrzny (numer linii, kolumna) jest inny dla każdego wystąpienia i jest przekazywany do metody `Render` przez wywołującego — flyweight **nigdy go nie przechowuje**.

## Szkielet architektury

```
IToken                    ← kontrakt; przyjmuje extrinsic state przez parametry metody
TokenFlyweight            ← przechowuje TYLKO intrinsic state (readonly pola)
TokenKey (record struct)  ← klucz cache; value equality przez kompilator
TokenFactory              ← ConcurrentDictionary<TokenKey, IToken> + metryki
```

### 1. Interfejs — `IToken`

```csharp
internal interface IToken
{
    void Render(int line, int column);   // line i column to extrinsic state
}
```

`Render` przyjmuje stan zewnętrzny jako parametry. Dzięki temu ten sam obiekt flyweighta może obsługiwać `"int"` w linii 1, 3, 7, 12 — bez żadnych pól instancji dla pozycji.

### 2. Concrete flyweight — `TokenFlyweight`

```csharp
internal sealed class TokenFlyweight(string text, string category) : IToken
{
    private readonly string _text     = text;      // intrinsic — nigdy się nie zmienia
    private readonly string _category = category;  // intrinsic — nigdy się nie zmienia

    public void Render(int line, int column)        // line, column — extrinsic, z zewnątrz
    {
        Console.WriteLine($"  [{_category}] '{_text}' @ line={line} col={column}");
    }
}
```

Pola są `readonly` — niemożliwe jest ich zmutowanie po konstruktorze. To gwarancja bezpieczeństwa współbieżnego: wiele wątków może jednocześnie wołać `Render` na tym samym obiekcie.

### 3. Klucz cache — `TokenKey`

```csharp
internal readonly record struct TokenKey(string Text, string Category);
```

`record struct` to kluczowy wybór:

- `readonly` — niemutowalny po utworzeniu.
- `record` — kompilator generuje `Equals` i `GetHashCode` oparte o wartości pól (a nie referencję).
- `struct` — klucz jest typem wartościowym, nie tworzy alokacji na stercie przy każdym lookupie.

Bez własnego `Equals`/`GetHashCode` dwa oddzielne `new TokenKey("int", "keyword")` byłyby traktowane jak różne klucze — flyweighty nigdy by się nie trafiły w cache.

### 4. Fabryka — `TokenFactory`

```csharp
internal sealed class TokenFactory
{
    private readonly ConcurrentDictionary<TokenKey, IToken> _cache = new();
    private int _hits;
    private int _misses;

    public IToken Get(string text, string category)
    {
        var key = new TokenKey(text, category);
        bool wasAdded = false;

        IToken fw = _cache.GetOrAdd(key, k =>
        {
            wasAdded = true;
            return new TokenFlyweight(k.Text, k.Category);
        });

        if (wasAdded) Interlocked.Increment(ref _misses);
        else          Interlocked.Increment(ref _hits);

        return fw;
    }
}
```

**`GetOrAdd`** — atomowa operacja słownika: jeśli klucz istnieje, zwraca istniejący obiekt bez tworzenia nowego; jeśli nie — wywołuje fabrykę i wstawia wynik. Dzięki temu `TokenFlyweight` jest tworzony **co najwyżej raz** dla każdej unikalnej kombinacji `(text, category)`, nawet przy współbieżnym dostępie z wielu wątków.

**`Interlocked.Increment`** — bezpieczna inkrementacja liczników `_hits`/`_misses` bez locka, atomowo.

**`wasAdded`** — lokalna flaga ustawiana wewnątrz lambdy fabryki. Jeśli lambda została wywołana, obiekt był nowy (miss). Jeśli nie — obiekt już istniał (hit).

## Przepływ dla wejścia `["int", "string", "int", "bool", "string", "int", "int", "bool"]`

```
Żądanie 1: "int"    → miss → tworzony TokenFlyweight("int","keyword")    cache: 1 obiekt
Żądanie 2: "string" → miss → tworzony TokenFlyweight("string","keyword")  cache: 2 obiekty
Żądanie 3: "int"    → HIT  → zwracany istniejący obiekt                   cache: 2 obiekty
Żądanie 4: "bool"   → miss → tworzony TokenFlyweight("bool","keyword")   cache: 3 obiekty
Żądanie 5: "string" → HIT  → zwracany istniejący obiekt
Żądanie 6: "int"    → HIT  → zwracany istniejący obiekt
Żądanie 7: "int"    → HIT  → zwracany istniejący obiekt
Żądanie 8: "bool"   → HIT  → zwracany istniejący obiekt

Wynik: 8 żądań → 3 unikalne obiekty, 5 trafień, 3 pudła, hit ratio = 63%
```

## Zalecenia implementacyjne

1. Trzymaj intrinsic jako `readonly` — brak możliwości mutacji = bezpieczeństwo współbieżne.
1. Używaj jawnego typu klucza (`record struct`) zamiast surowych stringów — czytelność i pewna równość wartościowa.
1. Zadbaj o deterministyczne `Equals` i `GetHashCode` klucza — bez tego cache nie działa.
1. Rejestruj metryki: liczba miss/hit oraz liczba unikalnych flyweightów — dowód realnych oszczędności.
1. Nie wstrzykuj do flyweighta żadnych zależności zależnych od żądania (np. `HttpContext`) — to jest stan zewnętrzny.

## Najczęstsze błędy C#

| Błąd | Skutek | Poprawka |
|---|---|---|
| Mutowalne pole w flyweighcie | Wyścig danych przy współbieżności | `private readonly` + brak setterów |
| Klucz jako `string` zamiast `record struct` | Błędne trafienia lub brak trafień | Dedykowany typ z value equality |
| Niespójna normalizacja klucza (raz `ToLower`, raz nie) | Te same dane tworzą dwa obiekty | Normalizacja w jednym miejscu — w konstruktorze klucza |
| Wstrzyknięcie serwisów scoped do flyweighta (singleton) | Captive dependency | Przekazuj przez parametry metody, nie przez konstruktor |

## Przykładowy program C#

Kod: [Examples/Program.cs](Examples/Program.cs)

```bash
cd src/11-pyłek/04-implementacja-csharp/Examples
dotnet run
```

## Co mierzyć w demie

| Metryka | Co oznacza |
|---|---|
| `UniqueFlyweights` | Ile obiektów faktycznie żyje w pamięci |
| `Hits` | Ile razy uniknięto tworzenia nowego obiektu |
| `Misses` | Ile razy obiekt musiał zostać stworzony |
| `HitRatio` | Skuteczność cache — im bliżej 100%, tym większa oszczędność |
