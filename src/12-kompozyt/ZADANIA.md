# Zadania: Wzorzec Kompozyt

## Zadanie 1 (podstawowe): Drzewo menu

Treść:

Zaimplementuj strukturę menu aplikacji (`MenuGroup`, `MenuItem`) z metodą `Render()`.

Wymagania:

1. Wspólny interfejs `IMenuComponent`.
1. `MenuItem` jako liść.
1. `MenuGroup` jako kompozyt z listą dzieci.
1. Klient wywołuje tylko `Render()` na korzeniu.
1. Menu co najmniej 3-poziomowe (Plik → Nowy → Dokument tekstowy).

Rozwiązanie (skrót):

```csharp
public interface IMenuComponent { void Render(int level = 0); }
public sealed class MenuItem(string title) : IMenuComponent
{
    public void Render(int level = 0) => Console.WriteLine($"{new string(' ', level * 2)}- {title}");
}
public sealed class MenuGroup(string title) : IMenuComponent
{
    private readonly List<IMenuComponent> _children = new();
    public void Add(IMenuComponent child) => _children.Add(child);
    public void Render(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {title}");
        foreach (var c in _children) c.Render(level + 1);
    }
}
```

Wyjaśnienie:

Klient nie rozróżnia, czy renderuje pojedynczy element, czy całą grupę. To jest główny zysk wzorca.

## Zadanie 2 (podstawowe): Koszyk z pakietami

Treść:

Zbuduj koszyk zakupów, w którym klient może dodawać produkty (`Product`) i zestawy (`Bundle`). Zestaw może zawierać produkty i inne zestawy.

Wymagania:

1. Wspólny interfejs `ICartItem` z metodą `decimal GetTotalPrice()` i `string GetName()`.
1. `Product` zwraca własną cenę.
1. `Bundle` sumuje ceny dzieci i może mieć rabat procentowy.
1. Wypisz drzewo koszyka z cenami i sumą końcową.

Przykładowa struktura:

```
Koszyk
├── Laptop (3499 zł)
├── Zestaw "Home Office" (rabat 10%)
│   ├── Monitor (1299 zł)
│   └── Klawiatura (199 zł)
└── Myszka (89 zł)
```

Pytanie kontrolne: ile poziomów może mieć koszyk? Czy kod klienta musiałby się zmieniać przy dodaniu nowego poziomu zagnieżdżenia?

## Zadanie 3 (średnie): Struktura organizacyjna firmy

Treść:

Zamodeluj hierarchię firmy: `Employee` (liść) i `Manager` (kompozyt). Zaimplementuj operacje agregujące na poddrzewach.

Wymagania:

1. Interfejs `IOrganizationUnit` z metodami `decimal GetSalaryBudget()`, `int GetHeadcount()`, `void PrintTree(int level = 0)`.
1. `Employee` zwraca własną pensję i liczy siebie jako 1 osobę.
1. `Manager` jest również pracownikiem (ma pensję) i zarządza podwładnymi.
1. `GetSalaryBudget()` na `CEO` zwraca sumę dla całej firmy.
1. `GetSalaryBudget()` na `CTO` zwraca sumę tylko dla działu technicznego.
1. Zbuduj co najmniej 3-poziomową hierarchię i wypisz drzewo z budżetami.

## Zadanie 4 (średnie): Ochrona przed cyklami

Treść:

Rozszerz `Composite` (dowolny z poprzednich zadań) o walidację uniemożliwiającą dodanie elementu, który tworzyłby cykl.

Wymagania:

1. Metoda `Add()` odrzuca próbę dodania przodka jako dziecka.
1. Odrzuca też próbę dodania samego siebie.
1. Test scenariusza błędnego z oczekiwanym wyjątkiem.

Rozwiązanie (skrót):

1. Podczas `Add(child)` sprawdzaj, czy `child` zawiera bieżący węzeł w swoim poddrzewie.
1. Jeśli tak, rzucaj `InvalidOperationException`.

Wyjaśnienie:

Bez walidacji cykli struktura przestaje być drzewem i może powodować nieskończoną rekurencję.

## Zadanie 5 (zaawansowane): Drzewo wyrażeń matematycznych

Treść:

Zaimplementuj AST dla wyrażeń matematycznych z czterema operatorami (`+`, `-`, `*`, `/`).

Wymagania:

1. Interfejs `IExpression` z metodą `double Evaluate()` i `string ToInfix()`.
1. `NumberExpression` (liść) — zwraca wartość i jej reprezentację.
1. `BinaryExpression` (kompozyt) — dwa operandy (`left`, `right`) i operator.
1. Zbuduj wyrażenie `(3 + 4) * (10 - 1) / 3` z samych węzłów.
1. Wywołaj `Evaluate()` i `ToInfix()` na korzeniu.
1. Dodaj `UnaryExpression` (negacja) — bez zmiany kodu klienta.

Pytanie kontrolne: co musiałbyś zmienić w kodzie klienta, gdybyś chciał dodać nowy typ węzła (np. `FunctionCallExpression`)? Porównaj z podejściem bez Kompozytu.

## Zadanie 6 (zaawansowane): Procedura decyzyjna

Dla każdego z poniższych scenariuszy zastosuj procedurę decyzyjną z rozdziału 02 i udokumentuj wybór.

Scenariusz A:
System zarządzania dokumentami. Dokument może być plikiem lub folderem. Foldery mogą zawierać pliki i inne foldery. Chcesz obliczyć rozmiar, wyświetlić drzewo i wyszukać po nazwie.

Scenariusz B:
Lista pracowników w firmie. Każdy pracownik ma `Id`, `Name`, `Department`, `Salary`. Potrzebujesz wyfiltrować i posortować pracowników wg departamentu.

Scenariusz C:
Widget UI: `ScrollablePanel` owijający dowolny inny widget. `ScrollablePanel` dodaje paski przewijania do wnętrza. Nie zarządza wieloma dziećmi — tylko jednym.

Scenariusz D:
Raportowanie: masz stabilną hierarchię dokumentów (Kompozyt: `Section → Paragraph → TextNode`). Często dodajesz nowe typy raportów (PDF, HTML, Word, Markdown).

Scenariusz E:
Bill of Materials (BOM) w systemie ERP. Produkt końcowy składa się z podzespołów, te z części, a części mogą być proste lub złożone. `GetTotalCost()` musi działać na każdym poziomie.

Dla każdego scenariusza podaj:

1. Jaki wzorzec/podejście wybrałeś (Kompozyt / Dekorator / Visitor / Prosta lista)?
1. Które pytania z checklisty były rozstrzygające?
1. Jeśli Kompozyt: wskaż liść, gałąź i wspólny interfejs.

Klucz odpowiedzi: A=Kompozyt (Leaf:File, Composite:Folder, INode), B=Prosta lista (brak hierarchii, filtr/sort), C=Dekorator (jedno dziecko, nie lista), D=Kompozyt+Visitor (stabilna struktura + nowe operacje), E=Kompozyt (Leaf:Part, Composite:Subassembly, IComponent).

## Pytania kontrolne

1. Co jest liściem (`Leaf`), a co gałęzią (`Composite`) w Twoim modelu z Zadania 3?
1. Jaka jest kluczowa różnica między Dekoratorem a Kompozytem? (podaj przykład każdego)
1. Kiedy warto łączyć Kompozyt z Visitorem? Podaj przykład scenariusza.
1. Co się stanie, jeśli do interfejsu `Component` dodasz metodę specyficzną tylko dla gałęzi (np. `Add`)? Jak liść powinien ją obsługiwać?
1. Jakie są konsekwencje wydajnościowe czystej rekurencji na bardzo głębokim drzewie (10 000 poziomów)?
1. Czym różni się Transparent Composite od Safe Composite? Kiedy każdy jest lepszy?
1. Jak obsłużyć sytuację, gdy Visitor musi przetworzyć Composite, ale nie zna wszystkich typów węzłów z góry?
1. Kiedy Kompozyt NIE da żadnego zysku mimo drzewiastej struktury?
