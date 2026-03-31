# Zadania: Wzorzec Kompozyt

## Zadanie 1 (podstawowe): Drzewo menu

Treść:

Zaimplementuj strukturę menu aplikacji (`MenuGroup`, `MenuItem`) z metodą `Render()`.

Wymagania:

1. Wspólny interfejs `IMenuComponent`.
1. `MenuItem` jako liść.
1. `MenuGroup` jako kompozyt z listą dzieci.
1. Klient wywołuje tylko `Render()` na korzeniu.

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

## Zadanie 2 (średnie): Liczenie kosztu poddrzewa

Treść:

W strukturze sklepu (`Product`, `Category`) dodaj metodę `GetTotalPrice()` dla całego poddrzewa.

Wymagania:

1. `Product` zwraca własną cenę.
1. `Category` sumuje ceny dzieci.
1. Pokazanie wyniku dla wielopoziomowej struktury.

Rozwiązanie (idea):

1. Liść zwraca wartość lokalną.
1. Kompozyt agreguje wyniki dzieci przez sumowanie.
1. Rekurencja pozwala obsłużyć dowolną głębokość.

## Zadanie 3 (zaawansowane): Ochrona przed cyklami

Treść:

Rozszerz `Composite` o walidację uniemożliwiającą dodanie elementu, który tworzyłby cykl.

Wymagania:

1. Metoda `Add()` odrzuca próbę dodania przodka jako dziecka.
1. Test scenariusza błędnego.

Rozwiązanie (skrót):

1. Podczas `Add(child)` sprawdzaj, czy `child` zawiera bieżący węzeł w swoim poddrzewie.
1. Jeśli tak, rzucaj `InvalidOperationException`.

Wyjaśnienie:

Bez walidacji cykli struktura przestaje być drzewem i może powodować nieskończoną rekurencję.

## Zadanie 4 (bonus): Visitor na Composite

Treść:

Dodaj wizytatora raportującego liczbę liści i kompozytów w drzewie.

Wskazówka:

1. To dobre ćwiczenie pokazujące połączenie Composite + Visitor.
