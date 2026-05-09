# 05. Duży przykład: system plików

## Cel rozdziału

Przećwiczyć wzorzec Kompozyt na większym, realistycznym przykładzie i zrozumieć konsekwencje projektowe.

## Kontekst

Modelujemy fragment drzewa katalogów projektu. Cel: obliczenie całkowitego rozmiaru drzewa i wydrukowanie go w strukturze z wcięciami — **bez żadnej instrukcji `if` po stronie klienta** rozróżniającej plik od katalogu.

Dwa rodzaje węzłów:

| Typ | Rola w Kompozycie | Co przechowuje | Jak liczy rozmiar |
|---|---|---|---|
| `FileNode` | Liść | `name`, `size` (stała) | zwraca własny rozmiar |
| `DirectoryNode` | Kompozyt | `name`, lista `_children` | sumuje `GetSize()` dzieci |

Oba implementują ten sam interfejs `IFileSystemNode` — klient nie musi wiedzieć, z czym ma do czynienia.

## Struktura budowanego drzewa

```
+ root  (137 400 B)
  + src  (9 500 B)
    - Program.cs   (4 300 B)
    - Composite.cs (5 200 B)
  + tests  (2 700 B)
    - CompositeTests.cs (2 700 B)
  + assets  (123 400 B)
    - logo.png    (120 000 B)
    - styles.css    (3 400 B)
  - README.md (1 800 B)
```

Rozmiar katalogu `root` to suma rozmiarów wszystkich jego dzieci, katalogów i plików, na wszystkich poziomach zagnieżdżenia.

## Interfejs — `IFileSystemNode`

```csharp
internal interface IFileSystemNode
{
    string Name    { get; }
    long   GetSize();
    void   PrintTree(int level = 0);
}
```

`GetSize()` i `PrintTree()` są jedynymi operacjami klienta. Klient operuje zawsze na `IFileSystemNode` — nigdy na `FileNode` ani `DirectoryNode` wprost.

## Liść — `FileNode`

```csharp
internal sealed class FileNode(string name, long size) : IFileSystemNode
{
    public string Name { get; } = name;
    private long Size  { get; } = size;   // przechowuje rozmiar w bajtach

    public long GetSize() => Size;        // zwraca rozmiar bez żadnych obliczeń

    public void PrintTree(int level = 0)
        => Console.WriteLine($"{new string(' ', level * 2)}- {Name} ({Size} B)");
}
```

Liść nie wie nic o drzewie ani o innych węzłach. `GetSize()` to jedno wyrażenie — zwrócenie wartości podanej w konstruktorze.

## Kompozyt — `DirectoryNode`

```csharp
internal sealed class DirectoryNode(string name) : IFileSystemNode
{
    private readonly List<IFileSystemNode> _children = new();
    public string Name { get; } = name;

    public void Add(IFileSystemNode child) => _children.Add(child);

    // Rekurencja: każde dziecko samo wie, jak obliczyć swój rozmiar
    public long GetSize() => _children.Sum(x => x.GetSize());

    public void PrintTree(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {Name} ({GetSize()} B)");
        foreach (IFileSystemNode child in _children)
            child.PrintTree(level + 1);   // każde dziecko wypisuje się samo
    }
}
```

`GetSize()` to `_children.Sum(x => x.GetSize())` — każde dziecko dostaje to samo pytanie i samo na nie odpowiada. Katalog nie sprawdza, czy dziecko jest plikiem czy innym katalogiem. To właśnie jest siłą Kompozytu: **operacja jest jednorodna na całym drzewie**.

### Jak przebiega obliczanie rozmiaru `root`

```
root.GetSize()
  → src.GetSize()
      → Program.cs.GetSize()   = 4 300
      → Composite.cs.GetSize() = 5 200
      = 9 500
  → tests.GetSize()
      → CompositeTests.cs.GetSize() = 2 700
      = 2 700
  → assets.GetSize()
      → logo.png.GetSize()    = 120 000
      → styles.css.GetSize()  =   3 400
      = 123 400
  → README.md.GetSize()       =   1 800
  = 137 400
```

Każdy węzeł drzewa odpowiada tylko za siebie i swoje bezpośrednie dzieci. Głębokość zagnieżdżenia nie wymaga żadnej zmiany w kodzie.

## Budowanie drzewa — `DemoFileSystem.Build()`

```csharp
internal static class DemoFileSystem
{
    public static IFileSystemNode Build()
    {
        var root   = new DirectoryNode("root");
        var src    = new DirectoryNode("src");
        var tests  = new DirectoryNode("tests");
        var assets = new DirectoryNode("assets");

        src.Add(new FileNode("Program.cs",   4300));
        src.Add(new FileNode("Composite.cs", 5200));

        tests.Add(new FileNode("CompositeTests.cs", 2700));

        assets.Add(new FileNode("logo.png",   120000));
        assets.Add(new FileNode("styles.css",   3400));

        root.Add(src);
        root.Add(tests);
        root.Add(assets);
        root.Add(new FileNode("README.md", 1800));

        return root;   // typ zwrotny: IFileSystemNode, nie DirectoryNode
    }
}
```

`Build()` zwraca `IFileSystemNode` — dzięki temu kod wywołujący nie zależy od konkretnego typu korzenia. Gdybyśmy zmienili korzeń na plik (mało praktyczne, ale możliwe), klient nie wymagałby żadnej zmiany.

## Kod klienta

```csharp
IFileSystemNode root = DemoFileSystem.Build();
root.PrintTree();                              // wypisuje całe drzewo z wcięciami
Console.WriteLine($"Total: {root.GetSize()} bytes");
```

Dwie linijki. Brak `if (root is DirectoryNode)`. Brak rzutowań. Brak wiedzy o tym, ile poziomów zagnieżdżenia ma drzewo.

## Oczekiwane wyjście programu

```
+ root (137400 B)
  + src (9500 B)
    - Program.cs (4300 B)
    - Composite.cs (5200 B)
  + tests (2700 B)
    - CompositeTests.cs (2700 B)
  + assets (123400 B)
    - logo.png (120000 B)
    - styles.css (3400 B)
  - README.md (1800 B)

Total size: 137400 bytes
```

`+` oznacza katalog (kompozyt), `-` oznacza plik (liść). Wcięcie odpowiada głębokości w drzewie (2 spacje na poziom).

## Diagram klas

![Diagram klas](diagrams/composite_filesystem_class.png)

Źródło: [diagrams/01-class-filesystem.puml](diagrams/01-class-filesystem.puml)

## Diagram sekwencji

![Diagram sekwencji](diagrams/composite_filesystem_sequence.png)

Źródło: [diagrams/02-sequence-filesystem.puml](diagrams/02-sequence-filesystem.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

```bash
cd src/12-kompozyt/05-duży-przykład-system-plikow/Examples
dotnet run
```

## Kiedy zastosować ten wzorzec tutaj

| Sygnał | Wyjaśnienie |
|---|---|
| Struktura jest drzewiasta i zagnieżdżona | Katalogi zawierają katalogi i pliki — klasyczne drzewo |
| Operacje agregujące na poddrzewach | `GetSize()` na katalogu = suma poddrzewa |
| Wspólne API niezależnie od poziomu | Klient wołający `GetSize()` na pliku i katalogu pisze identyczny kod |
| Brak instrukcji warunkowych w kliencie | Nie ma `if (node is FileNode)` ani `if (node is DirectoryNode)` |

## Źródła

1. Refactoring.Guru Composite: https://refactoring.guru/design-patterns/composite
1. Composite in C#: https://refactoring.guru/design-patterns/composite/csharp/example
