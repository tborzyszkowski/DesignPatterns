# Zadania — Wzorzec Odwiedzający (Visitor)

## Zadanie 1 — Figury geometryczne (poziom podstawowy)

### Treść

Dana jest hierarchia figur geometrycznych: `Koło`, `Prostokąt`, `Trójkąt`. Każda figura implementuje interfejs `IFigura` z metodą `Accept(IFiguraVisitor)`.

Zaimplementuj dwa odwiedzające:
1. `ObwodVisitor` — oblicza sumę obwodów wszystkich figur na liście
2. `OpisVisitor` — tworzy tekstowy opis każdej figury (np. `"Koło: r=5.00, obwód=31.42"`)

### Wymagania

- Kod w C# (.NET 9)
- Testy xUnit dla obu odwiedzających
- Co najmniej 3 figury na liście testowej

### Wskazówka

```csharp
interface IFigura
{
    void Accept(IFiguraVisitor visitor);
}

interface IFiguraVisitor
{
    void Visit(Kolo kolo);
    void Visit(Prostokat prostokat);
    void Visit(Trojkat trojkat);
}
```

### Rozwiązanie

<details>
<summary>Kliknij, aby zobaczyć rozwiązanie</summary>

```csharp
record Kolo(double Promien) : IFigura
{
    public void Accept(IFiguraVisitor v) => v.Visit(this);
}

record Prostokat(double Szerokosc, double Wysokosc) : IFigura
{
    public void Accept(IFiguraVisitor v) => v.Visit(this);
}

record Trojkat(double A, double B, double C) : IFigura
{
    public void Accept(IFiguraVisitor v) => v.Visit(this);
}

class ObwodVisitor : IFiguraVisitor
{
    public double SumaObwodow { get; private set; }

    public void Visit(Kolo k)      => SumaObwodow += 2 * Math.PI * k.Promien;
    public void Visit(Prostokat p) => SumaObwodow += 2 * (p.Szerokosc + p.Wysokosc);
    public void Visit(Trojkat t)   => SumaObwodow += t.A + t.B + t.C;
}

class OpisVisitor : IFiguraVisitor
{
    public List<string> Opisy { get; } = [];

    public void Visit(Kolo k)
        => Opisy.Add($"Koło: r={k.Promien:F2}, obwód={2 * Math.PI * k.Promien:F2}");
    public void Visit(Prostokat p)
        => Opisy.Add($"Prostokąt: {p.Szerokosc:F2}x{p.Wysokosc:F2}, obwód={2*(p.Szerokosc+p.Wysokosc):F2}");
    public void Visit(Trojkat t)
        => Opisy.Add($"Trójkąt: boki {t.A:F2},{t.B:F2},{t.C:F2}, obwód={t.A+t.B+t.C:F2}");
}
```

</details>

---

## Zadanie 2 — Struktura plików (poziom średni)

### Treść

Zaprojektuj system reprezentacji struktury katalogów plików używając wzorca Odwiedzający:

- **Elementy**: `Plik(string Nazwa, long RozmiarKB)`, `Katalog(string Nazwa, List<IWezl> Dzieci)`
- **Odwiedzający**:
  1. `RozmiarVisitor` — oblicza całkowity rozmiar katalogu rekurencyjnie
  2. `DrukowanieVisitor` — wyświetla drzewo katalogu z wcięciami (jak `tree` w terminalu)
  3. `WyszukanieVisitor(string rozszerzenie)` — zbiera listę plików o podanym rozszerzeniu

### Wymagania

- Hierarchia powinna być rekurencyjna (katalog może zawierać inne katalogi)
- Testy xUnit dla wszystkich trzech odwiedzających

### Wskazówka do wyświetlania z wcięciami

```csharp
class DrukowanieVisitor : IWezlVisitor
{
    private int _poziom = 0;

    public void Visit(Katalog k)
    {
        Console.WriteLine($"{new string(' ', _poziom * 2)}[{k.Nazwa}]");
        _poziom++;
        foreach (var dziecko in k.Dzieci)
            dziecko.Accept(this);
        _poziom--;
    }
}
```

### Rozwiązanie

<details>
<summary>Kliknij, aby zobaczyć rozwiązanie</summary>

```csharp
interface IWezl
{
    void Accept(IWezlVisitor visitor);
}

record Plik(string Nazwa, long RozmiarKB) : IWezl
{
    public void Accept(IWezlVisitor v) => v.Visit(this);
}

class Katalog(string Nazwa) : IWezl
{
    public string Nazwa { get; } = Nazwa;
    public List<IWezl> Dzieci { get; } = [];

    public void Accept(IWezlVisitor v) => v.Visit(this);
}

interface IWezlVisitor
{
    void Visit(Plik plik);
    void Visit(Katalog katalog);
}

class RozmiarVisitor : IWezlVisitor
{
    public long TotalKB { get; private set; }

    public void Visit(Plik p)    => TotalKB += p.RozmiarKB;
    public void Visit(Katalog k) => k.Dzieci.ForEach(d => d.Accept(this));
}

class DrukowanieVisitor : IWezlVisitor
{
    private int _poziom = 0;
    private readonly List<string> _linie = [];
    public IReadOnlyList<string> Linie => _linie;

    public void Visit(Plik p)
        => _linie.Add($"{new string(' ', _poziom * 2)}{p.Nazwa} ({p.RozmiarKB} KB)");

    public void Visit(Katalog k)
    {
        _linie.Add($"{new string(' ', _poziom * 2)}[{k.Nazwa}/]");
        _poziom++;
        foreach (var dziecko in k.Dzieci)
            dziecko.Accept(this);
        _poziom--;
    }
}

class WyszukanieVisitor(string rozszerzenie) : IWezlVisitor
{
    public List<string> ZnalezioneSciezki { get; } = [];

    public void Visit(Plik p)
    {
        if (p.Nazwa.EndsWith(rozszerzenie, StringComparison.OrdinalIgnoreCase))
            ZnalezioneSciezki.Add(p.Nazwa);
    }

    public void Visit(Katalog k) => k.Dzieci.ForEach(d => d.Accept(this));
}
```

</details>

---

## Zadanie 3 — Raportowanie pracowników (poziom zaawansowany)

### Treść

Rozszerz przykład z tematu 06. Masz strukturę:

```csharp
abstract record Pracownik(string Imie, decimal Pensja);
record Programista(string Imie, decimal Pensja, string Jezyk) : Pracownik(Imie, Pensja);
record Kierownik(string Imie, decimal Pensja, List<Pracownik> Zespol) : Pracownik(Imie, Pensja);
record Dyrektor(string Imie, decimal Pensja, string Dzial) : Pracownik(Imie, Pensja);
```

Zaimplementuj odwiedzających:

1. **`PodwyzkaVisitor(decimal procent)`** — zwiększa pensję każdego pracownika o zadany procent (mutuje lub tworzy nowe obiekty)
2. **`RaportPlacowyVisitor`** — generuje listę `(Imie, Rola, Pensja)` posortowaną malejąco po pensji
3. **`LiczbaPodwladnychVisitor`** — dla każdego `Kierownik` oblicza rekurencyjnie całkowitą liczbę podwładnych (łącznie z pośrednimi)

### Wymagania

- Co najmniej 12 testów xUnit
- Obsługa hierarchii dwupoziomowej (kierownik → programiści)
- `RaportPlacowyVisitor` używa LINQ do sortowania

### Kluczowe pytanie do przemyślenia

Czy `PodwyzkaVisitor` powinien **mutować** obiekty pracowników czy zwracać **nową** kolekcję? Jakie są konsekwencje obu podejść? Zapisz swoje wnioski jako komentarz w kodzie.

---

## Zadanie 4 — Porównaj wzorzec z pattern matching (poziom zaawansowany)

### Treść

Weź przykład z zadania 1 (figury geometryczne) i zaimplementuj te same operacje **bez wzorca Odwiedzający** — używając C# `switch` z pattern matching:

```csharp
static double ObliczObwod(IFigura figura) => figura switch
{
    Kolo k      => 2 * Math.PI * k.Promien,
    Prostokat p => 2 * (p.Szerokosc + p.Wysokosc),
    Trojkat t   => t.A + t.B + t.C,
    _           => throw new ArgumentException($"Nieznana figura: {figura}")
};
```

Następnie:

1. Porównaj oba podejścia pod kątem: ilości kodu, czytelności, rozszerzalności
2. Dodaj nową figurę `Elipsa(double A, double B)` do obu implementacji
3. Napisz w komentarzu: które podejście jest lepsze dla Twojego scenariusza i dlaczego

### Kryterium oceny

Studenci muszą samodzielnie uzasadnić wybór — nie ma jednej poprawnej odpowiedzi. Oceniamy rozumowanie, nie wynik.
