using Examples;
using Xunit;

namespace Examples.Tests;

public class LegacyAdapterTests
{
    [Fact]
    public void Adaptee_SpecificRequest_ReturnsLegacyPrefix()
    {
        var adaptee = new Adaptee();

        var result = adaptee.SpecificRequest("test");

        Assert.Equal("legacy::test", result);
    }

    [Fact]
    public void LegacyAdapter_Request_ReplacesPrefixToMapped()
    {
        ITarget target = new LegacyAdapter(new Adaptee());

        var result = target.Request("demo");

        Assert.Equal("mapped::demo", result);
    }

    [Fact]
    public void LegacyAdapter_Request_PreservesPayload()
    {
        ITarget target = new LegacyAdapter(new Adaptee());

        var result = target.Request("important-data");

        Assert.Contains("important-data", result);
    }

    [Fact]
    public void LegacyAdapter_Request_DoesNotContainLegacyPrefix()
    {
        ITarget target = new LegacyAdapter(new Adaptee());

        var result = target.Request("test");

        Assert.DoesNotContain("legacy::", result);
    }

    [Fact]
    public void LegacyAdapter_EmptyPayload_ReturnsMappedPrefix()
    {
        ITarget target = new LegacyAdapter(new Adaptee());

        var result = target.Request("");

        Assert.Equal("mapped::", result);
    }
}
