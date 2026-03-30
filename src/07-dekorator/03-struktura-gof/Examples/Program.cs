namespace Examples;

public interface IText
{
    string Render();
}

public sealed class PlainText(string value) : IText
{
    public string Render() => value;
}

public abstract class TextDecorator(IText inner) : IText
{
    protected IText Inner { get; } = inner;
    public abstract string Render();
}

public sealed class BoldDecorator(IText inner) : TextDecorator(inner)
{
    public override string Render() => $"<b>{Inner.Render()}</b>";
}

public sealed class ItalicDecorator(IText inner) : TextDecorator(inner)
{
    public override string Render() => $"<i>{Inner.Render()}</i>";
}

public static class Program
{
    public static void Main()
    {
        IText text = new ItalicDecorator(
            new BoldDecorator(
                new PlainText("Decorator GoF structure")));

        Console.WriteLine(text.Render());
    }
}
