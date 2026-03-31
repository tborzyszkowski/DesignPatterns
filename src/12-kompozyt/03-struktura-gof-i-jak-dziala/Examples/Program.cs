Component root = new Composite("root");
Component branchA = new Composite("branch-A");
Component branchB = new Composite("branch-B");

branchA.Add(new Leaf("leaf-A1"));
branchA.Add(new Leaf("leaf-A2"));
branchB.Add(new Leaf("leaf-B1"));

root.Add(branchA);
root.Add(branchB);

root.Operation();

internal abstract class Component
{
    public abstract void Operation(int level = 0);
    public virtual void Add(Component component) => throw new NotSupportedException();
    public virtual void Remove(Component component) => throw new NotSupportedException();
}

internal sealed class Leaf(string name) : Component
{
    public override void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}- {name}");
    }
}

internal sealed class Composite(string name) : Component
{
    private readonly List<Component> _children = new();

    public override void Add(Component component) => _children.Add(component);
    public override void Remove(Component component) => _children.Remove(component);

    public override void Operation(int level = 0)
    {
        Console.WriteLine($"{new string(' ', level * 2)}+ {name}");
        foreach (Component child in _children)
        {
            child.Operation(level + 1);
        }
    }
}
