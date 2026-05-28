# Materiały wykładowe — Wzorzec Odwiedzający (Visitor)

## Skrót dla wykładowcy

| Czas | Treść |
|------|-------|
| 10 min | Problem: jak dodawać operacje bez modyfikacji klas |
| 10 min | Double dispatch — mechanizm kluczowy |
| 15 min | Struktura GoF — diagram klas i sekwencji |
| 10 min | Cztery typy implementacji w C# |
| 10 min | Wady i alternatywy |
| 15 min | Przykład: drzewo AST z odwiedzającymi |

---

## Kluczowe pojęcia

- **Double dispatch** — wywołanie metody zależy zarówno od typu odbiorcy (`Accept`), jak i od typu argumentu (konkretny `Visit`)
- **Element** — obiekt struktury posiadający metodę `Accept(IVisitor)`
- **Odwiedzający (Visitor)** — obiekt wykonujący operację na konkretnych typach elementów
- **Struktura obiektów** — kolekcja, drzewo lub graf elementów akceptujących odwiedzających
- **Open/Closed Principle** — hierarchia elementów jest zamknięta, ale nowe odwiedzające dodajemy bez modyfikacji elementów

---

## Pliki diagramów

| Plik | PNG | Opis |
|------|-----|------|
| `01-idea-i-kontekst/diagrams/01-problem.puml` | `visitor_problem.png` | Klasy przed i po zastosowaniu wzorca |
| `01-idea-i-kontekst/diagrams/02-concept.puml` | `visitor_concept.png` | Mechanizm double dispatch |
| `01-idea-i-kontekst/diagrams/03-history.puml` | `visitor_history.png` | Oś czasu wzorca |
| `02-kiedy-stosowac-zalety-wady/diagrams/01-decision-tree.puml` | `visitor_decision.png` | Drzewo decyzyjne kiedy stosować |
| `02-kiedy-stosowac-zalety-wady/diagrams/02-variants.puml` | `visitor_variants.png` | Cztery odmiany wzorca |
| `03-struktura-gof/diagrams/01-class-diagram.puml` | `visitor_class.png` | Pełny diagram klas GoF |
| `03-struktura-gof/diagrams/02-sequence.puml` | `visitor_sequence.png` | Diagram sekwencji double dispatch |
| `03-struktura-gof/diagrams/03-double-dispatch.puml` | `visitor_dispatch.png` | Wyjaśnienie mechanizmu |
| `04-typy-implementacji/diagrams/01-impl-types.puml` | `visitor_impl_types.png` | Cztery typy implementacji |
| `04-typy-implementacji/diagrams/02-choice.puml` | `visitor_impl_choice.png` | Schemat wyboru implementacji |
| `05-wady-zalety-alternatywy/diagrams/01-alternatives.puml` | `visitor_alternatives.png` | Porównanie alternatyw |
| `05-wady-zalety-alternatywy/diagrams/02-decision-matrix.puml` | `visitor_decision_matrix.png` | Macierz decyzyjna |
| `06-wiekszy-przyklad/diagrams/01-ast-class.puml` | `visitor_ast_class.png` | Diagram klas AST |
| `06-wiekszy-przyklad/diagrams/02-ast-sequence.puml` | `visitor_ast_sequence.png` | Sekwencja ewaluacji AST |

---

## Kluczowe fragmenty kodu do omówienia na wykładzie

### 1. Problem — klasa bez wzorca

```csharp
class Circle
{
    // Wszystkie operacje wpychamy do klasy!
    public double CalculateArea() { ... }
    public double CalculatePerimeter() { ... }
    public string ExportToSvg() { ... }
    public string ExportToJson() { ... }
    public void Draw(IGraphicsContext ctx) { ... }
}
```

### 2. Rozwiązanie — podwójne przekazanie (double dispatch)

```csharp
// Krok 1: wywołanie Accept wybiera metodę na podstawie typu elementu
shapes.ForEach(s => s.Accept(areaVisitor));

// Krok 2 (wewnątrz Circle.Accept):
public void Accept(IShapeVisitor v) => v.Visit(this);  // "this" = Circle

// Krok 3 (wewnątrz AreaVisitor.Visit(Circle)):
public void Visit(Circle c) => Total += Math.PI * c.Radius * c.Radius;
```

### 3. Nowa operacja BEZ modyfikacji hierarchii

```csharp
class SvgExportVisitor : IShapeVisitor
{
    public void Visit(Circle c)    => Svg += $"<circle r=\"{c.Radius}\"/>";
    public void Visit(Rectangle r) => Svg += $"<rect w=\"{r.Width}\" h=\"{r.Height}\"/>";
    public void Visit(Triangle t)  => Svg += $"<polygon .../>";
}
// Żadna klasa Shape nie została zmodyfikowana!
```

---

## Pytania do dyskusji

1. Dlaczego zwykłe polimorfizm (virtual) nie wystarczy do rozwiązania tego problemu?
2. Co stanie się z odwiedzającymi, gdy dodamy nowy typ `Ellipse` do hierarchii figur?
3. Kiedy lepiej wybrać C# `switch` z pattern matching zamiast klasycznego GoF?
4. Jakie jest ryzyko "God Visitor" — odwiedzającego z setkami metod?
