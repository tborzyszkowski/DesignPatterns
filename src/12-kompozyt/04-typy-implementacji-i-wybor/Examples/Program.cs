Console.WriteLine("=== Transparent Composite ===");
TransparentComponent transparent = new TransparentComposite("root");
transparent.Add(new TransparentLeaf("item-1"));
transparent.Operation();

Console.WriteLine();
Console.WriteLine("=== Safe Composite ===");
var safeRoot = new SafeComposite("root");
safeRoot.Add(new SafeLeaf("item-1"));
safeRoot.Operation();

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
