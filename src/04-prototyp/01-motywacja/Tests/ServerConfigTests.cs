using Motywacja.Expensive;
using Xunit;

namespace Examples.Tests;

public class ServerConfigTests
{
    private static ServerConfig CreateTestConfig(
        string host = "db-test.firma.pl",
        int port = 5432,
        string database = "app_test",
        int poolSize = 10,
        TimeSpan? initTime = null)
    {
        return new ServerConfig(
            host, port, database, poolSize,
            ["10.0.0.1", "10.0.0.2"],
            initTime ?? TimeSpan.Zero);
    }

    [Fact]
    public void Clone_CreatesIndependentCopy()
    {
        var original = CreateTestConfig();

        var clone = original.Clone();

        Assert.Equal(original.Host, clone.Host);
        Assert.Equal(original.Port, clone.Port);
        Assert.Equal(original.Database, clone.Database);
        Assert.Equal(original.PoolSize, clone.PoolSize);
    }

    [Fact]
    public void Clone_DeepCopiesAllowedIps()
    {
        var original = CreateTestConfig();

        var clone = original.Clone();

        Assert.False(ReferenceEquals(original.AllowedIps, clone.AllowedIps));
        Assert.Equal(original.AllowedIps, clone.AllowedIps);
    }

    [Fact]
    public void Clone_ResetsInitTime()
    {
        var original = CreateTestConfig(initTime: TimeSpan.FromSeconds(5));

        var clone = original.Clone();

        Assert.Equal(TimeSpan.Zero, clone.InitTime);
    }

    [Fact]
    public void CloneWith_OverridesPort()
    {
        var original = CreateTestConfig(port: 5432);

        var clone = original.CloneWith(port: 3306);

        Assert.Equal(3306, clone.Port);
        Assert.Equal(original.Host, clone.Host);
        Assert.Equal(original.Database, clone.Database);
    }

    [Fact]
    public void CloneWith_OverridesPoolSize()
    {
        var original = CreateTestConfig(poolSize: 10);

        var clone = original.CloneWith(poolSize: 50);

        Assert.Equal(50, clone.PoolSize);
        Assert.Equal(original.Host, clone.Host);
    }

    [Fact]
    public void CloneWith_DeepCopiesAllowedIps()
    {
        var original = CreateTestConfig();

        var clone = original.CloneWith(port: 9999);

        Assert.False(ReferenceEquals(original.AllowedIps, clone.AllowedIps));
    }

    [Fact]
    public void CloneWith_PreservesUnchangedFields()
    {
        var original = CreateTestConfig(host: "myhost", port: 1234, database: "mydb", poolSize: 7);

        var clone = original.CloneWith();

        Assert.Equal("myhost", clone.Host);
        Assert.Equal(1234, clone.Port);
        Assert.Equal("mydb", clone.Database);
        Assert.Equal(7, clone.PoolSize);
    }
}
