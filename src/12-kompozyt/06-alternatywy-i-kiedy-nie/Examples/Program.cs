var expenses = new List<Expense>
{
    new("Hosting", 200),
    new("Domain", 50),
    new("Monitoring", 80)
};

decimal total = expenses.Sum(x => x.Amount);
Console.WriteLine("Prosty model listy wydatków:");
foreach (Expense expense in expenses)
{
    Console.WriteLine($"- {expense.Name}: {expense.Amount} PLN");
}
Console.WriteLine($"Suma: {total} PLN");
Console.WriteLine();
Console.WriteLine("Wniosek: tutaj Kompozyt nie jest potrzebny, bo model jest płaski.");

internal sealed record Expense(string Name, decimal Amount);
