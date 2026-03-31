IFileSystemNode root = DemoFileSystem.Build();
root.PrintTree();
Console.WriteLine();
Console.WriteLine($"Total size: {root.GetSize()} bytes");

internal interface IFileSystemNode
{
    string Name { get; }
    long GetSize();
    void PrintTree(int level = 0);
}

internal sealed class FileNode(string name, long size) : IFileSystemNode
{
    public string Name { get; } = name;
    private long Size { get; } = size;

    public long GetSize() => Size;

    public void PrintTree(int level = 0)
        => Console.WriteLine($"{new string(' ', level * 2)}- {Name} ({Size} B)");
}

internal sealed class DirectoryNode(string name) : IFileSystemNode
{
    private readonly List<IFileSystemNode> _children = new();

    public string Name { get; } = name;

    public void Add(IFileSystemNode child) => _children.Add(child);

    public long GetSize() => _children.Sum(x => x.GetSize());

    public void PrintTree(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {Name} ({GetSize()} B)");
        foreach (IFileSystemNode child in _children)
        {
            child.PrintTree(level + 1);
        }
    }
}

internal static class DemoFileSystem
{
    public static IFileSystemNode Build()
    {
        var root = new DirectoryNode("root");
        var src = new DirectoryNode("src");
        var tests = new DirectoryNode("tests");
        var assets = new DirectoryNode("assets");

        src.Add(new FileNode("Program.cs", 4300));
        src.Add(new FileNode("Composite.cs", 5200));

        tests.Add(new FileNode("CompositeTests.cs", 2700));

        assets.Add(new FileNode("logo.png", 120000));
        assets.Add(new FileNode("styles.css", 3400));

        root.Add(src);
        root.Add(tests);
        root.Add(assets);
        root.Add(new FileNode("README.md", 1800));

        return root;
    }
}
