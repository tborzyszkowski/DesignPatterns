INode root = DemoTree.Build();
root.Print();

internal interface INode
{
    void Print(int level = 0);
}

internal sealed class FileNode(string name) : INode
{
    public void Print(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}- {name}");
    }
}

internal sealed class FolderNode(string name) : INode
{
    private readonly List<INode> _children = new();

    public void Add(INode child) => _children.Add(child);

    public void Print(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {name}");
        foreach (INode child in _children)
        {
            child.Print(level + 1);
        }
    }
}

internal static class DemoTree
{
    public static INode Build()
    {
        var root = new FolderNode("root");
        var src = new FolderNode("src");
        var docs = new FolderNode("docs");

        src.Add(new FileNode("Program.cs"));
        src.Add(new FileNode("Composite.cs"));
        docs.Add(new FileNode("README.md"));

        root.Add(src);
        root.Add(docs);
        root.Add(new FileNode(".gitignore"));

        return root;
    }
}
