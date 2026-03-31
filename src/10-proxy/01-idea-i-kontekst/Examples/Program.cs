// Demonstrates the core Proxy idea: an intermediary with the same contract
// that adds a controlled entry point without changing the client code.
//
// Pattern roles:
//   IReportService  -> Subject (shared contract)
//   RealReportService -> RealSubject (real work)
//   ReportServiceProxy -> Proxy (access control)
//   top-level statements -> Client

Console.WriteLine("=== Proxy - idea i kontekst ===");
Console.WriteLine();

var user  = new UserContext(UserRole.User);
var admin = new UserContext(UserRole.Admin);

// Both user and admin get an IReportService — client never knows the difference.
IReportService userProxy  = new ReportServiceProxy(new RealReportService(), user);
IReportService adminProxy = new ReportServiceProxy(new RealReportService(), admin);

// 1. Read operation – allowed for everyone.
Console.WriteLine(userProxy.GetMonthlyReport(3));
Console.WriteLine();

// 2. Delete – blocked for plain user.
try
{
    userProxy.DeleteAllReports();
}
catch (UnauthorizedAccessException ex)
{
    Console.WriteLine($"Expected: {ex.Message}");
}

Console.WriteLine();

// 3. Delete – allowed for admin.
adminProxy.DeleteAllReports();

// ── Domain contracts ─────────────────────────────────────────────────────────

internal enum UserRole { User, Admin }

internal sealed record UserContext(UserRole Role);

internal interface IReportService
{
    string GetMonthlyReport(int month);
    void DeleteAllReports();
}

// ── RealSubject ───────────────────────────────────────────────────────────────

internal sealed class RealReportService : IReportService
{
    public string GetMonthlyReport(int month) => $"REPORT-{month:00}";

    public void DeleteAllReports()
        => Console.WriteLine("RealReportService: all reports deleted");
}

// ── Proxy ─────────────────────────────────────────────────────────────────────

internal sealed class ReportServiceProxy(IReportService inner, UserContext context) : IReportService
{
    private readonly IReportService _inner = inner;
    private readonly UserContext _context = context;

    public string GetMonthlyReport(int month)
    {
        Console.WriteLine($"Proxy: GetMonthlyReport({month}) [role={_context.Role}]");
        return _inner.GetMonthlyReport(month);
    }

    public void DeleteAllReports()
    {
        Console.WriteLine("Proxy: DeleteAllReports() requested");

        if (_context.Role != UserRole.Admin)
        {
            throw new UnauthorizedAccessException("Only Admin can delete reports.");
        }

        _inner.DeleteAllReports();
    }
}
