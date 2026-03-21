# 05. Over-engineering i alternatywy

## Kluczowa teza

W .NET Object Pool nie jest „domyślną optymalizacją". Dla wielu małych i tanich obiektów pool pogarsza wydajność.

---

## Kiedy pool szkodzi

1. Obiekt jest mały i tani w utworzeniu.
2. Koszt resetu i synchronizacji jest wyższy niż koszt `new`.
3. Ruch jest niski, więc pula prawie nie reuse'uje instancji.
4. Pula utrzymuje niepotrzebnie dużą liczbę obiektów i zwiększa zużycie pamięci.

---

## Diagramy

### Kiedy nie stosować

![Kiedy nie stosować](diagrams/01-when-not-to-use.png)

Źródło: [diagrams/01-when-not-to-use.puml](diagrams/01-when-not-to-use.puml)

### Alternatywy

![Alternatywy](diagrams/02-alternatives.png)

Źródło: [diagrams/02-alternatives.puml](diagrams/02-alternatives.puml)

---

## Alternatywy techniczne

- zwykłe `new` i zaufanie GC,
- `ArrayPool<T>` dla dużych buforów,
- Flyweight dla współdzielenia niezmiennych danych,
- Factory + poprawny lifetime w DI.

---

## Przykład C# (kontrprzykład)

Kod: [OverEngineeringSample/Program.cs](OverEngineeringSample/Program.cs)

Przykład porównuje dwa scenariusze:

- tworzenie lekkich obiektów przez `new`,
- tworzenie lekkich obiektów przez pool.

Uruchom:

```bash
cd src/05-object-pool/05-over-engineering-alternatywy/OverEngineeringSample
dotnet run -c Release
```

---

## Wniosek dydaktyczny

Najpierw mierz, potem optymalizuj. Object Pool ma sens tylko tam, gdzie realnie redukuje koszt.
