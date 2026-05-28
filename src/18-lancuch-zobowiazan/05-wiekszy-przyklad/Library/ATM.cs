namespace CoR.WiekszyPrzyklad;

// =============================================================================
// System wypłat bankomatowych — biblioteka współdzielona z testami
// =============================================================================

/// <summary>
/// Wynik operacji wypłaty — zbiera banknoty ze wszystkich ogniw łańcucha
/// </summary>
public class DispenseResult
{
    public Dictionary<int, int> Notes { get; } = new();
    public int Remaining              { get; private set; }
    public bool Success               { get; private set; }
    public string? ErrorMessage       { get; private set; }

    private DispenseResult() { }

    public static DispenseResult WithNote(int denomination, int count, int remaining)
    {
        var r = new DispenseResult { Remaining = remaining, Success = true };
        if (count > 0) r.Notes[denomination] = count;
        return r;
    }

    public static DispenseResult Failure(string message)
        => new() { Success = false, ErrorMessage = message };

    public static DispenseResult Empty(int remaining)
        => new() { Remaining = remaining, Success = true };

    public DispenseResult Merge(DispenseResult other)
    {
        if (!other.Success) return other;
        foreach (var (denom, count) in other.Notes)
            Notes[denom] = Notes.GetValueOrDefault(denom) + count;
        Remaining = other.Remaining;
        return this;
    }

    public int TotalAmount => Notes.Sum(x => x.Key * x.Value);
}

/// <summary>GoF Handler</summary>
public interface IDispenser
{
    IDispenser SetNext(IDispenser next);
    DispenseResult Dispense(int amount);
}

/// <summary>GoF BaseHandler</summary>
public abstract class BaseDispenser : IDispenser
{
    private IDispenser? _next;

    public int Denomination   { get; init; }
    public int AvailableCount { get; private set; }

    protected BaseDispenser(int denomination, int count)
    {
        Denomination   = denomination;
        AvailableCount = count;
    }

    public IDispenser SetNext(IDispenser next)
    {
        _next = next;
        return next;
    }

    public abstract DispenseResult Dispense(int amount);

    protected DispenseResult PassToNext(int amount)
        => _next?.Dispense(amount)
           ?? DispenseResult.Failure($"Nie można wydać {amount} zł — brak banknotów");

    protected bool TryDispenseNotes(int amount, out int count, out int remaining)
    {
        count     = Math.Min(amount / Denomination, AvailableCount);
        remaining = amount - count * Denomination;
        AvailableCount -= count;
        return count > 0;
    }

    public void Replenish(int count) => AvailableCount += count;
}

/// <summary>GoF ConcreteHandler — nominał x</summary>
public class NoteDispenser(int denomination, int count) : BaseDispenser(denomination, count)
{
    public override DispenseResult Dispense(int amount)
    {
        if (amount <= 0)
            return DispenseResult.Empty(0);

        TryDispenseNotes(amount, out int noteCount, out int remaining);

        var myResult = DispenseResult.WithNote(Denomination, noteCount, remaining);

        if (remaining > 0)
        {
            var nextResult = PassToNext(remaining);
            return myResult.Merge(nextResult);
        }

        return myResult;
    }
}

/// <summary>Null Object — zawsze zwraca błąd, kończy łańcuch</summary>
public class InsufficientFundsDispenser : IDispenser
{
    public IDispenser SetNext(IDispenser next) => next;

    public DispenseResult Dispense(int amount)
        => DispenseResult.Failure(
            $"Nie można wydać {amount} zł — niewystarczająca ilość banknotów w kasie");
}

/// <summary>Fasada nad łańcuchem dyspenserów</summary>
public class ATM
{
    private readonly NoteDispenser[] _dispensers;

    public ATM(Dictionary<int, int> denominationsAndCounts)
    {
        _dispensers = denominationsAndCounts
            .OrderByDescending(kv => kv.Key)
            .Select(kv => new NoteDispenser(kv.Key, kv.Value))
            .ToArray();

        for (int i = 0; i < _dispensers.Length - 1; i++)
            _dispensers[i].SetNext(_dispensers[i + 1]);

        _dispensers[_dispensers.Length - 1].SetNext(new InsufficientFundsDispenser());
    }

    public DispenseResult Withdraw(int amount)
    {
        if (amount <= 0)
            return DispenseResult.Failure("Kwota musi być większa od zera");
        if (amount % 10 != 0)
            return DispenseResult.Failure($"Kwota {amount} zł musi być wielokrotnością 10 zł");
        return _dispensers[0].Dispense(amount);
    }

    public void Replenish(int denomination, int count)
        => _dispensers.FirstOrDefault(d => d.Denomination == denomination)?.Replenish(count);

    public int GetAvailable(int denomination)
        => _dispensers.FirstOrDefault(d => d.Denomination == denomination)?.AvailableCount ?? 0;
}
