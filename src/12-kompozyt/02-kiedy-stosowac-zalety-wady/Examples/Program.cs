Console.WriteLine("=== Wariant 1: Kompozyt (menu wielopoziomowe) ===");
IMenuComponent root = BuildCompositeMenu();
root.Render();

Console.WriteLine();
Console.WriteLine("=== Wariant 2: Płaska lista komend ===");
var flat = new List<string> { "Nowy", "Otwórz", "Zapisz", "Eksportuj PDF" };
foreach (string item in flat)
{
    Console.WriteLine($"- {item}");
}

static IMenuComponent BuildCompositeMenu()
{
    var file = new MenuGroup("Plik");
    file.Add(new MenuItem("Nowy"));
    file.Add(new MenuItem("Otwórz"));

    var export = new MenuGroup("Eksport");
    export.Add(new MenuItem("PDF"));
    export.Add(new MenuItem("HTML"));

    file.Add(export);

    var root = new MenuGroup("Menu główne");
    root.Add(file);
    root.Add(new MenuItem("Pomoc"));
    return root;
}

internal interface IMenuComponent
{
    void Render(int level = 0);
}

internal sealed class MenuItem(string title) : IMenuComponent
{
    public void Render(int level = 0)
        => Console.WriteLine($"{new string(' ', level * 2)}- {title}");
}

internal sealed class MenuGroup(string title) : IMenuComponent
{
    private readonly List<IMenuComponent> _children = new();

    public void Add(IMenuComponent child) => _children.Add(child);

    public void Render(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {title}");
        foreach (IMenuComponent child in _children)
        {
            child.Render(level + 1);
        }
    }
}
