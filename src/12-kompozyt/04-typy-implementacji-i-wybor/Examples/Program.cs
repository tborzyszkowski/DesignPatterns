Console.WriteLine("=== Transparent Composite ===");
TransparentComponent transparent = new TransparentComposite("root");
transparent.Add(new TransparentLeaf("item-1"));
transparent.Operation();

Console.WriteLine();
Console.WriteLine("=== Safe Composite ===");
var safeRoot = new SafeComposite("root");
safeRoot.Add(new SafeLeaf("item-1"));
safeRoot.Operation();

Console.WriteLine();
Console.WriteLine("=== Composite + Iterator (BFS) ===");
var iterRoot = new IterNode("root");
var iterBranch = new IterNode("branch-A");
iterBranch.Add(new IterNode("leaf-A1"));
iterBranch.Add(new IterNode("leaf-A2"));
iterRoot.Add(iterBranch);
iterRoot.Add(new IterNode("leaf-B"));

foreach (IterNode node in BfsIterator.Traverse(iterRoot))
{
    Console.WriteLine($"  {node.Name}");
}

internal abstract class TransparentComponent(string name)
{
    protected string Name { get; } = name;
    public abstract void Operation(int level = 0);
    public virtual void Add(TransparentComponent child) => throw new NotSupportedException("Leaf cannot Add");
}

internal sealed class TransparentLeaf(string name) : TransparentComponent(name)
{
    public override void Operation(int level = 0) => Console.WriteLine($"{new string(' ', level * 2)}- {Name}");
}

internal sealed class TransparentComposite(string name) : TransparentComponent(name)
{
    private readonly List<TransparentComponent> _children = new();
    public override void Add(TransparentComponent child) => _children.Add(child);

    public override void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {Name}");
        foreach (var child in _children)
        {
            child.Operation(level + 1);
        }
    }
}

internal interface ISafeComponent
{
    void Operation(int level = 0);
}

internal sealed class SafeLeaf(string name) : ISafeComponent
{
    public void Operation(int level = 0) => Console.WriteLine($"{new string(' ', level * 2)}- {name}");
}

internal sealed class SafeComposite(string name) : ISafeComponent
{
    private readonly List<ISafeComponent> _children = new();

    public void Add(ISafeComponent child) => _children.Add(child);

    public void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {name}");
        foreach (var child in _children)
        {
            child.Operation(level + 1);
        }
    }
}

internal sealed class IterNode(string name)
{
    private readonly List<IterNode> _children = new();
    public string Name { get; } = name;
    public IEnumerable<IterNode> Children => _children;
    public void Add(IterNode child) => _children.Add(child);
}

internal static class BfsIterator
{
    public static IEnumerable<IterNode> Traverse(IterNode root)
    {
        var queue = new Queue<IterNode>();
        queue.Enqueue(root);
        while (queue.Count > 0)
        {
            IterNode node = queue.Dequeue();
            yield return node;
            foreach (IterNode child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    }
}
