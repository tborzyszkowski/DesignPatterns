# Wzorzec Clean Architecture

> **Wzorzec architektoniczny** — separuje logikę biznesową od szczegółów technicznych,
> tworząc system niezależny od frameworków, baz danych i interfejsów użytkownika.
> Opisany przez Roberta C. Martina w 2012 roku, inspirowany wcześniejszymi wzorcami
> Onion Architecture (Palermo, 2008) i Hexagonal Architecture (Cockburn, 2005).

## Tematy

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-warstwy/README.md) | Idea i warstwy | Problem N-Tier, historia, Zasada Zależności, cztery warstwy |
| [02](02-encje-i-przypadki-uzycia/README.md) | Encje i przypadki użycia | Entities, Value Objects, Use Cases, przepływ danych |
| [03](03-zaleznosci-i-di/README.md) | Zależności i DI | DIP, porty, adaptery, Composition Root |
| [04](04-testowanie/README.md) | Testowanie | Piramida testów, testowanie warstw, testy izolowane |
| [05](05-porownanie-architektur/README.md) | Porównanie architektur | N-Tier vs Onion vs Hexagonal vs Clean — kiedy stosować |
| [06](06-wiekszy-przyklad/README.md) | Większy przykład | System zarządzania zadaniami: 4 warstwy + testy xUnit |

## Efekty kształcenia

Po ukończeniu tego modułu student:

1. Rozumie motywację stojącą za Clean Architecture i problemy, które rozwiązuje
2. Zna i potrafi zastosować Zasadę Zależności (Dependency Rule)
3. Umie zaprojektować strukturę projektu z podziałem na warstwy Domain, Application, Infrastructure i Presentation
4. Rozumie koncepcję portów (interfejsów) definiowanych w warstwach wewnętrznych i adapterów (implementacji) w warstwach zewnętrznych
5. Potrafi pisać testy jednostkowe logiki biznesowej bez zależności od infrastruktury
6. Zna inne architektury (Onion, Hexagonal) i potrafi ocenić, kiedy stosować każdą z nich

## Szybki start

```bash
# Temat 01 — idea i warstwy
cd src/A02-clean-architecture/01-idea-i-warstwy/Examples && dotnet run

# Temat 02 — encje i przypadki użycia
cd src/A02-clean-architecture/02-encje-i-przypadki-uzycia/Examples && dotnet run

# Temat 03 — zależności i DI
cd src/A02-clean-architecture/03-zaleznosci-i-di/Examples && dotnet run

# Temat 04 — testowanie
cd src/A02-clean-architecture/04-testowanie/Examples && dotnet run

# Temat 05 — porównanie architektur
cd src/A02-clean-architecture/05-porownanie-architektur/Examples && dotnet run

# Temat 06 — większy przykład + testy
cd src/A02-clean-architecture/06-wiekszy-przyklad/Examples && dotnet run
cd src/A02-clean-architecture/06-wiekszy-przyklad/Tests && dotnet test
```

## Literatura i źródła

- [Robert C. Martin — Clean Architecture (blog, 2012)](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Robert C. Martin — *Clean Architecture: A Craftsman's Guide* (Informit, 2017)](https://www.informit.com/store/clean-architecture-a-craftsmans-guide-to-software-structure-9780134494166)
- [Jeffrey Palermo — Onion Architecture (2008)](https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/)
- [Alistair Cockburn — Hexagonal Architecture (2005)](https://alistair.cockburn.us/hexagonal-architecture/)
- [Microsoft — Architektura N-Tier](https://learn.microsoft.com/en-us/azure/architecture/guide/architecture-styles/n-tier)
- [Microsoft — Wstrzykiwanie zależności w .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Martin Fowler — Inversion of Control Containers](https://martinfowler.com/articles/injection.html)
