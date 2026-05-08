# Wzorzec Metoda Szablonowa (Template Method)

## Cel modułu

Ten moduł zawiera komplet materiałów dydaktycznych do wykładu o wzorcu **Metoda Szablonowa** (Template Method).  
Wzorzec definiuje **szkielet algorytmu** w klasie bazowej i pozwala podklasom na wypełnianie wybranych kroków, bez zmiany ogólnej struktury algorytmu. Jest fundamentem zasady **Hollywood Principle** i wzorcem używanym w setkach frameworków .NET.

## Spis tematów

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Rys historyczny, problem duplikacji kodu, koncepcja wzorca |
| [02](02-kiedy-stosować-zalety-wady/README.md) | Kiedy stosować | Sygnały decyzyjne, zalety, wady, odmiany wzorca |
| [03](03-struktura-i-działanie/README.md) | Struktura i działanie | Rolę GoF, diagramy klas i sekwencji, konsekwencje stosowania |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Abstrakcyjne kroki, hooki, implementacje domyślne, hybrydy |
| [05](05-wady-i-zalety/README.md) | Wady i zalety | Analiza stosowania — Hollywood Principle, LSP, Fragile Base Class |
| [06](06-duży-przykład-i-alternatywy/README.md) | Duży przykład | System raportowania — pełny przykład z testami i alternatywami |

## Efekty uczenia

Po przerobieniu modułu student:

1. Rozumie problem duplikacji szkieletu algorytmu w pokrewnych klasach.
1. Potrafi zaprojektować rolę `AbstractClass` (z metodą szablonową) i `ConcreteClass` (z krokami algorytmu).
1. Zna różnicę między krokami abstrakcyjnymi (*primitive operations*) a haczykami (*hooks*).
1. Rozumie zasadę Hollywood Principle i jej związek ze wzorcem.
1. Potrafi ocenić kiedy Template Method jest lepszy od Strategii i odwrotnie.
1. Wie o problemach dziedziczenia: Fragile Base Class i naruszeniu LSP.

## Jak korzystać z modułu

1. Pracuj sekwencyjnie od 01 do 06.
1. W każdym temacie przeczytaj README, obejrzyj diagramy i uruchom kod C#.
1. Na koniec wykonaj zadania z [ZADANIA.md](ZADANIA.md).

## Uruchamianie przykładów

```bash
cd src/15-metoda-szablonowa/01-idea-i-kontekst/Examples && dotnet run
cd src/15-metoda-szablonowa/02-kiedy-stosować-zalety-wady/Examples && dotnet run
cd src/15-metoda-szablonowa/03-struktura-i-działanie/Examples && dotnet run
cd src/15-metoda-szablonowa/04-typy-implementacji/Examples && dotnet run
cd src/15-metoda-szablonowa/05-wady-i-zalety/Examples && dotnet run
cd src/15-metoda-szablonowa/06-duży-przykład-i-alternatywy/Examples && dotnet run
```

## Uruchamianie testów

```bash
cd src/15-metoda-szablonowa/06-duży-przykład-i-alternatywy/Tests && dotnet test
```

## Materiały prowadzącego

Szczegółowy scenariusz wykładu: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania wraz z rozwiązaniami i omówieniem: [ZADANIA.md](ZADANIA.md)

## Literatura i źródła

1. Gamma E., Helm R., Johnson R., Vlissides J. — *Design Patterns: Elements of Reusable Object-Oriented Software* (1994), rozdział Template Method — s. 325–330.
1. Freeman E., Robson E. — *Head First Design Patterns* (2004/2020), rozdz. 8 — *The Template Method Pattern*.
1. Martin R.C. — *Agile Software Development, Principles, Patterns, and Practices* (2002), rozdział 14 — Template Method & Strategy.
1. [Refactoring Guru — Template Method](https://refactoring.guru/design-patterns/template-method) — ilustracje i przykłady wielojęzykowe.
1. [Microsoft Docs — Abstract classes (C#)](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/abstract-and-sealed-classes-and-class-members) — dokumentacja słów kluczowych `abstract`, `virtual`, `sealed`.
1. [SourceMaking — Template Method](https://sourcemaking.com/design_patterns/template_method) — teoria i przykłady.
