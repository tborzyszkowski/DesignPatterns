# Wzorzec Object Pool (Pula Obiektów)

> **Kategoria:** Kreacyjny  
> **Rodzina GoF:** wzorzec pokrewny (często opisywany poza klasycznymi 23 wzorcami)

---

## Definicja

**Object Pool** zarządza pulą gotowych do użycia obiektów i pozwala je wielokrotnie wypożyczać oraz zwracać, aby ograniczyć koszt tworzenia i niszczenia instancji.

Najczęściej używamy go dla obiektów:

- kosztownych w inicjalizacji,
- ograniczonych licencyjnie lub infrastrukturalnie,
- pracujących pod dużym obciążeniem współbieżnym.

---

## Spis treści

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Motywacja, geneza, problem biznesowy i techniczny |
| [02](02-kiedy-stosowac/README.md) | Kiedy stosować | Kryteria decyzyjne, sygnały ostrzegawcze, checklista |
| [03](03-struktura-dzialanie/README.md) | Struktura i działanie | Role we wzorcu, diagram klas i sekwencji, przykład bazowy |
| [04](04-implementacje-warianty/README.md) | Implementacje i warianty | `lock+Queue`, `ConcurrentBag`, `DefaultObjectPool<T>` w układzie: opis + diagram + kod |
| [05](05-over-engineering-alternatywy/README.md) | Over-engineering i alternatywy | Kiedy pool szkodzi, czym go zastąpić |
| [06](06-asynchroniczne-workery/README.md) | Asynchroniczni workerzy | Realny scenariusz I/O, limit zasobów, pomiar przepustowości |

---

## Jak uruchomić przykłady

Każdy temat ma niezależny projekt .NET 9:

```bash
cd src/05-object-pool/01-idea-i-kontekst/Examples                  && dotnet run
cd src/05-object-pool/02-kiedy-stosowac/Examples                   && dotnet run
cd src/05-object-pool/03-struktura-dzialanie/StructureSample       && dotnet run
cd src/05-object-pool/04-implementacje-warianty/VariantsSample     && dotnet run
cd src/05-object-pool/05-over-engineering-alternatywy/OverEngineeringSample && dotnet run -c Release
cd src/05-object-pool/06-asynchroniczne-workery/AsyncWorkersSample && dotnet run
```

---

## Najczęstsze problemy przy stosowaniu Object Pool

1. Brak resetu stanu obiektu przy `Return` powoduje wycieki danych między żądaniami.
2. Pool dla tanich obiektów bywa wolniejszy niż zwykłe `new` (narzut synchronizacji).
3. Zbyt duża pula „zamraża" pamięć i utrudnia pracę GC.
4. Brak limitów/czasów oczekiwania może prowadzić do zatorów i timeoutów.
5. Niepoprawne zarządzanie cyklem życia (podwójny zwrot, użycie po zwrocie) prowadzi do trudnych błędów współbieżności.

---

## Zadania dla studentów

Zestaw zadań z rozwiązaniami i omówieniem znajduje się w pliku [ZADANIA.md](ZADANIA.md).

---

## Literatura

| Źródło | Temat |
| --- | --- |
| GoF, *Design Patterns* (1994) | Kontekst wzorców kreacyjnych |
| [Microsoft Docs: ObjectPool in ASP.NET Core](https://learn.microsoft.com/aspnet/core/performance/objectpool) | Produkcyjne użycie `Microsoft.Extensions.ObjectPool` |
| [SourceMaking: Object Pool](https://sourcemaking.com/design_patterns/object_pool) | Intuicja wzorca i porównania |
| [System.Buffers ArrayPool](https://learn.microsoft.com/dotnet/api/system.buffers.arraypool-1) | Alternatywa dla buforów/tablic |
