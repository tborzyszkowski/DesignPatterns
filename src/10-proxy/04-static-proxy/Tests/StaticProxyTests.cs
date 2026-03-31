using Xunit;

public class StaticProxyTests
{
    [Fact]
    public void GetMonthlyReport_DelegatesAndLogs()
    {
        var fake = new FakeReportService();
        var logs = new List<string>();
        var proxy = new ReportServiceProxy(fake, new UserContext(UserRole.User), logs.Add);

        var result = proxy.GetMonthlyReport(7);

        Assert.Equal("FAKE-07", result);
        Assert.Equal(1, fake.GetCalls);
        Assert.Contains(logs, x => x.Contains("GetMonthlyReport(7)"));
    }

    [Fact]
    public void DeleteAllReports_ThrowsForUser()
    {
        var fake = new FakeReportService();
        var proxy = new ReportServiceProxy(fake, new UserContext(UserRole.User), _ => { });

        Assert.Throws<UnauthorizedAccessException>(() => proxy.DeleteAllReports());
        Assert.Equal(0, fake.DeleteCalls);
    }

    [Fact]
    public void DeleteAllReports_CallsInnerForAdmin()
    {
        var fake = new FakeReportService();
        var proxy = new ReportServiceProxy(fake, new UserContext(UserRole.Admin), _ => { });

        proxy.DeleteAllReports();

        Assert.Equal(1, fake.DeleteCalls);
    }

    private sealed class FakeReportService : IReportService
    {
        public int GetCalls { get; private set; }
        public int DeleteCalls { get; private set; }

        public string GetMonthlyReport(int month)
        {
            GetCalls++;
            return $"FAKE-{month:00}";
        }

        public void DeleteAllReports() => DeleteCalls++;
    }
}
