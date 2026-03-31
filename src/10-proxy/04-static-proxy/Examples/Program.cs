UserContext user = new(UserRole.User);
UserContext admin = new(UserRole.Admin);

IReportService userProxy = new ReportServiceProxy(new RealReportService(), user, Console.WriteLine);
IReportService adminProxy = new ReportServiceProxy(new RealReportService(), admin, Console.WriteLine);

Console.WriteLine(userProxy.GetMonthlyReport(3));

try
{
    userProxy.DeleteAllReports();
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Expected: {ex.Message}");
}

adminProxy.DeleteAllReports();

internal enum UserRole
{
    User,
    Admin
}

internal sealed record UserContext(UserRole Role);

internal interface IReportService
{
    string GetMonthlyReport(int month);
    void DeleteAllReports();
}

internal sealed class RealReportService : IReportService
{
    public string GetMonthlyReport(int month) => $"REPORT-{month:00}";

    public void DeleteAllReports()
    {
        Console.WriteLine("RealReportService: all reports deleted");
    }
}

internal sealed class ReportServiceProxy(IReportService inner, UserContext context, Action<string> logger) : IReportService
{
    private readonly IReportService _inner = inner;
    private readonly UserContext _context = context;
    private readonly Action<string> _logger = logger;

    public string GetMonthlyReport(int month)
    {
        _logger($"Proxy: GetMonthlyReport({month})");
        return _inner.GetMonthlyReport(month);
    }

    public void DeleteAllReports()
    {
        _logger("Proxy: DeleteAllReports() requested");

        if (_context.Role != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only Admin can delete reports.");
        }

        _inner.DeleteAllReports();
    }
}
