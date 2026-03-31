using Alternatives;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Alternatives.Tests;

// =====================================================================
// Testy: Dependency Injection jako alternatywa Singletona
// =====================================================================

public class DIExampleTests
{
    [Fact]
    public void DI_Singleton_ReturnsSameInstance()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IEmailSender, SmtpEmailSender>();
        var provider = services.BuildServiceProvider();

        var s1 = provider.GetRequiredService<IEmailSender>();
        var s2 = provider.GetRequiredService<IEmailSender>();

        Assert.Same(s1, s2);
    }

    [Fact]
    public void DI_Transient_ReturnsDifferentInstances()
    {
        var services = new ServiceCollection();
        services.AddTransient<IEmailSender, SmtpEmailSender>();
        var provider = services.BuildServiceProvider();

        var s1 = provider.GetRequiredService<IEmailSender>();
        var s2 = provider.GetRequiredService<IEmailSender>();

        Assert.NotSame(s1, s2);
    }

    [Fact]
    public void OrderService_UsesMockSender_InTests()
    {
        var mock = new MockEmailSender();
        var service = new OrderService(mock);

        service.PlaceOrder("test@example.com", "Laptop");

        Assert.Single(mock.SentMessages);
        Assert.Contains("Laptop", mock.SentMessages[0]);
    }

    [Fact]
    public void SmtpEmailSender_TracksSentMessages()
    {
        var sender = new SmtpEmailSender();
        sender.Send("a@b.com", "Subject", "Body");

        Assert.Single(sender.SentMessages);
    }

    [Fact]
    public void MockEmailSender_TracksSentMessages()
    {
        var sender = new MockEmailSender();
        sender.Send("a@b.com", "Subject", "Body");

        Assert.Single(sender.SentMessages);
        Assert.Contains("MOCK", sender.SentMessages[0]);
    }
}

// =====================================================================
// Testy: Monostate Pattern
// =====================================================================

public class MonostateLoggerTests
{
    [Fact]
    public void TwoInstances_ShareSameState()
    {
        var logger1 = new MonostateLogger();
        var logger2 = new MonostateLogger();

        logger1.LogFile = "shared.log";
        Assert.Equal("shared.log", logger2.LogFile);
    }

    [Fact]
    public void TwoInstances_AreDifferentObjects()
    {
        var logger1 = new MonostateLogger();
        var logger2 = new MonostateLogger();
        Assert.NotSame(logger1, logger2);
    }

    [Fact]
    public void Log_BelowMinimumLevel_DoesNotIncrementCount()
    {
        var logger = new MonostateLogger();
        logger.MinimumLevel = Alternatives.LogLevel.Warning;
        var countBefore = MonostateLogger.MessageCount;

        logger.Log(Alternatives.LogLevel.Debug, "should be filtered");

        Assert.Equal(countBefore, MonostateLogger.MessageCount);
    }

    [Fact]
    public void Log_AtOrAboveMinimumLevel_IncrementsCount()
    {
        var logger = new MonostateLogger();
        logger.MinimumLevel = Alternatives.LogLevel.Info;
        var countBefore = MonostateLogger.MessageCount;

        logger.Log(Alternatives.LogLevel.Error, "error message");

        Assert.Equal(countBefore + 1, MonostateLogger.MessageCount);
    }
}

// =====================================================================
// Testy: Ambient Context (AppTimeProvider)
// =====================================================================

public class AppTimeProviderTests
{
    [Fact]
    public void Default_ReturnsSystemTimeProvider()
    {
        Assert.IsType<SystemAppTimeProvider>(AppTimeProvider.Default);
    }

    [Fact]
    public void Current_CanBeReplaced_WithFixedProvider()
    {
        var fixedTime = new DateTime(2025, 6, 15, 12, 0, 0);
        AppTimeProvider.Current = new FixedAppTimeProvider(fixedTime);

        Assert.Equal(fixedTime, AppTimeProvider.Current.Now);

        // Reset
        AppTimeProvider.Current = AppTimeProvider.Default;
    }

    [Fact]
    public void FixedProvider_AlwaysReturnsSameTime()
    {
        var fixedTime = new DateTime(2025, 1, 1, 0, 0, 0);
        var provider = new FixedAppTimeProvider(fixedTime);

        Assert.Equal(fixedTime, provider.Now);
        Assert.Equal(fixedTime, provider.Now); // drugie wywołanie — ten sam czas
    }

    [Fact]
    public void Current_SetToNull_Throws()
    {
        Assert.Throws<ArgumentNullException>(
            () => AppTimeProvider.Current = null!);
    }

    [Fact]
    public void SystemTimeProvider_ReturnsApproximateCurrentTime()
    {
        var provider = new SystemAppTimeProvider();
        var now = provider.Now;

        // Czas powinien być "blisko" DateTime.Now (±2s)
        Assert.InRange(now, DateTime.Now.AddSeconds(-2), DateTime.Now.AddSeconds(2));
    }
}
