using Examples;
using Xunit;

namespace Examples.Tests;

public class AdapterVariantsTests
{
    [Fact]
    public void ObjectAdapter_Export_ReturnsCsvPrefix()
    {
        IFileExporter adapter = new ObjectAdapter(new LegacyCsvService());

        var result = adapter.Export("report");

        Assert.Equal("CSV::report", result);
    }

    [Fact]
    public void ClassAdapter_Export_ReturnsCsvPrefix()
    {
        IFileExporter adapter = new ClassAdapter();

        var result = adapter.Export("report");

        Assert.Equal("CSV::report", result);
    }

    [Fact]
    public void BothAdapters_ProduceSameOutput()
    {
        IFileExporter objectAdapter = new ObjectAdapter(new LegacyCsvService());
        IFileExporter classAdapter = new ClassAdapter();

        var objectResult = objectAdapter.Export("data");
        var classResult = classAdapter.Export("data");

        Assert.Equal(objectResult, classResult);
    }

    [Fact]
    public void LegacyCsvService_SaveCsv_ReturnsCsvFormat()
    {
        var service = new LegacyCsvService();

        var result = service.SaveCsv("raw");

        Assert.Equal("CSV::raw", result);
    }

    [Fact]
    public void ObjectAdapter_WithEmptyInput_ReturnsCsvPrefixOnly()
    {
        IFileExporter adapter = new ObjectAdapter(new LegacyCsvService());

        var result = adapter.Export("");

        Assert.Equal("CSV::", result);
    }
}
