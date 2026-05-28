# Wzorzec Mediator

> **Wzorzec behawioralny** — definiuje obiekt (mediatora), który hermetyzuje sposób interakcji zbioru obiektów. Mediator zapewnia luźne sprzężenie, eliminując bezpośrednie referencje między współpracującymi obiektami.

## Tematy

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Problem siatki zależności, historia, definicja GoF |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Sygnały wskazujące, 4 odmiany wzorca |
| [03](03-struktura-gof/README.md) | Struktura GoF | Diagram klas, sekwencji, cykl życia |
| [04](04-typy-implementacji/README.md) | Typy implementacji | Klasyczny, delegaty, MediatR, funkcyjny |
| [05](05-wady-zalety-alternatywy/README.md) | Wady, zalety, alternatywy | Porównanie z Observer, Facade, CoR, Command |
| [06](06-wiekszy-przyklad/README.md) | Większy przykład | Kontrola ruchu lotniczego + xUnit testy |

## Efekty kształcenia

Po ukończeniu tego modułu student:
1. Rozumie, kiedy siatka zależności jest problemem i jak Mediator go rozwiązuje
2. Potrafi zidentyfikować role GoF (Mediator, Colleague) w istniejącym kodzie
3. Umie wybrać odpowiedni typ implementacji (GoF/delegaty/MediatR/Hub)
4. Rozróżnia Mediator od Observer, Facade, CoR i Command
5. Potrafi zaprojektować i zaimplementować własny Mediator z testami
6. Zna zagrożenie "God Object" i wie jak mu przeciwdziałać

## Szybki start

```bash
# Temat 01 — idea
cd src/19-mediator/01-idea-i-kontekst/Examples && dotnet run

# Temat 02 — kiedy stosować
cd src/19-mediator/02-kiedy-stosowac-zalety-wady/Examples && dotnet run

# Temat 03 — struktura GoF
cd src/19-mediator/03-struktura-gof/Examples && dotnet run

# Temat 04 — typy implementacji
cd src/19-mediator/04-typy-implementacji/Examples && dotnet run

# Temat 05 — alternatywy
cd src/19-mediator/05-wady-zalety-alternatywy/Examples && dotnet run

# Temat 06 — większy przykład + testy
cd src/19-mediator/06-wiekszy-przyklad/Examples && dotnet run
cd src/19-mediator/06-wiekszy-przyklad/Tests && dotnet test
```

## Literatura

- E. Gamma, R. Helm, R. Johnson, J. Vlissides, *Design Patterns*, Addison-Wesley, 1994
- [Mediator — refactoring.guru](https://refactoring.guru/design-patterns/mediator)
- [MediatR — dokumentacja](https://github.com/jbogard/MediatR)
- [SignalR Hubs — dokumentacja Microsoft](https://learn.microsoft.com/aspnet/core/signalr/hubs)
