# 06. Alternatywy i kiedy nie wybierać Kompozytu

## Cel rozdziału

Świadomie odróżniać przypadki, w których Kompozyt jest najlepszy, od tych, gdzie lepiej wybrać inne podejście.

## Kiedy nie wybierać Kompozytu

1. **Brak hierarchii drzewiastej** — dane są płaskie (lista zamówień, tabela produktów). Kompozyt dodałby złożoność bez żadnego zysku.
1. **Stały, mały zestaw poziomów** — np. zawsze dokładnie: `Koszyk → Produkt`. Prosta klasa `Order` z `List<OrderItem>` jest czytelniejsza.
1. **Brak wspólnego sensownego interfejsu** — liść i gałąź nie mają żadnej wspólnej operacji. Wymuszanie wspólnego interfejsu prowadzi do "pustych" lub rzucających wyjątek metod.
1. **Tylko jedna operacja na strukturze** — jeśli jedyną operacją jest wyświetlenie, zwykła klasa z `ToString()` jest wystarczająca.
1. **Koszty utrzymania hierarchii > zysk** — przy małej skali (10–20 węzłów) narzut architektoniczny nie jest wart zysku.

## Alternatywy — kiedy i dlaczego

### Prosta kolekcja + serwis domenowy

Gdy masz zawsze stałą głębokość (1–2 poziomy) i różne API dla liścia i rodzica.

```csharp
// Zamiast Composite dla dwóch poziomów:
public class Order
{
    public IReadOnlyList<OrderItem> Items { get; }
    public decimal GetTotalPrice() => Items.Sum(i => i.Price * i.Quantity);
}
```

Scenariusz: lista zamówień w e-sklepie. Każde zamówienie zawiera pozycje — zawsze 2 poziomy, brak rekurencji, brak potrżeby jednolitego API.

### Dekorator

Gdy chcesz rozszerzać zachowanie **jednego** obiektu w locie, nie zarządzać kolekcją dzieci.

```csharp
// Composite zarządza dziećmi — Dekorator owija jeden obiekt:
IStream stream = new CompressionStream(new EncryptionStream(new FileStream("data.bin")));
```

Scenariusz: przetwarzanie strumienia danych z kompresją i szyfrowaniem. Dekorator dodaje warstwę zachowania; nie tworzy drzewa z kolekcją węzłów. Kluczowa różnica: Dekorator ma **jedno dziecko**, Composite ma **listę dzieci**.

### Visitor

Gdy struktura drzewa jest ustalona, ale często dodajesz nowe operacje na węzłach.

```csharp
// Zamiast dodawania metod do klas struktury:
root.Accept(new XmlExportVisitor());
root.Accept(new PdfExportVisitor());
root.Accept(new StatisticsVisitor());
```

Scenariusz: kompilator z AST. Struktura węzłów (IfNode, LoopNode, AssignNode) zmienia się rzadko, ale ciągle dochodzą nowe analizy (linter, optymalizator, generator kodu). Visitor pozwala dodawać nowe operacje bez modyfikacji klas węzłów.

Zasada: **Composite + Visitor** często idą razem — Composite zarządza strukturą, Visitor dodaje nowe operacje.

### Strategia + drzewo danych

Gdy zmieniasz algorytm przetwarzania drzewa, nie samą strukturę.

```csharp
// Drzewo jako czyste dane, algorytm wymienny:
ITreeTraversal strategy = new DepthFirstTraversal();
var result = strategy.Traverse(root);
```

Scenariusz: wyszukiwarka w drzewie dokumentów z wymiennymi strategiami (BFS dla szerokiego przeszukiwania, DFS dla głębokiego). Struktura drzewa to proste dane, strategia decyduje o sposobie przetwarzania.

## Tabela porównawcza

| Wzorzec | Struktura | Cel | Kluczowa różnica od Composite |
|---|---|---|---|
| **Composite** | Drzewo: Leaf + Composite | Jednolite API dla hierarchii | — (to jest nasz wzorzec) |
| **Dekorator** | Łańcuch owinieci | Rozszerza jedno dziecko | Jedno dziecko, nie lista |
| **Visitor** | Drzewo Composite + zewnętrzny obiekt | Nowe operacje bez zmiany klas | Operacja zewnętrzna, nie w węźle |
| **Strategia** | Drzewo jako dane + algorytm | Wymienny algorytm przetwarzania | Algorytm oddzielony od drzewa |
| **Prosta lista** | `List<T>` | Płaskie kolekcję, stała głębokość | Brak rekurencji i wspólnego interfejsu |

## Diagram porównawczy

![Porównanie wzorców](diagrams/composite_alternatives.png)

Źródło: [diagrams/01-alternatives.puml](diagrams/01-alternatives.puml)

## Diagram decyzji

![Decyzja: Composite czy nie](diagrams/composite_or_not.png)

Źródło: [diagrams/02-decision.puml](diagrams/02-decision.puml)

## Przykład C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje sytuację, gdzie prostsza lista z agregacją jest wystarczająca i Kompozyt byłby nadmiarowy.

```bash
cd src/12-kompozyt/06-alternatywy-i-kiedy-nie/Examples
dotnet run
```

## Literatura

1. Refactoring.Guru Composite: https://refactoring.guru/design-patterns/composite
1. Refactoring.Guru Visitor: https://refactoring.guru/design-patterns/visitor
1. Refactoring.Guru Decorator: https://refactoring.guru/design-patterns/decorator
