// ============================================================
// Wzorzec Odwiedzający — Temat 06: Większy przykład
// Drzewo wyrażeń arytmetycznych (AST) z czterema odwiedzającymi
// ============================================================

using Visitor.WiekszyPrzyklad;

static string Print(Expr e)
{
    var v = new PrintVisitor(); e.Accept(v); return v.Result;
}

static double Eval(Expr e, Dictionary<string, double>? vars = null)
{
    var v = new EvalVisitor(vars); e.Accept(v); return v.Result;
}

static Expr Optimize(Expr e)
{
    var v = new OptimizeVisitor(); e.Accept(v); return v.Result;
}

Console.WriteLine("=== Wzorzec Odwiedzający — Drzewo wyrażeń (AST) ===\n");

// ─── Przykład 1: (2 + 3) * 4 ─────────────────────────────────

var expr1 = new BinOp(
    new BinOp(new Num(2), "+", new Num(3)),
    "*",
    new Num(4));

Console.WriteLine("─── Przykład 1: (2 + 3) * 4");
Console.WriteLine($"  Druk:     {Print(expr1)}");
Console.WriteLine($"  Wynik:    {Eval(expr1)}");    // 20
var opt1 = Optimize(expr1);
Console.WriteLine($"  Po opt.:  {Print(opt1)}");     // 20 (constant folding)
Console.WriteLine();

// ─── Przykład 2: x * (y + 2) przy x=3, y=4 ──────────────────

var expr2 = new BinOp(
    new Var("x"),
    "*",
    new BinOp(new Var("y"), "+", new Num(2)));

var vars = new Dictionary<string, double> { ["x"] = 3.0, ["y"] = 4.0 };
Console.WriteLine("─── Przykład 2: x * (y + 2) przy x=3, y=4");
Console.WriteLine($"  Druk:     {Print(expr2)}");
Console.WriteLine($"  Wynik:    {Eval(expr2, vars)}");  // 18
Console.WriteLine();

// ─── Przykład 3: Optymalizacja ────────────────────────────────

// (x + 0) * 1 + -(-(y)) → ale tu nie mamy jedynek, pokażmy co mamy
var expr3 = new BinOp(
    new BinOp(new Var("x"), "+", new Num(0)),
    "*",
    new BinOp(new Num(0), "+", new Num(5)));

Console.WriteLine("─── Przykład 3: (x + 0) * (0 + 5)");
Console.WriteLine($"  Przed opt.: {Print(expr3)}");
var opt3 = Optimize(expr3);
Console.WriteLine($"  Po opt.:    {Print(opt3)}");  // (x * 5)
Console.WriteLine();

// ─── Przykład 4: Podwójna negacja ────────────────────────────

var expr4 = new Neg(new Neg(new Var("x")));
Console.WriteLine("─── Przykład 4: -(-(x))");
Console.WriteLine($"  Przed opt.: {Print(expr4)}");
var opt4 = Optimize(expr4);
Console.WriteLine($"  Po opt.:    {Print(opt4)}");  // x
Console.WriteLine();

// ─── Przykład 5: Złożone wyrażenie ───────────────────────────

// (a * a) + (b * b) — suma kwadratów
var expr5 = new BinOp(
    new BinOp(new Var("a"), "*", new Var("a")),
    "+",
    new BinOp(new Var("b"), "*", new Var("b")));

var vars5 = new Dictionary<string, double> { ["a"] = 3.0, ["b"] = 4.0 };
Console.WriteLine("─── Przykład 5: (a*a) + (b*b) przy a=3, b=4");
Console.WriteLine($"  Druk:  {Print(expr5)}");
Console.WriteLine($"  Wynik: {Eval(expr5, vars5)}");  // 25 (pitagoras)
Console.WriteLine();

// ─── Statystyki AST ──────────────────────────────────────────

Console.WriteLine("─── Statystyki węzłów drzewa");
var stats5 = new StatsVisitor(); expr5.Accept(stats5);
Console.WriteLine($"  Wyrażenie: {Print(expr5)}");
Console.WriteLine($"  Węzły razem: {stats5.TotalNodes}");
Console.WriteLine($"    Liczby (Num):   {stats5.NumCount}");
Console.WriteLine($"    Operatory (BinOp): {stats5.BinOpCount}");
Console.WriteLine($"    Zmienne (Var):  {stats5.VarCount}");
Console.WriteLine($"    Negacje (Neg):  {stats5.NegCount}");
Console.WriteLine($"  Głębokość drzewa: {stats5.Depth}");

Console.WriteLine("""

=== Podsumowanie ===
Wzorzec Visitor na drzewie AST pozwolił zaimplementować:
  EvalVisitor     — ewaluacja wartości
  PrintVisitor    — tekstowa reprezentacja
  OptimizeVisitor — constant folding i upraszczanie
  StatsVisitor    — statystyki węzłów
Żaden węzeł (Num, BinOp, Neg, Var) nie był zmieniany!
""");
