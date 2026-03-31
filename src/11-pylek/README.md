# Wzorzec Pylek (Flyweight)

## Cel modulu

Ten modul zawiera komplet materialow do wykladu o wzorcu Pylek.
Nacisk jest na rozdzielenie stanu wspoldzielonego (`intrinsic`) i kontekstowego (`extrinsic`) oraz na praktyczna ocene zysku pamieci.

## Spis tematow

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Problem redundancji danych i motywacja biznesowa |
| [02](02-intrinsic-vs-extrinsic/README.md) | Intrinsic vs Extrinsic | Jak podzielic stan i uniknac bledow modelowania |
| [03](03-struktura-gof/README.md) | Struktura GoF | Role, relacje i przeplyw wywolan |
| [04](04-implementacja-csharp/README.md) | Implementacja C# | FlyweightFactory, cache i wspolbieznosc |
| [05](05-case-study-czcionki-i-tiles/README.md) | Case study | Czcionki i kafelki jako duza liczba obiektow |
| [06](06-kiedy-stosowac-i-alternatywy/README.md) | Kiedy stosowac | Decyzje architektoniczne i porownanie z alternatywami |

## Efekty uczenia

Po module student:

1. Rozumie, kiedy Flyweight ma sens i jaki problem rozwiazuje.
1. Potrafi rozdzielic stan na intrinsic i extrinsic.
1. Umie zaprojektowac factory z cache dla flyweightow.
1. Potrafi porownac Flyweight z Object Pool i zwyklym cache.

## Jak korzystac z modulu

1. Zacznij od 01 i przechodz sekwencyjnie do 06.
1. Po kazdym temacie odtworz diagram i uruchom przyklad.
1. Na koncu rozwiaz zadania z [ZADANIA.md](ZADANIA.md).

## Materialy prowadzacego

Scenariusz 90-minutowego spotkania: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Literatura

1. GoF, *Design Patterns*, rozdzial Flyweight.
1. Refactoring.Guru, Flyweight pattern.
1. Dokumentacja .NET: `ConcurrentDictionary`, `WeakReference`, `string.Intern`.
