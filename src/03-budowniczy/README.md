# Wzorzec Builder (Budowniczy)

> **Kategoria:** Kreacyjny  
> **Rodzina GoF:** Gang of Four (1994)

---

## Definicja

> Oddziela proces tworzenia złożonego obiektu od jego reprezentacji, tak by ten sam proces tworzenia mógł prowadzić do różnych reprezentacji.
>
> — *Design Patterns: Elements of Reusable Object-Oriented Software*, GoF 1994

Inaczej mówiąc: Builder wyodrębnia *jak* obiekt jest budowany (krok po kroku) od tego, *czym* ten obiekt jest.

---

## Spis treści

| # | Temat | Opis |
|---|-------|------|
| [01](01-problem-konstrukcji/README.md) | **Problem z konstrukcją obiektów** | Telescoping constructor, mutowalne pola, motywacja do Buildera |
| [02](02-struktura-gof/README.md) | **Struktura GoF** | Director, Builder (interfejs), ConcreteBuilder, Product |
| [03](03-fluent-builder/README.md) | **Fluent Builder** | Method chaining, `implicit operator`, EmployeeBuilder, EmailBuilder |
| [04](04-typy-implementacji/README.md) | **Typy implementacji** | Step Builder, Builder z `record` i `with`, porównanie wariantów |
| [05](05-kiedy-stosowac/README.md) | **Kiedy stosować — i kiedy nie** | Drzewo decyzyjne, ReportBuilder, counter-examples |

---

## Szybki start

Każda sekcja zawiera niezależny projekt .NET 9:

```bash
cd src/03-budowniczy/01-problem-konstrukcji/Examples && dotnet run
cd src/03-budowniczy/02-struktura-gof/Examples        && dotnet run
cd src/03-budowniczy/03-fluent-builder/Examples       && dotnet run
cd src/03-budowniczy/04-typy-implementacji/Examples   && dotnet run
cd src/03-budowniczy/05-kiedy-stosowac/Examples       && dotnet run
```

---

## Kontekst historyczny

| Rok | Wydarzenie |
|-----|-----------|
| 1994 | GoF opisuje Builder jako jeden z 23 wzorców kreacyjnych |
| 2001 | Martin Fowler opisuje **Fluent Interface** jako DSL w kodzie |
| 2008 | Joshua Bloch popularyzuje **nested Builder** w *Effective Java* (2nd ed.) |
| 2010+ | **Step Builder** zyskuje popularność jako sposób wymuszania kolejności kroków |
| 2020 | C# 9 `record` + `with` wyrażenia jako lekka alternatywa dla buildera |

---

## Relacje z innymi wzorcami

```
Builder
 ├── vs. Abstract Factory  — Factory tworzy rodziny produktów (KTÓRY),
 │                           Builder montuje jeden produkt krok po kroku (JAK)
 ├── + Composite           — Builder często tworzy struktury drzewiaste (Composite)
 ├── + Factory Method      — Director może użyć Factory Method do wyboru Buildera
 └── vs. Prototype         — Prototype klonuje istniejący obiekt;
                             Builder tworzy nowy od podstaw
```

---

## Literatura

| Źródło | Temat |
|--------|-------|
| GoF, *Design Patterns* (1994), s. 97–106 | Oryginalna definicja wzorca |
| Joshua Bloch, *Effective Java* (2018), Item 2 | Nested Builder jako zamiennik telescoping constructor |
| Martin Fowler, *Domain-Specific Languages* (2010) | Fluent Interface i wewnętrzne DSL |
| [refactoring.guru/design-patterns/builder](https://refactoring.guru/design-patterns/builder) | Wizualne wyjaśnienie z przykładami |
