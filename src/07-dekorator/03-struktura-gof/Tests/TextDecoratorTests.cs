using Examples;
using Xunit;

public class TextDecoratorTests
{
    [Fact]
    public void PlainText_Render_ReturnsOriginalValue()
    {
        IText text = new PlainText("hello");

        Assert.Equal("hello", text.Render());
    }

    [Fact]
    public void BoldDecorator_Render_WrapsInBoldTags()
    {
        IText text = new BoldDecorator(new PlainText("hello"));

        Assert.Equal("<b>hello</b>", text.Render());
    }

    [Fact]
    public void ItalicDecorator_Render_WrapsInItalicTags()
    {
        IText text = new ItalicDecorator(new PlainText("hello"));

        Assert.Equal("<i>hello</i>", text.Render());
    }

    [Fact]
    public void ItalicOverBold_Render_WrapsCorrectly()
    {
        IText text = new ItalicDecorator(new BoldDecorator(new PlainText("text")));

        Assert.Equal("<i><b>text</b></i>", text.Render());
    }

    [Fact]
    public void BoldOverItalic_Render_WrapsCorrectly()
    {
        IText text = new BoldDecorator(new ItalicDecorator(new PlainText("text")));

        Assert.Equal("<b><i>text</i></b>", text.Render());
    }
}
