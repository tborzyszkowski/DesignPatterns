using PlytkieGleboke.Documents;
using Xunit;

namespace Examples.Tests;

public class PersonTests
{
    [Fact]
    public void CopyConstructor_CopiesValues()
    {
        var original = new Person("Jan", "jan@firma.pl");

        var copy = new Person(original);

        Assert.Equal("Jan", copy.Name);
        Assert.Equal("jan@firma.pl", copy.Email);
    }

    [Fact]
    public void CopyConstructor_IsIndependent()
    {
        var original = new Person("Jan", "jan@firma.pl");

        var copy = new Person(original);
        copy.Name = "Anna";

        Assert.Equal("Jan", original.Name);
    }
}

public class DocumentShallowCloneTests
{
    private static Document CreateTestDocument() => new(
        "Umowa",
        new Person("Jan", "jan@firma.pl"),
        ["prawny", "2024"],
        ["Paragraf 1", "Paragraf 2"]);

    [Fact]
    public void ShallowClone_CopiesTitle()
    {
        var original = CreateTestDocument();

        var clone = original.ShallowClone();

        Assert.Equal("Umowa", clone.Title);
    }

    [Fact]
    public void ShallowClone_SharesAuthorReference()
    {
        var original = CreateTestDocument();

        var clone = original.ShallowClone();

        Assert.True(ReferenceEquals(original.Author, clone.Author));
    }

    [Fact]
    public void ShallowClone_SharesTagsReference()
    {
        var original = CreateTestDocument();

        var clone = original.ShallowClone();

        Assert.True(ReferenceEquals(original.Tags, clone.Tags));
    }
}

public class DocumentDeepCloneManualTests
{
    private static Document CreateTestDocument() => new(
        "Umowa",
        new Person("Jan", "jan@firma.pl"),
        ["prawny", "2024"],
        ["Paragraf 1", "Paragraf 2"]);

    [Fact]
    public void DeepCloneManual_CopiesAllValues()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneManual();

        Assert.Equal(original.Title, clone.Title);
        Assert.Equal(original.Author.Name, clone.Author.Name);
        Assert.Equal(original.Tags, clone.Tags);
        Assert.Equal(original.Paragraphs, clone.Paragraphs);
    }

    [Fact]
    public void DeepCloneManual_AuthorIsIndependent()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneManual();
        clone.Author.Name = "Anna";

        Assert.Equal("Jan", original.Author.Name);
    }

    [Fact]
    public void DeepCloneManual_TagsAreIndependent()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneManual();
        clone.Tags.Add("pilne");

        Assert.Equal(2, original.Tags.Count);
    }

    [Fact]
    public void DeepCloneManual_ParagraphsAreIndependent()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneManual();
        clone.Paragraphs.Clear();

        Assert.Equal(2, original.Paragraphs.Count);
    }
}

public class DocumentDeepCloneJsonTests
{
    private static Document CreateTestDocument() => new(
        "Umowa",
        new Person("Jan", "jan@firma.pl"),
        ["prawny", "2024"],
        ["Paragraf 1", "Paragraf 2"]);

    [Fact]
    public void DeepCloneJson_CopiesAllValues()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneJson();

        Assert.Equal(original.Title, clone.Title);
        Assert.Equal(original.Author.Name, clone.Author.Name);
        Assert.Equal(original.Tags, clone.Tags);
    }

    [Fact]
    public void DeepCloneJson_AuthorIsIndependent()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneJson();
        clone.Author.Email = "other@mail.pl";

        Assert.Equal("jan@firma.pl", original.Author.Email);
    }

    [Fact]
    public void DeepCloneJson_TagsAreIndependent()
    {
        var original = CreateTestDocument();

        var clone = original.DeepCloneJson();
        clone.Tags.Clear();

        Assert.Equal(2, original.Tags.Count);
    }
}
