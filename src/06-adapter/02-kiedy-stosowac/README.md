# 02. Kiedy stosować Adapter

## Kryteria

Stosuj Adapter, gdy:

- klient musi działać na stabilnym interfejsie,
- nie możesz zmienić kodu dostawcy (zewnętrzne API, legacy),
- migracja ma być etapowa i niskiego ryzyka.

Nie stosuj, gdy:

- możesz bezpiecznie zmienić oba końce kontraktu,
- adapter ukrywa złą granicę domenową,
- rośnie liczba warstw tłumaczących i koszt utrzymania.

## Co mierzyć

1. Czas mapowania danych w adapterze.
2. Częstotliwość błędów transformacji.
3. Stabilność kontraktu po stronie klienta.
4. Koszt utrzymania przy dodawaniu nowych pól.

## Diagramy

![Drzewo decyzji](diagrams/01-decision-tree.png)

Źródło: [diagrams/01-decision-tree.puml](diagrams/01-decision-tree.puml)

![Sygnały](diagrams/02-signals.png)

Źródło: [diagrams/02-signals.puml](diagrams/02-signals.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Fragment:

```csharp
var metrics = Benchmark.Run(operations: 1000, mapCostMs: 2);
Console.WriteLine($"NoAdapter={metrics.NoAdapterMs} ms, Adapter={metrics.AdapterMs} ms");
```
