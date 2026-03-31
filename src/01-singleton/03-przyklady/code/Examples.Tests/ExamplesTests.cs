using ConfigurationExample;
using ConnectionPoolExample;
using FactoryExample;
using LoggerExample;
using Xunit;

namespace Examples.Tests;

// =====================================================================
// Testy: AppConfiguration (Singleton)
// =====================================================================

public class AppConfigurationTests
{
    [Fact]
    public void Instance_ReturnsSameObject()
    {
        var c1 = AppConfiguration.Instance;
        var c2 = AppConfiguration.Instance;
        Assert.Same(c1, c2);
    }

    [Fact]
    public void Get_ExistingKey_ReturnsValue()
    {
        var config = AppConfiguration.Instance;
        Assert.Equal("Development", config.Get("Environment"));
    }

    [Fact]
    public void Get_NonExistingKey_ReturnsEmpty()
    {
        Assert.Equal(string.Empty, AppConfiguration.Instance.Get("NonExistent"));
    }

    [Fact]
    public void Get_CaseInsensitive()
    {
        Assert.Equal(
            AppConfiguration.Instance.Get("environment"),
            AppConfiguration.Instance.Get("ENVIRONMENT"));
    }

    [Fact]
    public void GetGeneric_Int_ParsesCorrectly()
    {
        var timeout = AppConfiguration.Instance.Get<int>("ConnectionTimeout", 0);
        Assert.Equal(30, timeout);
    }

    [Fact]
    public void GetGeneric_NonExistingKey_ReturnsDefault()
    {
        var value = AppConfiguration.Instance.Get<int>("Missing", 42);
        Assert.Equal(42, value);
    }

    [Fact]
    public void Keys_ContainsExpectedSettings()
    {
        var keys = AppConfiguration.Instance.Keys.ToList();
        Assert.Contains("ConnectionString", keys);
        Assert.Contains("Environment", keys);
        Assert.Contains("LogLevel", keys);
    }
}

// =====================================================================
// Testy: DbConnectionPool (Singleton)
// =====================================================================

public class DbConnectionPoolTests
{
    [Fact]
    public void Instance_ReturnsSameObject()
    {
        var p1 = DbConnectionPool.Instance;
        var p2 = DbConnectionPool.Instance;
        Assert.Same(p1, p2);
    }

    [Fact]
    public void PoolSize_IsThree()
    {
        Assert.Equal(3, DbConnectionPool.PoolSize);
    }

    [Fact]
    public async Task AcquireAndRelease_WorksCorrectly()
    {
        var pool = DbConnectionPool.Instance;
        var conn = await pool.AcquireAsync();

        Assert.NotNull(conn);
        Assert.True(conn.IsOpen);

        pool.Release(conn);
        Assert.False(conn.IsOpen);
    }

    [Fact]
    public void DbConnection_ExecuteQuery_WhenClosed_Throws()
    {
        var conn = new DbConnection(999);
        Assert.Throws<InvalidOperationException>(
            () => conn.ExecuteQuery("SELECT 1"));
    }

    [Fact]
    public void DbConnection_ExecuteQuery_WhenOpen_ReturnsResult()
    {
        var conn = new DbConnection(999);
        conn.Open();
        var result = conn.ExecuteQuery("SELECT 1");

        Assert.Contains("SELECT 1", result);
        conn.Close();
    }
}

// =====================================================================
// Testy: VehicleFactory (Singleton)
// =====================================================================

public class VehicleFactoryTests
{
    [Fact]
    public void Instance_ReturnsSameObject()
    {
        var f1 = VehicleFactory.Instance;
        var f2 = VehicleFactory.Instance;
        Assert.Same(f1, f2);
    }

    [Theory]
    [InlineData("car", "Car")]
    [InlineData("truck", "Truck")]
    [InlineData("bike", "Bike")]
    public void Create_BuiltInType_ReturnsCorrectVehicle(string type, string expectedType)
    {
        var vehicle = VehicleFactory.Instance.Create(type);
        Assert.Equal(expectedType, vehicle.Type);
    }

    [Fact]
    public void Create_UnknownType_Throws()
    {
        Assert.Throws<ArgumentException>(
            () => VehicleFactory.Instance.Create("spaceship"));
    }

    [Fact]
    public void Create_IsCaseInsensitive()
    {
        var vehicle = VehicleFactory.Instance.Create("CAR");
        Assert.Equal("Car", vehicle.Type);
    }

    [Fact]
    public void Register_NewType_CanBeCreated()
    {
        VehicleFactory.Instance.Register("scooter", () => new Bike()); // reuse Bike as test
        var vehicle = VehicleFactory.Instance.Create("scooter");
        Assert.NotNull(vehicle);
    }

    [Fact]
    public void RegisteredTypes_ContainsBuiltInTypes()
    {
        var types = VehicleFactory.Instance.RegisteredTypes.ToList();
        Assert.Contains("car", types, StringComparer.OrdinalIgnoreCase);
        Assert.Contains("truck", types, StringComparer.OrdinalIgnoreCase);
        Assert.Contains("bike", types, StringComparer.OrdinalIgnoreCase);
    }
}

// =====================================================================
// Testy: AppLogger (Singleton)
// =====================================================================

public class AppLoggerTests
{
    [Fact]
    public void Instance_ReturnsSameObject()
    {
        var l1 = AppLogger.Instance;
        var l2 = AppLogger.Instance;
        Assert.Same(l1, l2);
    }

    [Fact]
    public void Log_DoesNotThrow()
    {
        var logger = AppLogger.Instance;
        logger.Log(LogLevel.Info, "Test message");
        // Jeśli nie rzuciło wyjątku — logger działa
    }

    [Fact]
    public void ConvenienceMethods_DoNotThrow()
    {
        var logger = AppLogger.Instance;
        logger.LogDebug("debug");
        logger.LogInfo("info");
        logger.LogWarning("warning");
        logger.LogError("error");
        logger.LogCritical("critical");
    }
}
