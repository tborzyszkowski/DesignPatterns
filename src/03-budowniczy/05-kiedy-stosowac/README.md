# 05 – Kiedy stosować Builder

## Cel

Pokazanie, **kiedy Builder jest właściwym wyborem**, a kiedy jest przerostem formy wobec prostszych technik (konstruktor, named arguments, object initializer, Abstract Factory).

---

## Diagram decyzyjny

![Drzewo decyzyjne](diagrams/decision_tree.png)

---

## Kiedy Builder jest uzasadniony

| Sygnał | Dlaczego Builder |
|--------|-----------------|
| Więcej niż ~4 parametry konstruktora | Unika "*telescoping constructor*" |
| Część parametrów jest opcjonalna | Nie trzeba tworzyć N przeciążeń |
| Wymagana kolejność kroków (krok A → B → C) | Step Builder wymusza kolejność |
| Produkt jest niezmienny po zbudowaniu | Builder montuje, `Build()` zamraża |
| Walidacja zależy od kombinacji pól | Logika weryfikacyjna w `Build()` |
| Ten sam algorytm montażu, różne reprezentacje | GoF Builder + Director |

---

## Kiedy Builder to przerost formy

```csharp
// ŹLE — nadmierny builder dla obiektu z 2 polami
new PointBuilder().WithX(3.0).WithY(4.5).Build()

// DOBRZE — konstruktor jest wystarczający
new Point2D(3.0, 4.5)

// DOBRZE — named arguments eliminują pomyłki kolejności
new Color(R: 255, G: 128, B: 0)

// DOBRZE — object initializer bez walidacji
new ApiOptions { BaseUrl = "...", TimeoutSeconds = 60 }
```

### Alternatiwy do rozważenia

| Sytuacja | Zamiast Buildera użyj |
|----------|----------------------|
| ≤ 4 parametry, wszystkie wymagane | Konstruktor + named args |
| Opcjonalne pola, brak walidacji | Object initializer |
| Wiele wariantów produktu z tej samej rodziny | Abstract Factory |
| Produkt niezmienny, C# record | `with` expression |

---

## Przykład uzasadnionego użycia — ReportBuilder

Raport posiada: tytuł, autora, listę sekcji (każda z nagłówkiem, treścią i wykresami), stopkę, format wyjściowy i opcjonalne numery stron. To **klasyczny kandydat** do Buildera:

- 7+ pól,
- sekcje są opcjonalne i powtarzalne,
- walidacja w `Build()` (brak tytułu → wyjątek),
- zagnieżdżony `SectionBuilder` dla płynności bez utraty typów.

### Diagram klas

![ReportBuilder](diagrams/report_builder_class.png)

### Kod — budowanie raportu

```csharp
Report report = new ReportBuilder()
    .WithTitle("Raport Sprzedaży — Styczeń 2024")
    .WithAuthor("Jan Kowalski")
    .AsFormat(ReportFormat.Html)
    .WithPageNumbers()
    .AddSection("Podsumowanie")
        .WithBody("Sprzedaż wzrosła o 12% r/r.")
        .AddChart(ChartType.Bar, "sales.csv", "Sprzedaż wg regionów")
        .EndSection()
    .AddSection("Rekomendacje")
        .WithBody("Zwiększyć budżet marketingowy.")
        .EndSection()
    .WithFooter("Dokument poufny")
    .Build();
```

### Kod — zagnieżdżony SectionBuilder

```csharp
public sealed class SectionBuilder
{
    private readonly ReportBuilder _parent;

    public SectionBuilder WithBody(string body) { _body = body; return this; }
    public SectionBuilder AddChart(ChartType type, string source, string title) { ... return this; }

    // wraca do głównego buildera po zakończeniu sekcji
    public ReportBuilder EndSection()
    {
        _parent.AddBuiltSection(new ReportSection(_heading, _body, _charts));
        return _parent;
    }
}
```

---

## Porównanie technik tworzenia obiektów

| Technika | Czytelność | Niezmienność | Walidacja | Over-engineering? |
|----------|-----------|-------------|-----------|-------------------|
| Konstruktor | ✅ (named args) | ✅ | W konstruktorze | ❌ dla ≤4 pól |
| Object initializer | ✅ (auto) | ❌ (mutable) | Brak | ❌ dla DTO |
| Fluent Builder | ✅✅ | ✅ w Build() | ✅ w Build() | ⚠️ zbędny ≤3 pola |
| Step Builder | ✅✅ (wymusza kolejność) | ✅ | ✅ | ⚠️ zbędny bez kolejności |
| GoF Builder+Director | ✅ | ✅ | ✅ | ⚠️ zbędny bez różnych repr. |
| Abstract Factory | ✅ (rodziny) | ✅ | ❌ | ⚠️ zbędny jeden wariant |
| `with` expression (record) | ✅ | ✅ | ❌ | ❌ dla wartości |

---

## „Code smells" sugerujące Builder

```csharp
// Zapach 1: Telescoping constructor (N przeciążeń)
new Pizza("duża", true, false, false, true, false)

// Zapach 2: Opcjonalne parametry z wartościami domyślnymi
new Pizza("duża", cheese: true, pepperoni: false, bacon: false, ...)

// Zapach 3: Null jako placeholder
new Connection("host", 5432, null, null, null, true)

// Zapach 4: Tworzenie obiektu poprzez właściwości (mutable)
var conn = new Connection();
conn.Host = "host";
conn.Port = 5432;
// Można zapomnieć ustawić wymagane pole!
```

---

## Uruchomienie

```bash
cd 05-kiedy-stosowac/Examples
dotnet run
```

---

## Podsumowanie modułu

| Temat | Sekcja |
|-------|--------|
| Problem z konstruktorami | [01-problem-konstrukcji](../01-problem-konstrukcji/README.md) |
| Struktura GoF | [02-struktura-gof](../02-struktura-gof/README.md) |
| Fluent Builder | [03-fluent-builder](../03-fluent-builder/README.md) |
| Typy implementacji | [04-typy-implementacji](../04-typy-implementacji/README.md) |
| **Kiedy stosować** | **05-kiedy-stosowac** ← jesteś tutaj |
