// ============================================================
// Wzorzec Odwiedzający — Temat 05: Wady, zalety, alternatywy
// Porównanie Visitor z polimorfizmem i pattern matching
// ============================================================

var employees = new List<IEmployee>
{
    new Developer("Anna Nowak",      8_500m, "C#"),
    new Developer("Piotr Kowalski",  7_200m, "Python"),
    new Manager  ("Maria Wiśniewska",12_000m, 5),
    new Director ("Jan Zając",       18_000m, "IT"),
    new Developer("Tomasz Lewicki",   9_100m, "C#"),
};

// ═══════════════════════════════════════════════════════════
// PODEJŚCIE A: Wzorzec Visitor (GoF)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("══ A: Visitor GoF ══\n");

var bonusV = new BonusVisitor();
employees.ForEach(e => e.Accept(bonusV));
Console.WriteLine("Premie (Visitor):");
bonusV.Bonuses.ToList().ForEach(kv => Console.WriteLine($"  {kv.Key}: {kv.Value:C}"));

var reportV = new SalaryReportVisitor();
employees.ForEach(e => e.Accept(reportV));
Console.WriteLine("\nRaport (Visitor):");
reportV.Lines.ForEach(Console.WriteLine);

// ═══════════════════════════════════════════════════════════
// PODEJŚCIE B: pattern matching (switch expression)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("\n══ B: Pattern matching ══\n");

static decimal CalculateBonus(IEmployee emp) => emp switch
{
    Developer d => d.Salary * 0.10m,
    Manager m   => m.Salary * 0.15m + m.TeamSize * 200m,
    Director d  => d.Salary * 0.20m,
    _           => 0m
};

static string FormatLine(IEmployee emp) => emp switch
{
    Developer d => $"  Dev   {d.Name,-20} {d.Salary,10:C} [{d.Language}]",
    Manager m   => $"  Mgr   {m.Name,-20} {m.Salary,10:C} [zespół: {m.TeamSize}]",
    Director d  => $"  Dir   {d.Name,-20} {d.Salary,10:C} [{d.Department}]",
    _           => "  ???"
};

Console.WriteLine("Premie (switch):");
employees.ForEach(e => Console.WriteLine($"  {e.Name}: {CalculateBonus(e):C}"));
Console.WriteLine("\nRaport (switch):");
employees.ForEach(e => Console.WriteLine(FormatLine(e)));

// ═══════════════════════════════════════════════════════════
// PODEJŚCIE C: polimorfizm (metoda wirtualna)
// ═══════════════════════════════════════════════════════════

Console.WriteLine("\n══ C: Polimorfizm (virtual) ══\n");

var baseEmployees = new List<EmployeeBase>
{
    new DevEmployee("Anna Nowak", 8_500m, "C#"),
    new MgrEmployee("Maria Wiśniewska", 12_000m, 5),
};

Console.WriteLine("Premie (polimorfizm):");
baseEmployees.ForEach(e => Console.WriteLine($"  {e.Name}: {e.GetBonus():C}"));
Console.WriteLine("\nRaport (polimorfizm):");
baseEmployees.ForEach(e => Console.WriteLine(e.GetReportLine()));

Console.WriteLine("""

══════════════════════════════════════════════════════
WNIOSKI:
  A (Visitor)  → Dodawanie operacji jest łatwe.
                 Dodanie nowego typu (np. Intern) wymaga
                 zmiany WSZYSTKICH odwiedzających.
  B (switch)   → Kod zwięzły, ale rozproszony.
                 Dodanie operacji = nowa funkcja statyczna.
                 Kompilator ostrzeże o brakujących przypadkach.
  C (virtual)  → Naturalne OOP. Nowy typ = nowa klasa.
                 Nowa operacja = zmiana WSZYSTKICH klas.
══════════════════════════════════════════════════════
""");

// ─── Typy ──────────────────────────────────────────────────

interface IEmployee { string Name { get; } decimal Salary { get; } }
record Developer(string Name, decimal Salary, string Language) : IEmployee;
record Manager(string Name, decimal Salary, int TeamSize) : IEmployee;
record Director(string Name, decimal Salary, string Department) : IEmployee;

interface IEmployeeVisitor
{
    void Visit(Developer d);
    void Visit(Manager m);
    void Visit(Director d);
}

static class EmployeeExtensions
{
    public static void Accept(this IEmployee emp, IEmployeeVisitor v)
    {
        switch (emp)
        {
            case Developer d:  v.Visit(d);   break;
            case Manager m:    v.Visit(m);   break;
            case Director dir: v.Visit(dir); break;
        }
    }
}

class BonusVisitor : IEmployeeVisitor
{
    public Dictionary<string, decimal> Bonuses { get; } = [];

    public void Visit(Developer d) => Bonuses[d.Name] = d.Salary * 0.10m;
    public void Visit(Manager m)   => Bonuses[m.Name] = m.Salary * 0.15m + m.TeamSize * 200m;
    public void Visit(Director d)  => Bonuses[d.Name] = d.Salary * 0.20m;
}

class SalaryReportVisitor : IEmployeeVisitor
{
    public List<string> Lines { get; } = [];

    public void Visit(Developer d) => Lines.Add($"  Dev   {d.Name,-20} {d.Salary,10:C} [{d.Language}]");
    public void Visit(Manager m)   => Lines.Add($"  Mgr   {m.Name,-20} {m.Salary,10:C} [zespół: {m.TeamSize}]");
    public void Visit(Director d)  => Lines.Add($"  Dir   {d.Name,-20} {d.Salary,10:C} [{d.Department}]");
}

abstract class EmployeeBase
{
    public abstract string Name { get; }
    public abstract decimal Salary { get; }
    public abstract decimal GetBonus();
    public abstract string GetReportLine();
}

class DevEmployee(string name, decimal salary, string lang) : EmployeeBase
{
    public override string Name => name;
    public override decimal Salary => salary;
    public override decimal GetBonus()     => Salary * 0.10m;
    public override string GetReportLine() => $"  Dev   {Name,-20} {Salary,10:C} [{lang}]";
}

class MgrEmployee(string name, decimal salary, int team) : EmployeeBase
{
    public override string Name => name;
    public override decimal Salary => salary;
    public override decimal GetBonus()     => Salary * 0.15m + team * 200m;
    public override string GetReportLine() => $"  Mgr   {Name,-20} {Salary,10:C} [zespół: {team}]";
}
