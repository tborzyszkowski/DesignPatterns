# 04. Przykłady zastosowania i typy implementacji

## Cel tematu

Pokazać różne style implementacji Dekoratora w C# i wskazać ich trade-offy.

## Diagram mapy wariantów

![Mapa wariantów](diagrams/decorator_variants.png)

Źródło: [diagrams/01-variants-map.puml](diagrams/01-variants-map.puml)

## Szczegółowe omówienie wariantów (pod mapą)

Poniżej każdy wariant został opisany osobno: jak działa, kiedy jest dobry oraz gdzie pojawiają się koszty i ograniczenia.

### 1) Wariant klasyczny (GoF)

W tym podejściu mamy wspólny kontrakt (`INotifier`), obiekt bazowy (`ConsoleNotifier`) i dekorator, który opakowuje obiekt wewnętrzny (`TimestampDecorator`).

Mini-diagram (przepływ wywołania):

```text
Client
	|
	v
TimestampDecorator.Notify(msg)
	|
	v
inner.Notify("[czas] " + msg)
	|
	v
ConsoleNotifier.Notify(...)
	|
	v
"NOTIFY:[czas] msg"
```

Uproszczony kod:

```csharp
public interface INotifier
{
		string Notify(string message);
}

public sealed class ConsoleNotifier : INotifier
{
		public string Notify(string message) => $"NOTIFY:{message}";
}

public sealed class TimestampDecorator(INotifier inner) : INotifier
{
		public string Notify(string message)
				=> inner.Notify($"[{DateTime.UtcNow:HH:mm:ss}] {message}");
}
```

Kiedy używać:

- gdy potrzebujesz jawnej, obiektowej struktury i czytelnej separacji odpowiedzialności,
- gdy dekoratory mają być testowane i rozwijane niezależnie,
- gdy kod ma być dydaktycznie jasny dla zespołu.

Trade-off:

- najwięcej klas,
- większy narzut „ceremonii” (interfejsy, konstruktory, pliki).

### 2) Wariant funkcyjny (`Func<string, string>`)

W tym wariancie każdy krok to funkcja transformująca wiadomość. Kompozycja funkcji tworzy odpowiednik łańcucha dekoratorów.

Mini-diagram (kompozycja):

```text
msg
 |
 v
baseFunc(msg)
 |
 v
withPrefix(...)
 |
 v
withSuffix(...)
 |
 v
wynik
```

Uproszczony kod:

```csharp
Func<string, string> baseFunc = m => $"[BASE]{m}";
Func<string, string> withPrefix = m => $"[PFX]{baseFunc(m)}";
Func<string, string> withSuffix = m => $"{withPrefix(m)}[SFX]";

var result = withSuffix(" Hello");
```

Kiedy używać:

- gdy transformacje są proste i krótkie,
- gdy chcesz szybko zbudować pipeline bez tworzenia wielu klas,
- gdy priorytetem jest zwięzłość kodu.

Trade-off:

- trudniej dodać rozbudowany stan i testować skomplikowane zależności,
- przy większej liczbie kroków spada czytelność nazw i przepływu.

### 3) Wariant pipeline/DI (lista kroków)

Każdy krok to niezależna funkcja/middleware. Kroki uruchamiasz sekwencyjnie, a kolejność zwykle jest konfigurowana (np. przez DI albo ustawienia).

Mini-diagram (kolejność kroków):

```text
input
	|
	+--> [VALID]
	|
	+--> [AUDIT]
	|
	+--> [TRACE]
	|
	v
output
```

Uproszczony kod:

```csharp
var steps = new List<Func<string, string>>
{
		m => $"[VALID]{m}",
		m => $"[AUDIT]{m}",
		m => $"[TRACE]{m}"
};

var message = "Event";
foreach (var step in steps)
{
		message = step(message);
}
```

Kiedy używać:

- gdy łańcuch ma być konfigurowalny runtime,
- gdy różne środowiska mają różne kroki,
- gdy chcesz łatwo włączać/wyłączać elementy procesu.

Trade-off:

- wynik zależy mocno od kolejności kroków,
- błędy konfiguracji (zła kolejność, brak kroku) mogą być trudne do wykrycia,
- przy bardzo dużych pipeline'ach rośnie koszt utrzymania.

## Schemat implementacji

![Schemat implementacji](diagrams/decorator_schema.png)

Źródło: [diagrams/02-implementation-schema.puml](diagrams/02-implementation-schema.puml)

## Typy implementacji

1. Klasyczny (interfejs + klasy dekoratorów): najbardziej czytelny dydaktycznie.
2. Funkcyjny (`Func<string,string>`): lekki i zwięzły dla prostych przypadków.
3. Pipeline/DI (lista kroków): dobry przy konfigurowalnych łańcuchach runtime.

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje wszystkie trzy style w jednym miejscu i celowo używa prostych przykładów, aby dobrze zobaczyć różnice.

Kluczowe fragmenty:

```csharp
var classic = new TimestampDecorator(new ConsoleNotifier());
Func<string, string> withSuffix = msg => $"{withPrefix(msg)}[SFX]";
var pipeline = new List<Func<string, string>> { ... };
```

### Szczegółowe wyjaśnienie programu C#

1. Inicjalizacja przykładu klasycznego:

```csharp
var classic = new TimestampDecorator(new ConsoleNotifier());
Console.WriteLine(classic.Notify("Wariant klasyczny"));
```

Co tu się dzieje:

- `ConsoleNotifier` to komponent bazowy, który umie tylko zwrócić `NOTIFY:{message}`,
- `TimestampDecorator` opakowuje `ConsoleNotifier` i przed delegacją dopisuje timestamp,
- klient wywołuje tylko obiekt zewnętrzny (`classic`), nie musi znać wnętrza łańcucha.

2. Inicjalizacja przykładu funkcyjnego:

```csharp
Func<string, string> baseFunc = msg => $"[BASE]{msg}";
Func<string, string> withPrefix = msg => $"[PFX]{baseFunc(msg)}";
Func<string, string> withSuffix = msg => $"{withPrefix(msg)}[SFX]";
Console.WriteLine(withSuffix(" Wariant funkcyjny"));
```

Co tu się dzieje:

- `baseFunc` to najniższy poziom przetwarzania,
- `withPrefix` dekoruje wynik `baseFunc`, a nie oryginalny tekst,
- `withSuffix` dekoruje wynik `withPrefix`, więc kompozycja działa kaskadowo,
- końcowy rezultat odzwierciedla kolejność zagnieżdżenia funkcji.

3. Inicjalizacja przykładu pipeline/DI:

```csharp
var pipeline = new List<Func<string, string>>
{
	m => $"[VALID]{m}",
	m => $"[AUDIT]{m}",
	m => $"[TRACE]{m}"
};

var message = "Wariant pipeline/DI";
foreach (var step in pipeline)
{
	message = step(message);
}
Console.WriteLine(message);
```

Co tu się dzieje:

- lista kroków reprezentuje konfigurowalny łańcuch,
- każda iteracja pętli aktualizuje tę samą zmienną `message`,
- finalny napis zawiera wszystkie znaczniki dodane po kolei,
- jeśli zmienisz kolejność elementów w liście, zmieni się semantyka wyniku.

4. Wspólny wniosek architektoniczny:

- wszystkie 3 style realizują ideę Dekoratora: „dodaj zachowanie bez zmiany bazowego komponentu”,
- różnią się przede wszystkim poziomem formalizacji: klasyczny > pipeline > funkcyjny,
- wybór zależy od tego, czy bardziej liczy się czytelność domenowa, czy szybkość implementacji i konfiguracja runtime.

## Uruchom

```bash
cd src/07-dekorator/04-implementacje-i-typy/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Zadanie: dodaj w pipeline krok `Sanitize`, który usuwa niepożądane znaki.
Rozwiązanie: dodaj funkcję do listy pipeline i przetestuj kolejność kroków.

2. Zadanie: rozbuduj wariant klasyczny o `CorrelationIdDecorator`.
Wyjaśnienie: dekorator jest naturalny dla cross-cutting concerns.

## Literatura

- Microsoft Docs DI: https://learn.microsoft.com/dotnet/core/extensions/dependency-injection
- Refactoring.Guru: https://refactoring.guru/design-patterns/decorator
