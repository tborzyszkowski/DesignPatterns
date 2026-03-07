# Wzorce Projektowe: Rodzina Fabryka

> **"Program to an interface, not an implementation."**  
> — Gang of Four, *Design Patterns* (1994)

Wzorce z rodziny "Fabryka" to jedne z najważniejszych wzorców **kreacyjnych**.
Odpowiadają na pytanie: *kto i jak odpowiada za tworzenie obiektów?*
Zrozumienie ich kolejności — od zasady OCP, przez prostą fabrykę, metodę wytwórczą, aż do fabryki abstrakcyjnej — pozwala świadomie dobierać właściwe narzędzie do konkretnego problemu.

---

## Spis treści

| Nr | Temat | Opis |
|----|-------|------|
| [01](01-open-close/README.md) | **Open-Closed Principle** | Fundament: dlaczego kod zamknięty na modyfikacje jest lepszy |
| [02](02-simple-factory/README.md) | **Simple Factory** | Enkapsulacja `new` — wygodny skrót, ale nie wzorzec GoF |
| [03](03-factory-method/README.md) | **Metoda Wytwórcza** | Odroczone tworzenie przez dziedziczenie; OCP przez podklasy |
| [04](04-abstract-factory/README.md) | **Fabryka Abstrakcyjna** | Tworzenie całych rodzin kompatybilnych obiektów |

---

## Kontekst historyczny

Wzorce Metoda Wytwórcza i Fabryka Abstrakcyjna opisali **Gang of Four** (Gamma, Helm, Johnson, Vlissides)
w *"Design Patterns: Elements of Reusable Object-Oriented Software"* (1994).
Należą do kategorii **wzorców kreacyjnych** — koncentrują się na tym, *jak* tworzyć obiekty,
oddzielając ten mechanizm od logiki biznesowej.

**Simple Factory** nie jest formalnym wzorcem GoF — to popularna idiom/praktyka,
często mylona z Factory Method. Jej świadome rozróżnienie jest pierwszym krokiem do dobrego projektu.

**Open-Closed Principle** (zasada otwarte-zamknięte) pochodzi z pracy Bertranda Meyera (1988)
i został spopularyzowany przez Roberta C. Martina jako litera **O** w akronimie **SOLID**.
Stanowi fundament, który tłumaczy, *dlaczego* w ogóle sięgamy po wzorce fabrykujące.

---

## Mapa zależności tematycznych

```
Open-Closed Principle
      │
      ▼
 Simple Factory  ──── narusza OCP (modyfikacja fabryki przy nowym typie)
      │
      ▼
Factory Method   ──── zachowuje OCP (nowa podklasa Creator)
      │
      ▼
Abstract Factory ──── zachowuje OCP + gwarantuje spójność rodzin produktów
```

---

## Jak uruchomić przykłady

Każdy podkatalog zawiera samodzielny projekt **.NET 9** w folderze `Examples/`. Wymagania:

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) lub nowszy
- Opcjonalnie: Java + [PlantUML](https://plantuml.com/) do renderowania diagramów `.puml`

```bash
# Uruchomienie przykładu
cd src/02-fabryka/03-factory-method/Examples
dotnet run

# Wszystkie cztery sekcje
cd src/02-fabryka/01-open-close/Examples  && dotnet run
cd src/02-fabryka/02-simple-factory/Examples && dotnet run
cd src/02-fabryka/03-factory-method/Examples  && dotnet run
cd src/02-fabryka/04-abstract-factory/Examples && dotnet run
```

### Renderowanie diagramów PlantUML

```bash
# Renderowanie wszystkich diagramów naraz (wymaga Java i plantuml.jar)
Get-ChildItem -Recurse src/02-fabryka -Filter "*.puml" | ForEach-Object {
    java -jar plantuml.jar $_.FullName
}

# Lub użyj rozszerzenia PlantUML dla VS Code: jebbs.plantuml
```

---

## Literatura

| Źródło | Typ |
|--------|-----|
| Gamma, E., Helm, R., Johnson, R., Vlissides, J. (1994). *Design Patterns: Elements of Reusable Object-Oriented Software*. Addison-Wesley. | Książka |
| Freeman, E., Robson, E. (2021). *Head First Design Patterns* (2nd ed.). O'Reilly. Rozdz. 4. | Książka |
| Martin, R. C. (2003). *Agile Software Development: Principles, Patterns, and Practices*. Prentice Hall. (OCP) | Książka |
| Meyer, B. (1988). *Object-Oriented Software Construction*. Prentice Hall. (źródło OCP) | Książka |
| Shvets, A. — *Factory Method*. [refactoring.guru/design-patterns/factory-method](https://refactoring.guru/design-patterns/factory-method) | Web |
| Shvets, A. — *Abstract Factory*. [refactoring.guru/design-patterns/abstract-factory](https://refactoring.guru/design-patterns/abstract-factory) | Web |
| Microsoft — *Abstract Factory in C#*. [refactoring.guru/design-patterns/abstract-factory/csharp/example](https://refactoring.guru/design-patterns/abstract-factory/csharp/example) | Web |
