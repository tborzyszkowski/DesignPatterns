# 03. Struktura GoF Adapter

## Szczegółowy opis

## Role we wzorcu

1. `Target` - interfejs oczekiwany przez klienta.
2. `Adaptee` - istniejąca klasa o niekompatybilnym API.
3. `Adapter` - tłumacz pomiędzy `Target` i `Adaptee`.
4. `Client` - używa wyłącznie `Target`.

Jak działa współpraca ról:

1. `Client` zna tylko kontrakt `Target`, więc jest odseparowany od szczegółów legacy.
2. `Adapter` implementuje `Target`, dzięki czemu jest podstawialny dla klienta.
3. `Adapter` posiada referencję do `Adaptee` i deleguje wywołania po odpowiednim mapowaniu.
4. `Adaptee` pozostaje niezmieniony, a logika translacji jest skoncentrowana w jednym miejscu.

## Diagramy

![Diagram klas](diagrams/adapter_class_diagram.png)

Źródło: [diagrams/01-class-diagram.puml](diagrams/01-class-diagram.puml)

Opis diagramu klas:

1. Relacja `Target <|.. Adapter` pokazuje, że adapter implementuje oczekiwany kontrakt klienta.
2. Relacja `Adapter --> Adaptee` oznacza kompozycję/delegację do istniejącego API.
3. Relacja `Client --> Target` utrzymuje klienta niezależnym od konkretnej implementacji adaptera.
4. Taki układ minimalizuje sprzężenie i upraszcza podmianę dostawcy integracji.

![Diagram sekwencji](diagrams/adapter_sequence.png)

Źródło: [diagrams/02-sequence.puml](diagrams/02-sequence.puml)

Opis diagramu sekwencji:

1. `Client` wywołuje `Request("demo")` na interfejsie `Target`.
2. `Adapter` tłumaczy żądanie i wywołuje `SpecificRequest("demo")` na `Adaptee`.
3. `Adaptee` zwraca odpowiedź w formacie legacy.
4. `Adapter` mapuje odpowiedź do formatu oczekiwanego przez klienta.
5. `Client` dostaje wynik bez świadomości, że dane pochodzą z innego kontraktu.

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Co robi program:

1. Definiuje `ITarget` jako interfejs stabilny dla klienta.
2. Udostępnia `Adaptee`, który zwraca dane w formacie `legacy::...`.
3. `LegacyAdapter` implementuje `ITarget`, deleguje wywołanie do `Adaptee` i mapuje prefiks `legacy::` na `mapped::`.
4. W `Main()` klient używa tylko `ITarget`, więc nie zależy od szczegółów klasy legacy.

```csharp
ITarget target = new LegacyAdapter(new Adaptee());
Console.WriteLine(target.Request("demo"));
```

Interpretacja wyniku:

1. Program wypisze wartość w stylu `mapped::demo`.
2. To potwierdza dwa etapy translacji: delegację do legacy i mapowanie odpowiedzi w adapterze.
3. Wzorzec spełnia cel GoF: kompatybilność interfejsów bez modyfikacji `Adaptee`.

Uruchom:

```bash
cd src/06-adapter/03-struktura-gof/Examples
dotnet run
```
