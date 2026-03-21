# 02. Kiedy stosować Object Pool

## Cel rozdziału

Po tym rozdziale student powinien:
- umieć podjąć decyzję, czy Object Pool ma sens,
- rozpoznać sygnały, że pula jest over-engineeringiem,
- znać metryki, które warto mierzyć przed wdrożeniem.

---

## Kryteria decyzyjne

Stosuj Object Pool, gdy spełnione są co najmniej 2-3 warunki:
- koszt stworzenia obiektu jest wysoki (np. > 1 ms lub koszt I/O),
- istnieje limit zasobów (licencje, API, liczba połączeń),
- obciążenie jest wysokie i współbieżne,
- obiekt da się bezpiecznie zresetować i ponownie użyć.

Nie stosuj, gdy:
- obiekt jest mały i tani,
- żyje bardzo krótko,
- koszt synchronizacji jest większy niż koszt `new`.

---

## Diagramy decyzyjne

### Drzewo decyzji

![Drzewo decyzji](diagrams/01-decision-tree.png)

Źródło: [diagrams/01-decision-tree.puml](diagrams/01-decision-tree.puml)

### Sygnały „pomaga" vs „szkodzi"

![Sygnały użycia](diagrams/02-signals.png)

Źródło: [diagrams/02-signals.puml](diagrams/02-signals.puml)

---

## Co mierzyć przed wdrożeniem

1. Średni i P95/P99 czas tworzenia obiektu.
2. Liczbę alokacji na żądanie.
3. Narzut GC (`Gen0`, `Gen1`, `Gen2`).
4. Przepustowość i czas odpowiedzi pod obciążeniem.
5. Czas oczekiwania na wolny obiekt w puli.

---

## Przykład C#

Kod demonstracyjny: [Examples/Program.cs](Examples/Program.cs)

Przykład uruchamia dwa warianty:
- bez puli (`new`),
- z pulą (`SemaphoreSlim` + kolejka).

Uruchom:

```bash
cd src/05-object-pool/02-kiedy-stosowac/Examples
dotnet run -c Release
```

---

## Zadanie dla studentów

Zadanie: Zwiększ liczbę operacji i porównaj, przy jakim czasie inicjalizacji obiektu pool zaczyna dawać zysk.

Wskazówka: zmieniaj parametr `simulatedInitMs` w kodzie i zapisuj wyniki w tabeli.