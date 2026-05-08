# Wzorzec Pyłek (Flyweight)

## Cel modułu

Ten moduł zawiera komplet materiałów do wykładu o wzorcu Pyłek.
Nacisk położono na rozdzielenie stanu współdzielonego (`intrinsic`) i kontekstowego (`extrinsic`) oraz na praktyczną ocenę zysku pamięci.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Problem redundancji danych i motywacja biznesowa |
| [02](02-intrinsic-vs-extrinsic/README.md) | Intrinsic vs Extrinsic | Jak podzielić stan i uniknąć błędów modelowania |
| [03](03-struktura-gof/README.md) | Struktura GoF | Rolę, relacje i przepływ wywołań |
| [04](04-implementacja-csharp/README.md) | Implementacja C# | FlyweightFactory, cache i współbieżność |
| [05](05-case-study-czcionki-i-tiles/README.md) | Case study | Czcionki i kafelki jako duża liczba obiektów |
| [06](06-kiedy-stosować-i-alternatywy/README.md) | Kiedy stosować | Decyzje architektoniczne i porównanie z alternatywami |

## Efekty uczenia

Po tym module student:

1. Rozumie, kiedy Flyweight ma sens i jaki problem rozwiązuje.
1. Potrafi rozdzielić stan na intrinsic i extrinsic.
1. Umie zaprojektować fabrykę z cache dla flyweightów.
1. Potrafi porównać Flyweight z Object Pool i zwykłym cache.

## Jak korzystać z modułu

1. Zacznij od 01 i przechodź sekwencyjnie do 06.
1. Po każdym temacie odtwórz diagram i uruchom przykład.
1. Na końcu rozwiąż zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/11-pyłek/01-idea-i-kontekst/Examples && dotnet run
cd src/11-pyłek/02-intrinsic-vs-extrinsic/Examples && dotnet run
cd src/11-pyłek/03-struktura-gof/Examples && dotnet run
cd src/11-pyłek/04-implementacja-csharp/Examples && dotnet run
cd src/11-pyłek/05-case-study-czcionki-i-tiles/Examples && dotnet run
cd src/11-pyłek/06-kiedy-stosować-i-alternatywy/Examples && dotnet run
```

## Materiały prowadzącego

Scenariusz 90-minutowego spotkania: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z pytaniami kontrolnymi: [ZADANIA.md](ZADANIA.md)

## Literatura

1. GoF, *Design Patterns*, rozdział Flyweight.
1. Refactoring.Guru, Flyweight pattern.
1. Dokumentacja .NET: `ConcurrentDictionary`, `WeakReference`, `string.Intern`.
