# Wzorzec CQRS (Command Query Responsibility Segregation)

> **Wzorzec architektoniczny** — rozdziela odpowiedzialność za modyfikację stanu systemu
> (Command) od odpowiedzialności za odczyt danych (Query).
> Wywodzi się z zasady CQS Bertranda Meyera i został spopularyzowany przez Grega Younga.

## Tematy

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Problem CRUD, zasada CQS, historia, definicja |
| [02](02-struktura-podstawowa/README.md) | Struktura podstawowa | ICommand, IQuery, handlery, dispatcher |
| [03](03-separacja-modeli/README.md) | Separacja modeli | Write Model vs Read Model, DTO, projekcje |
| [04](04-event-sourcing/README.md) | CQRS + Event Sourcing | Zdarzenia domenowe, Event Store, eventual consistency |
| [05](05-wady-zalety-alternatywy/README.md) | Wady, zalety, alternatywy | Kiedy stosować, porównanie z CRUD i MediatR |
| [06](06-wiekszy-przyklad/README.md) | Większy przykład | Wypożyczalnia książek + testy xUnit |

## Efekty kształcenia

Po ukończeniu tego modułu student:

1. Rozumie różnicę między zasadą CQS a wzorcem CQRS
2. Potrafi zidentyfikować scenariusze, w których CQRS przynosi korzyści
3. Umie zaprojektować i zaimplementować podstawową strukturę CQRS (komendy, zapytania, handlery)
4. Rozumie koncepcję separacji modelu zapisu i odczytu
5. Zna związek między CQRS a Event Sourcing
6. Potrafi ocenić wady i zalety wzorca i wybrać odpowiednią alternatywę

## Szybki start

```bash
# Temat 01 — idea
cd src/A01-cqrs/01-idea-i-kontekst/Examples && dotnet run

# Temat 02 — struktura podstawowa
cd src/A01-cqrs/02-struktura-podstawowa/Examples && dotnet run

# Temat 03 — separacja modeli
cd src/A01-cqrs/03-separacja-modeli/Examples && dotnet run

# Temat 04 — Event Sourcing
cd src/A01-cqrs/04-event-sourcing/Examples && dotnet run

# Temat 05 — alternatywy
cd src/A01-cqrs/05-wady-zalety-alternatywy/Examples && dotnet run

# Temat 06 — większy przykład + testy
cd src/A01-cqrs/06-wiekszy-przyklad/Examples && dotnet run
cd src/A01-cqrs/06-wiekszy-przyklad/Tests && dotnet test
```

## Literatura i źródła

- [Greg Young — CQRS Documents (2010)](https://cqrs.files.wordpress.com/2010/11/cqrs_documents.pdf)
- [Martin Fowler — CQRS (2011)](https://martinfowler.com/bliki/CQRS.html)
- [Microsoft — CQRS Pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Microsoft — Event Sourcing Pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing)
- Bertrand Meyer — *Object Oriented Software Construction* (1988) — rozdział o CQS
