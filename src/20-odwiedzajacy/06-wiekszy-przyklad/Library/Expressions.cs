namespace Visitor.WiekszyPrzyklad;

// ══════════════════════════════════════════════════════════════
// AST — Abstract Syntax Tree (drzewo wyrażeń arytmetycznych)
// ══════════════════════════════════════════════════════════════

/// <summary>Interfejs odwiedzającego — deklaruje Visit dla każdego węzła AST.</summary>
public interface IExprVisitor
{
    void Visit(Num n);
    void Visit(BinOp b);
    void Visit(Neg n);
    void Visit(Var v);
}

/// <summary>Bazowy węzeł drzewa wyrażeń.</summary>
public abstract record Expr
{
    public abstract void Accept(IExprVisitor visitor);
}

/// <summary>Węzeł: stała liczbowa (np. 3.14, 42).</summary>
public record Num(double Value) : Expr
{
    public override void Accept(IExprVisitor visitor) => visitor.Visit(this);
}

/// <summary>Węzeł: operacja binarna (+, -, *, /).</summary>
public record BinOp(Expr Left, string Op, Expr Right) : Expr
{
    public override void Accept(IExprVisitor visitor) => visitor.Visit(this);
}

/// <summary>Węzeł: negacja unarna (-x).</summary>
public record Neg(Expr Operand) : Expr
{
    public override void Accept(IExprVisitor visitor) => visitor.Visit(this);
}

/// <summary>Węzeł: zmienna (np. x, y).</summary>
public record Var(string Name) : Expr
{
    public override void Accept(IExprVisitor visitor) => visitor.Visit(this);
}

// ══════════════════════════════════════════════════════════════
// Odwiedzający 1: Ewaluacja (obliczenie wartości)
// ══════════════════════════════════════════════════════════════

/// <summary>
/// Oblicza wartość wyrażenia. Zmienne rozwiązywane przez podany słownik.
/// Używa stosu do gromadzenia wyników podwyrażeń.
/// </summary>
public class EvalVisitor(IReadOnlyDictionary<string, double>? variables = null) : IExprVisitor
{
    private readonly Stack<double> _stack = new();

    public double Result => _stack.Count > 0
        ? _stack.Peek()
        : throw new InvalidOperationException("Brak wyrazeń do obliczenia.");

    public void Visit(Num n) => _stack.Push(n.Value);

    public void Visit(BinOp b)
    {
        b.Left.Accept(this);
        b.Right.Accept(this);
        double right = _stack.Pop();
        double left  = _stack.Pop();
        _stack.Push(b.Op switch
        {
            "+" => left + right,
            "-" => left - right,
            "*" => left * right,
            "/" when right == 0 => throw new DivideByZeroException("Dzielenie przez zero"),
            "/" => left / right,
            "%" => left % right,
            _   => throw new InvalidOperationException($"Nieznany operator: {b.Op}")
        });
    }

    public void Visit(Neg n)
    {
        n.Operand.Accept(this);
        _stack.Push(-_stack.Pop());
    }

    public void Visit(Var v)
    {
        if (variables is not null && variables.TryGetValue(v.Name, out double val))
            _stack.Push(val);
        else
            throw new InvalidOperationException($"Nieznana zmienna: '{v.Name}'");
    }
}

// ══════════════════════════════════════════════════════════════
// Odwiedzający 2: Drukowanie (pretty-print wyrażenia)
// ══════════════════════════════════════════════════════════════

/// <summary>
/// Tworzy tekstową reprezentację wyrażenia z nawiasami (fully parenthesized).
/// </summary>
public class PrintVisitor : IExprVisitor
{
    private readonly System.Text.StringBuilder _sb = new();
    public string Result => _sb.ToString();

    public void Visit(Num n)
        => _sb.Append(n.Value % 1 == 0 ? ((long)n.Value).ToString() : n.Value.ToString("G"));

    public void Visit(BinOp b)
    {
        _sb.Append('(');
        b.Left.Accept(this);
        _sb.Append($" {b.Op} ");
        b.Right.Accept(this);
        _sb.Append(')');
    }

    public void Visit(Neg n)
    {
        _sb.Append("-(");
        n.Operand.Accept(this);
        _sb.Append(')');
    }

    public void Visit(Var v) => _sb.Append(v.Name);
}

// ══════════════════════════════════════════════════════════════
// Odwiedzający 3: Optymalizacja (constant folding + simplify)
// ══════════════════════════════════════════════════════════════

/// <summary>
/// Optymalizuje drzewo wyrażeń:
/// - constant folding: (2 + 3) → 5
/// - eliminacja podwójnej negacji: -(-x) → x
/// - eliminacja mnożenia przez 0: x * 0 → 0
/// - eliminacja dodawania 0: x + 0 → x
/// </summary>
public class OptimizeVisitor : IExprVisitor
{
    private readonly Stack<Expr> _stack = new();

    public Expr Result => _stack.Count > 0
        ? _stack.Peek()
        : throw new InvalidOperationException("Brak wyrażeń do optymalizacji.");

    public void Visit(Num n) => _stack.Push(n);

    public void Visit(BinOp b)
    {
        b.Left.Accept(this);
        b.Right.Accept(this);
        var right = _stack.Pop();
        var left  = _stack.Pop();

        // Constant folding: oba operandy są stałymi
        if (left is Num(var l) && right is Num(var r))
        {
            double result = b.Op switch
            {
                "+" => l + r,
                "-" => l - r,
                "*" => l * r,
                "/" when r != 0 => l / r,
                _ => double.NaN
            };
            if (!double.IsNaN(result)) { _stack.Push(new Num(result)); return; }
        }

        // x * 0 = 0  lub  0 * x = 0
        if (b.Op == "*" && (IsZero(left) || IsZero(right)))
        { _stack.Push(new Num(0)); return; }

        // x + 0 = x  lub  0 + x = x
        if (b.Op == "+" && IsZero(right)) { _stack.Push(left);  return; }
        if (b.Op == "+" && IsZero(left))  { _stack.Push(right); return; }

        // x - 0 = x
        if (b.Op == "-" && IsZero(right)) { _stack.Push(left); return; }

        _stack.Push(new BinOp(left, b.Op, right));
    }

    public void Visit(Neg n)
    {
        n.Operand.Accept(this);
        var inner = _stack.Pop();
        // -(-x) = x
        if (inner is Neg(var x)) { _stack.Push(x); return; }
        // -(stała) = stała ze znakiem
        if (inner is Num(var v)) { _stack.Push(new Num(-v)); return; }
        _stack.Push(new Neg(inner));
    }

    public void Visit(Var v) => _stack.Push(v);

    private static bool IsZero(Expr e) => e is Num(0.0);
}

// ══════════════════════════════════════════════════════════════
// Odwiedzający 4: Zliczanie węzłów (statystyki)
// ══════════════════════════════════════════════════════════════

/// <summary>Zbiera statystyki o węzłach drzewa.</summary>
public class StatsVisitor : IExprVisitor
{
    public int NumCount    { get; private set; }
    public int BinOpCount  { get; private set; }
    public int NegCount    { get; private set; }
    public int VarCount    { get; private set; }
    public int TotalNodes  => NumCount + BinOpCount + NegCount + VarCount;
    public int Depth       { get; private set; }
    private int _currentDepth;

    public void Visit(Num n) { NumCount++; UpdateDepth(); }
    public void Visit(Var v) { VarCount++; UpdateDepth(); }

    public void Visit(BinOp b)
    {
        BinOpCount++;
        _currentDepth++;
        b.Left.Accept(this);
        b.Right.Accept(this);
        _currentDepth--;
    }

    public void Visit(Neg n)
    {
        NegCount++;
        _currentDepth++;
        n.Operand.Accept(this);
        _currentDepth--;
    }

    private void UpdateDepth()
    {
        if (_currentDepth > Depth) Depth = _currentDepth;
    }
}
