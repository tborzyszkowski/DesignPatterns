// =============================================================================
// Wzorzec Łańcuch Zobowiązań — 05. Większy przykład
// System wypłat bankomatowych (ATM Dispenser Chain)
// Uruchamianie: cd Examples && dotnet run
// =============================================================================
using CoR.WiekszyPrzyklad;

Console.WriteLine("╔══════════════════════════════════════════════╗");
Console.WriteLine("║       BANKOMAT — System wypłat (CoR)        ║");
Console.WriteLine("╚══════════════════════════════════════════════╝\n");

var atm = new ATM(new()
{
    [200] = 10,
    [100] = 20,
    [50]  = 20,
    [20]  = 50,
    [10]  = 100
});

int[] withdrawals = [380, 250, 90, 1000, 15, 10, 0];

foreach (var amount in withdrawals)
{
    Console.WriteLine($"─── Wypłata: {amount} zł ───");
    var result = atm.Withdraw(amount);

    if (result.Success)
    {
        Console.WriteLine("  ✔ Wydano banknoty:");
        foreach (var (denom, count) in result.Notes.OrderByDescending(k => k.Key))
            Console.WriteLine($"      {denom} zł × {count} = {denom * count} zł");
        Console.WriteLine($"      Łącznie: {result.TotalAmount} zł");
    }
    else
    {
        Console.WriteLine($"  ✗ {result.ErrorMessage}");
    }
    Console.WriteLine();
}

Console.WriteLine("─── Stan kasy po wszystkich wypłatach ───");
foreach (var denom in new[] { 200, 100, 50, 20, 10 })
{
    var count = atm.GetAvailable(denom);
    Console.WriteLine($"  {(count > 0 ? "✔" : "✗")} {denom,4} zł: {count,4} szt.");
}
