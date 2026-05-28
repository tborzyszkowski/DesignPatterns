using CoR.WiekszyPrzyklad;
using Xunit;

namespace CoR.WiekszyPrzyklad.Tests;

// =============================================================================
// Testy jednostkowe — System bankomatowy (CoR)
// Uruchamianie: cd Tests && dotnet test
// =============================================================================

public class NoteDispenserTests
{
    [Theory]
    [InlineData(200, 200, 1)]
    [InlineData(200, 400, 2)]
    public void Dispense_ExactAmount_ShouldReturnCorrectNoteCount(
        int denomination, int amount, int expectedCount)
    {
        // Arrange — kwota dokładna, bez reszty
        var dispenser = new NoteDispenser(denomination, 10);
        dispenser.SetNext(new InsufficientFundsDispenser());

        // Act
        var result = dispenser.Dispense(amount);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(expectedCount, result.Notes.GetValueOrDefault(denomination));
    }

    [Fact]
    public void Dispense_WithRemainder_PassesToNext()
    {
        // Arrange — 200+50 — dwa ogniwa
        var d200 = new NoteDispenser(200, 10);
        var d50  = new NoteDispenser(50, 10);
        d200.SetNext(d50);
        d50.SetNext(new InsufficientFundsDispenser());

        // Act
        var result = d200.Dispense(250);

        // Assert
        Assert.True(result.Success);
        Assert.Equal(1, result.Notes[200]);
        Assert.Equal(1, result.Notes[50]);
    }

    [Fact]
    public void Dispense_WhenAmountZero_ReturnsEmpty()
    {
        var dispenser = new NoteDispenser(100, 10);
        var result = dispenser.Dispense(0);

        Assert.True(result.Success);
        Assert.Empty(result.Notes);
    }

    [Fact]
    public void Dispense_WhenInsufficientNotes_UsesNextHandler()
    {
        // Arrange — tylko 1 banknot 200, reszta idzie do InsufficientFunds
        var dispenser = new NoteDispenser(200, 1);
        dispenser.SetNext(new InsufficientFundsDispenser());

        // Act — żądamy 400, mamy tylko 1×200 = wydamy 200, reszta 200 nie do wypłacenia
        var result = dispenser.Dispense(400);

        // Assert
        Assert.False(result.Success);
        Assert.Contains("200", result.ErrorMessage);
    }

    [Fact]
    public void Replenish_ShouldIncreaseAvailableCount()
    {
        var dispenser = new NoteDispenser(100, 5);
        dispenser.Replenish(10);

        Assert.Equal(15, dispenser.AvailableCount);
    }
}

public class ChainIntegrationTests
{
    private ATM CreateFullATM() => new(new()
    {
        [200] = 10,
        [100] = 20,
        [50]  = 20,
        [20]  = 50,
        [10]  = 100
    });

    [Theory]
    [InlineData(380, true,  new[] { 200, 1, 100, 1, 50, 1, 20, 1, 10, 1 })]
    [InlineData(250, true,  new[] { 200, 1, 50, 1 })]
    [InlineData(10,  true,  new[] { 10, 1 })]
    [InlineData(200, true,  new[] { 200, 1 })]
    public void Withdraw_ShouldUseOptimalNotes(
        int amount, bool expectedSuccess, int[] notesFlat)
    {
        // Arrange
        var atm = CreateFullATM();
        var expectedNotes = ParseNotesFlat(notesFlat);

        // Act
        var result = atm.Withdraw(amount);

        // Assert
        Assert.Equal(expectedSuccess, result.Success);
        if (expectedSuccess)
        {
            Assert.Equal(amount, result.TotalAmount);
            foreach (var (denom, count) in expectedNotes)
                Assert.Equal(count, result.Notes.GetValueOrDefault(denom));
        }
    }

    [Theory]
    [InlineData(0,   "większa od zera")]
    [InlineData(-50, "większa od zera")]
    [InlineData(15,  "wielokrotnością")]
    [InlineData(25,  "wielokrotnością")]
    public void Withdraw_InvalidAmount_ShouldFail(int amount, string expectedMessageFragment)
    {
        var atm = CreateFullATM();
        var result = atm.Withdraw(amount);

        Assert.False(result.Success);
        Assert.Contains(expectedMessageFragment, result.ErrorMessage);
    }

    [Fact]
    public void Withdraw_WhenInsufficientFunds_ShouldFail()
    {
        var atm = new ATM(new() { [200] = 1, [100] = 0, [50] = 0, [20] = 0, [10] = 0 });

        var result = atm.Withdraw(500);

        Assert.False(result.Success);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public void Withdraw_ShouldDecrementAvailableNotes()
    {
        var atm = new ATM(new() { [200] = 2, [100] = 0, [50] = 0, [20] = 0, [10] = 0 });

        atm.Withdraw(200);

        Assert.Equal(1, atm.GetAvailable(200));
    }

    [Fact]
    public void Replenish_ShouldAllowWithdrawAfterEmpty()
    {
        var atm = new ATM(new() { [100] = 1, [50] = 0, [20] = 0, [10] = 0, [200] = 0 });

        var first = atm.Withdraw(100);
        Assert.True(first.Success);

        var second = atm.Withdraw(100);
        Assert.False(second.Success);

        atm.Replenish(100, 5);
        var third = atm.Withdraw(100);
        Assert.True(third.Success);
    }

    [Fact]
    public void Withdraw_PreferLargerDenominations()
    {
        // Przy wypłacie 200 powinien użyć 1×200, nie 2×100
        var atm = CreateFullATM();
        var result = atm.Withdraw(200);

        Assert.True(result.Success);
        Assert.Equal(1, result.Notes.GetValueOrDefault(200));
        Assert.False(result.Notes.ContainsKey(100));
    }

    private static Dictionary<int, int> ParseNotesFlat(int[] flat)
    {
        var d = new Dictionary<int, int>();
        for (int i = 0; i < flat.Length; i += 2)
            d[flat[i]] = flat[i + 1];
        return d;
    }
}

public class InsufficientFundsDispenserTests
{
    [Fact]
    public void Dispense_AlwaysReturnsFailure()
    {
        var dispenser = new InsufficientFundsDispenser();
        var result    = dispenser.Dispense(100);

        Assert.False(result.Success);
        Assert.NotNull(result.ErrorMessage);
    }

    [Fact]
    public void SetNext_ReturnsNext()
    {
        var dispenser = new InsufficientFundsDispenser();
        var next      = new NoteDispenser(10, 10);

        var returned = dispenser.SetNext(next);

        Assert.Same(next, returned);
    }
}
