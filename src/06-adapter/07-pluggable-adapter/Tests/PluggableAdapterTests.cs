using Examples;
using Xunit;

namespace Examples.Tests;

public class PluggableAdapterTests
{
    [Fact]
    public void JsonAdapter_Adapt_ReturnsJsonAdaptedPrefix()
    {
        IMessageAdapter adapter = new JsonAdapter();

        var result = adapter.Adapt("{ \"key\": 1 }");

        Assert.StartsWith("JSON_ADAPTED::", result);
    }

    [Fact]
    public void XmlAdapter_Adapt_ReturnsXmlAdaptedPrefix()
    {
        IMessageAdapter adapter = new XmlAdapter();

        var result = adapter.Adapt("<root/>");

        Assert.StartsWith("XML_ADAPTED::", result);
    }

    [Fact]
    public void CsvAdapter_Adapt_ReturnsCsvAdaptedWithPipes()
    {
        IMessageAdapter adapter = new CsvAdapter();

        var result = adapter.Adapt("A,B,C");

        Assert.StartsWith("CSV_ADAPTED::", result);
        Assert.Contains("A | B | C", result);
    }

    [Fact]
    public void JsonAdapter_SourceType_IsJson()
    {
        var adapter = new JsonAdapter();

        Assert.Equal("json", adapter.SourceType);
    }

    [Fact]
    public void Registry_Resolve_ReturnsRegisteredAdapter()
    {
        var registry = new AdapterRegistry(new IMessageAdapter[] { new JsonAdapter() });

        var adapter = registry.Resolve("json");

        Assert.IsType<JsonAdapter>(adapter);
    }

    [Fact]
    public void Registry_Resolve_UnknownType_Throws()
    {
        var registry = new AdapterRegistry(Array.Empty<IMessageAdapter>());

        Assert.Throws<InvalidOperationException>(() => registry.Resolve("yaml"));
    }

    [Fact]
    public void Registry_TryResolve_KnownType_ReturnsTrue()
    {
        var registry = new AdapterRegistry(new IMessageAdapter[] { new XmlAdapter() });

        var found = registry.TryResolve("xml", out var adapter);

        Assert.True(found);
        Assert.NotNull(adapter);
    }

    [Fact]
    public void Registry_TryResolve_UnknownType_ReturnsFalse()
    {
        var registry = new AdapterRegistry(Array.Empty<IMessageAdapter>());

        var found = registry.TryResolve("csv", out _);

        Assert.False(found);
    }

    [Fact]
    public void Registry_Register_DuplicateType_Throws()
    {
        var registry = new AdapterRegistry(new IMessageAdapter[] { new JsonAdapter() });

        Assert.Throws<InvalidOperationException>(() => registry.Register(new JsonAdapter()));
    }

    [Fact]
    public void Registry_RegisteredTypes_ReturnsAllKeys()
    {
        var registry = new AdapterRegistry(new IMessageAdapter[]
        {
            new JsonAdapter(),
            new XmlAdapter(),
            new CsvAdapter()
        });

        var types = registry.RegisteredTypes().ToList();

        Assert.Equal(3, types.Count);
        Assert.Contains("json", types);
        Assert.Contains("xml", types);
        Assert.Contains("csv", types);
    }

    [Fact]
    public void Registry_DynamicRegistration_NewAdapterAvailable()
    {
        var registry = new AdapterRegistry(new IMessageAdapter[] { new JsonAdapter() });

        registry.Register(new CsvAdapter());

        Assert.True(registry.TryResolve("csv", out _));
    }
}
