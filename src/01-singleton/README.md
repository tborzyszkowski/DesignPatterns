# Wzorzec Projektowy: Singleton (Antywzorzec)

> **"Zapewnij, że klasa ma tylko jeden egzemplarz i udostępnij globalny punkt dostępu do niego."**  
> — Gang of Four, *Design Patterns* (1994)

Singleton jest jednym z najprostszych, a zarazem najbardziej kontrowersyjnych wzorców projektowych.  
Współczesna inżynieria oprogramowania coraz częściej klasyfikuje go jako **antywzorzec** — jednak rozumienie go jest niezbędne zarówno po to, by go poprawnie stosować, jak i by wiedzieć, kiedy go unikać.

---

## Spis treści

| Nr  | Temat                                          | Opis                                                      |
|-----|------------------------------------------------|-----------------------------------------------------------|
| [01](01-definicja/README.md)       | **Definicja**         | Definicja GoF, struktura UML, podstawowe implementacje w C# |
| [02](02-konsekwencje/README.md)    | **Konsekwencje**      | Zalety i wady stosowania singletona                        |
| [03](03-przyklady/README.md)       | **Przykłady użycia**  | Logger, Konfiguracja, Pula połączeń, Fabryka               |
| [04](04-problemy/README.md)        | **Problemy**          | Dziedziczenie, serializacja, refleksja                     |
| [05](05-wspolbieznosc/README.md)   | **Współbieżność**     | Race conditions, Double-Checked Locking, `Lazy<T>`         |
| [06](06-alternatywy/README.md)     | **Alternatywy**       | Kiedy i jak zastąpić singleton; kiedy go zachować          |

---

## Kontekst historyczny

Wzorzec Singleton został opisany w 1994 roku przez **Gang of Four** (Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides)  
w książce *"Design Patterns: Elements of Reusable Object-Oriented Software"*. Należy do kategorii **wzorców kreacyjnych**.

Z biegiem lat zyskał złą sławę — zbyt łatwo się po niego sięga i zbyt trudno go potem usunąć.  
Michael Feathers i inni autorzy określają go mianem "global state in disguise" (globalny stan w przebraniu).

---

## Jak uruchomić przykłady

Każdy przykład w podkatalogach `code/` to samodzielny projekt .NET 8. Wymagania:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) lub nowszy
- Opcjonalnie: [PlantUML](https://plantuml.com/) do renderowania diagramów `.puml`

```bash
# Uruchomienie przykładu
cd 01-definicja/code/SingletonDefinition
dotnet run

# Uruchomienie testów jednostkowych
cd 01-definicja/code/SingletonDefinition.Tests
dotnet test
```

### Renderowanie diagramów PlantUML

```bash
# Jeśli masz zainstalowany PlantUML (wymaga Java)
plantuml **/*.puml

# Lub użyj rozszerzenia PlantUML dla VS Code: jebbs.plantuml
```

---

## Literatura

| Źródło | Typ |
|--------|-----|
| Gamma, E., Helm, R., Johnson, R., Vlissides, J. (1994). *Design Patterns: Elements of Reusable Object-Oriented Software*. Addison-Wesley. | Książka |
| Freeman, E., Robson, E. (2020). *Head First Design Patterns* (2nd ed.). O'Reilly. | Książka |
| Martin, R. C. (2009). *Clean Code*. Prentice Hall. | Książka |
| Seemann, M. (2011). *Dependency Injection in .NET*. Manning. | Książka |
| Fowler, M. (2004). *Inversion of Control Containers and the Dependency Injection pattern*. martinfowler.com | Web |
| [Singleton Pattern - Refactoring.Guru](https://refactoring.guru/design-patterns/singleton) | Web |
| [Fabulous Adventures in Coding — Eric Lippert](https://ericlippert.com/) | Web |
