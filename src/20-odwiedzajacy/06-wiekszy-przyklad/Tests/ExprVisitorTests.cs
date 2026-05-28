using Visitor.WiekszyPrzyklad;
using Xunit;

namespace Visitor.WiekszyPrzyklad.Tests;

// ══════════════════════════════════════════════════════════════
// Testy EvalVisitor
// ══════════════════════════════════════════════════════════════

public class EvalVisitorTests
{
    private static double Eval(Expr e, Dictionary<string, double>? vars = null)
    {
        var v = new EvalVisitor(vars);
        e.Accept(v);
        return v.Result;
    }

    [Fact]
    public void Eval_Number_ReturnsValue()
    {
        Assert.Equal(42.0, Eval(new Num(42)));
    }

    [Fact]
    public void Eval_Addition_ReturnsSum()
    {
        var e = new BinOp(new Num(3), "+", new Num(4));
        Assert.Equal(7.0, Eval(e));
    }

    [Fact]
    public void Eval_Multiplication_ReturnsProduct()
    {
        var e = new BinOp(new Num(3), "*", new Num(4));
        Assert.Equal(12.0, Eval(e));
    }

    [Fact]
    public void Eval_NestedExpression_Correct()
    {
        // (2 + 3) * 4 = 20
        var e = new BinOp(
            new BinOp(new Num(2), "+", new Num(3)),
            "*",
            new Num(4));
        Assert.Equal(20.0, Eval(e));
    }

    [Fact]
    public void Eval_Negation_ReturnsNegated()
    {
        var e = new Neg(new Num(5));
        Assert.Equal(-5.0, Eval(e));
    }

    [Fact]
    public void Eval_Variable_ResolvesFromDictionary()
    {
        var e = new BinOp(new Var("x"), "+", new Num(1));
        var vars = new Dictionary<string, double> { ["x"] = 10.0 };
        Assert.Equal(11.0, Eval(e, vars));
    }

    [Fact]
    public void Eval_UnknownVariable_ThrowsException()
    {
        var e = new Var("z");
        Assert.Throws<InvalidOperationException>(() => Eval(e));
    }

    [Fact]
    public void Eval_DivisionByZero_ThrowsException()
    {
        var e = new BinOp(new Num(1), "/", new Num(0));
        Assert.Throws<DivideByZeroException>(() => Eval(e));
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0)]   // trójkąt 3-4-5
    [InlineData(5.0, 12.0, 13.0)] // trójkąt 5-12-13
    public void Eval_PythagoreanTheorem(double a, double b, double expected)
    {
        // a*a + b*b powinno = expected*expected
        var e = new BinOp(
            new BinOp(new Var("a"), "*", new Var("a")),
            "+",
            new BinOp(new Var("b"), "*", new Var("b")));
        var vars = new Dictionary<string, double> { ["a"] = a, ["b"] = b };
        Assert.Equal(expected * expected, Eval(e, vars));
    }
}

// ══════════════════════════════════════════════════════════════
// Testy PrintVisitor
// ══════════════════════════════════════════════════════════════

public class PrintVisitorTests
{
    private static string Print(Expr e)
    {
        var v = new PrintVisitor();
        e.Accept(v);
        return v.Result;
    }

    [Fact]
    public void Print_Number_ReturnsDigit()
    {
        Assert.Equal("5", Print(new Num(5)));
    }

    [Fact]
    public void Print_BinOp_AddsParentheses()
    {
        var e = new BinOp(new Num(2), "+", new Num(3));
        Assert.Equal("(2 + 3)", Print(e));
    }

    [Fact]
    public void Print_Negation_AddsNegSign()
    {
        var e = new Neg(new Num(5));
        Assert.Equal("-(5)", Print(e));
    }

    [Fact]
    public void Print_Variable_ReturnsName()
    {
        Assert.Equal("x", Print(new Var("x")));
    }

    [Fact]
    public void Print_NestedExpression_FullyParenthesized()
    {
        var e = new BinOp(
            new BinOp(new Num(2), "+", new Num(3)),
            "*",
            new Num(4));
        Assert.Equal("((2 + 3) * 4)", Print(e));
    }
}

// ══════════════════════════════════════════════════════════════
// Testy OptimizeVisitor
// ══════════════════════════════════════════════════════════════

public class OptimizeVisitorTests
{
    private static Expr Opt(Expr e)
    {
        var v = new OptimizeVisitor();
        e.Accept(v);
        return v.Result;
    }

    private static string Print(Expr e)
    {
        var v = new PrintVisitor();
        e.Accept(v);
        return v.Result;
    }

    [Fact]
    public void Optimize_ConstantFolding_Addition()
    {
        var e = new BinOp(new Num(2), "+", new Num(3));
        var result = Opt(e);
        Assert.IsType<Num>(result);
        Assert.Equal(5.0, ((Num)result).Value);
    }

    [Fact]
    public void Optimize_ConstantFolding_Multiplication()
    {
        var e = new BinOp(new Num(3), "*", new Num(4));
        var result = Opt(e);
        Assert.IsType<Num>(result);
        Assert.Equal(12.0, ((Num)result).Value);
    }

    [Fact]
    public void Optimize_MultiplyByZero_ReturnsZero()
    {
        var e = new BinOp(new Var("x"), "*", new Num(0));
        var result = Opt(e);
        Assert.IsType<Num>(result);
        Assert.Equal(0.0, ((Num)result).Value);
    }

    [Fact]
    public void Optimize_AddZero_ReturnsOtherOperand()
    {
        var e = new BinOp(new Var("x"), "+", new Num(0));
        var result = Opt(e);
        Assert.IsType<Var>(result);
        Assert.Equal("x", ((Var)result).Name);
    }

    [Fact]
    public void Optimize_DoubleNegation_Simplifies()
    {
        var e = new Neg(new Neg(new Var("x")));
        var result = Opt(e);
        Assert.IsType<Var>(result);
        Assert.Equal("x", ((Var)result).Name);
    }

    [Fact]
    public void Optimize_NegNumber_ReturnsFoldedNum()
    {
        var e = new Neg(new Num(5));
        var result = Opt(e);
        Assert.IsType<Num>(result);
        Assert.Equal(-5.0, ((Num)result).Value);
    }

    [Fact]
    public void Optimize_NestedConstantFolding()
    {
        // (2 + 3) * 4 → 5 * 4 → 20
        var e = new BinOp(
            new BinOp(new Num(2), "+", new Num(3)),
            "*",
            new Num(4));
        var result = Opt(e);
        Assert.IsType<Num>(result);
        Assert.Equal(20.0, ((Num)result).Value);
    }
}

// ══════════════════════════════════════════════════════════════
// Testy StatsVisitor
// ══════════════════════════════════════════════════════════════

public class StatsVisitorTests
{
    private static StatsVisitor CollectStats(Expr e)
    {
        var v = new StatsVisitor();
        e.Accept(v);
        return v;
    }

    [Fact]
    public void Stats_SingleNum_CountsOne()
    {
        var s = CollectStats(new Num(1));
        Assert.Equal(1, s.NumCount);
        Assert.Equal(1, s.TotalNodes);
    }

    [Fact]
    public void Stats_BinOp_CountsCorrectly()
    {
        // (2 + 3) → 1 BinOp, 2 Num
        var e = new BinOp(new Num(2), "+", new Num(3));
        var s = CollectStats(e);
        Assert.Equal(1, s.BinOpCount);
        Assert.Equal(2, s.NumCount);
        Assert.Equal(3, s.TotalNodes);
    }

    [Fact]
    public void Stats_Depth_CalculatedCorrectly()
    {
        // (a*a) + (b*b) → głębokość 2
        var e = new BinOp(
            new BinOp(new Var("a"), "*", new Var("a")),
            "+",
            new BinOp(new Var("b"), "*", new Var("b")));
        var s = CollectStats(e);
        Assert.Equal(2, s.Depth);
    }
}
