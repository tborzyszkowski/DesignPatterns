# Wzorzec Łańcuch Zobowiązań (Chain of Responsibility)

> Wzorzec behawioralny GoF — pozwala przekazywać żądanie wzdłuż łańcucha potencjalnych
> obsługujących, dopóki jeden z nich nie obsłuży żądania.

---

## Struktura modułu

| # | Temat | Opis |
|---|-------|------|
| [01](01-idea-i-kontekst/) | Idea i kontekst | Historia, problem, koncepcja, definicja GoF |
| [02](02-kiedy-stosowac-zalety-wady/) | Kiedy stosować | Sygnały użycia, warianty, zalety, wady |
| [03](03-struktura-gof/) | Struktura GoF | Diagramy klas i sekwencji, role uczestników |
| [04](04-typy-implementacji/) | Typy implementacji | OOP, Func<>, Middleware, IPipelineBehavior |
| [05](05-wiekszy-przyklad/) | Większy przykład | Bankomat — pełny przykład z testami xUnit |
| [06](06-alternatywy-i-decyzja/) | Alternatywy i decyzja | CoR vs Observer, Strategy, Decorator, Template Method |

---

## Efekty uczenia się

Po ukończeniu tego modułu student:

1. Wyjaśnia problem, który rozwiązuje wzorzec Łańcuch Zobowiązań
2. Identyfikuje sytuacje, w których CoR jest odpowiednim rozwiązaniem
3. Implementuje CoR w czterech wariantach (OOP, Func<>, Middleware, IPipelineBehavior)
4. Analizuje diagram klas GoF i mapuje go na kod C#
5. Pisze testy jednostkowe dla poszczególnych ogniw łańcucha
6. Wybiera odpowiedni wzorzec (CoR vs Observer vs Strategy vs Decorator) dla danego problemu

---

## Uruchamianie przykładów

```bash
# Temat 01
cd src/18-lancuch-zobowiazan/01-idea-i-kontekst/Examples && dotnet run

# Temat 02
cd src/18-lancuch-zobowiazan/02-kiedy-stosowac-zalety-wady/Examples && dotnet run

# Temat 03
cd src/18-lancuch-zobowiazan/03-struktura-gof/Examples && dotnet run

# Temat 04
cd src/18-lancuch-zobowiazan/04-typy-implementacji/Examples && dotnet run

# Temat 05
cd src/18-lancuch-zobowiazan/05-wiekszy-przyklad/Examples && dotnet run

# Temat 06
cd src/18-lancuch-zobowiazan/06-alternatywy-i-decyzja/Examples && dotnet run
```

## Testy jednostkowe (temat 05)

```bash
cd src/18-lancuch-zobowiazan/05-wiekszy-przyklad/Tests
dotnet test
```

---

## Stara wersja

Historyczne przykłady (Java + stary C#) w `old_version/18LancuchZobowiazan/`:
- `01Simple/` — abstrakcyjny Handler (C# .NET Framework)
- `02Managers/` — zatwierdzanie zakupów przez menedżerów (C#)
- `03Bankomat/` — bankomat (Java)

---

## Literatura

1. **GoF** — Gamma, Helm, Johnson, Vlissides: *Design Patterns. Elements of Reusable Object-Oriented Software* (1994), s. 223–232
2. **RefactoringGuru** — https://refactoring.guru/design-patterns/chain-of-responsibility
3. **Microsoft ASP.NET Core Middleware** — https://learn.microsoft.com/en-us/aspnet/core/fundamentals/middleware
4. **MediatR Pipeline Behaviors** — https://github.com/jbogard/MediatR/wiki/Behaviors
