Console.WriteLine("=== Clean Architecture — Testowanie bez infrastruktury ===\n");

// ─────────────────────────────────────────────────────────────
// Prosta platforma testowa (bez xUnit — tylko demo w konsoli)
// ─────────────────────────────────────────────────────────────
int passed = 0, failed = 0;

void Test(string name, Action test)
{
    try
    {
        test();
        Console.WriteLine($"  [OK] {name}");
        passed++;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"  [FAIL] {name}: {ex.Message}");
        failed++;
    }
}

void Equal<T>(T expected, T actual, string? msg = null)
{
    if (!Equals(expected, actual))
        throw new Exception(msg ?? $"Oczekiwano '{expected}', ale było '{actual}'");
}

void Throws<TEx>(Action action, string? msg = null) where TEx : Exception
{
    try { action(); throw new Exception(msg ?? $"Oczekiwano wyjątku {typeof(TEx).Name}"); }
    catch (TEx) { }
}

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 1: Testy warstwy Domain — encje i niezmienniki
// ─────────────────────────────────────────────────────────────
Console.WriteLine("─── Testy Domain: BankAccount (encja) ───");

Test("Nowe konto ma saldo zero", () =>
{
    var account = new BankAccount(Guid.NewGuid(), "jan@email.com");
    Equal(0m, account.Balance);
});

Test("Wpłata zwiększa saldo", () =>
{
    var account = new BankAccount(Guid.NewGuid(), "jan@email.com");
    account.Deposit(new Money(500m));
    Equal(500m, account.Balance);
});

Test("Wypłata zmniejsza saldo", () =>
{
    var account = new BankAccount(Guid.NewGuid(), "jan@email.com");
    account.Deposit(new Money(1000m));
    account.Withdraw(new Money(300m));
    Equal(700m, account.Balance);
});

Test("Niezmiennik: wypłata ponad saldo — wyjątek", () =>
    Throws<InvalidOperationException>(() =>
    {
        var account = new BankAccount(Guid.NewGuid(), "jan@email.com");
        account.Deposit(new Money(100m));
        account.Withdraw(new Money(200m)); // overdraft!
    })
);

Test("Niezmiennik: ujemna wpłata — wyjątek", () =>
    Throws<ArgumentException>(() =>
    {
        var account = new BankAccount(Guid.NewGuid(), "jan@email.com");
        account.Deposit(new Money(-10m));
    })
);

Test("Value Object Money: równość przez wartość", () =>
{
    var m1 = new Money(100m);
    var m2 = new Money(100m);
    Equal(true, m1 == m2);
});

// ─────────────────────────────────────────────────────────────
// CZĘŚĆ 2: Testy Application — Use Cases z Fake/Stub
// ─────────────────────────────────────────────────────────────
Console.WriteLine("\n─── Testy Application: TransferFundsUseCase (z Fake) ───");

Test("Transfer: kwota przelana poprawnie", async () =>
{
    // Arrange — Fake zamiast prawdziwego repozytorium
    var fakeRepo = new FakeAccountRepository();
    var sender   = new BankAccount(Guid.NewGuid(), "jan@email.com");
    var receiver = new BankAccount(Guid.NewGuid(), "anna@email.com");
    sender.Deposit(new Money(1000m));
    await fakeRepo.AddAsync(sender);
    await fakeRepo.AddAsync(receiver);
    var fakeNotify = new FakeNotificationService();

    var uc = new TransferFundsUseCase(fakeRepo, fakeNotify);
    // Act
    await uc.ExecuteAsync(new TransferCommand(sender.Id, receiver.Id, new Money(400m)));
    // Assert
    var updatedSender   = await fakeRepo.FindByIdAsync(sender.Id);
    var updatedReceiver = await fakeRepo.FindByIdAsync(receiver.Id);
    Equal(600m, updatedSender!.Balance);
    Equal(400m, updatedReceiver!.Balance);
});

Test("Transfer: wysłano powiadomienie", async () =>
{
    var fakeRepo = new FakeAccountRepository();
    var sender   = new BankAccount(Guid.NewGuid(), "jan@email.com");
    var receiver = new BankAccount(Guid.NewGuid(), "anna@email.com");
    sender.Deposit(new Money(1000m));
    await fakeRepo.AddAsync(sender);
    await fakeRepo.AddAsync(receiver);
    var fakeNotify = new FakeNotificationService();

    var uc = new TransferFundsUseCase(fakeRepo, fakeNotify);
    await uc.ExecuteAsync(new TransferCommand(sender.Id, receiver.Id, new Money(100m)));

    Equal(1, fakeNotify.NotificationsSent);
});

Test("Transfer: błąd gdy nadawca nie istnieje", async () =>
{
    var fakeRepo   = new FakeAccountRepository();
    var fakeNotify = new FakeNotificationService();
    var uc = new TransferFundsUseCase(fakeRepo, fakeNotify);

    await Async(() =>
        Throws<InvalidOperationException>(async () =>
            await uc.ExecuteAsync(new TransferCommand(Guid.NewGuid(), Guid.NewGuid(), new Money(100m)))
        )
    );
});

Test("Transfer: błąd gdy za mało środków", async () =>
{
    var fakeRepo = new FakeAccountRepository();
    var sender   = new BankAccount(Guid.NewGuid(), "jan@email.com");
    var receiver = new BankAccount(Guid.NewGuid(), "anna@email.com");
    sender.Deposit(new Money(50m));
    await fakeRepo.AddAsync(sender);
    await fakeRepo.AddAsync(receiver);
    var fakeNotify = new FakeNotificationService();
    var uc = new TransferFundsUseCase(fakeRepo, fakeNotify);

    await Async(() =>
        Throws<InvalidOperationException>(async () =>
            await uc.ExecuteAsync(new TransferCommand(sender.Id, receiver.Id, new Money(100m)))
        )
    );
});

// Podsumowanie
Console.WriteLine($"\n=== Wyniki: {passed} OK, {failed} FAIL ===");
if (failed == 0)
    Console.WriteLine("Wszystkie testy przeszły pomyślnie!");

// ─────────────────────────────────────────────────────────────
// Pomocnik dla async Throws
// ─────────────────────────────────────────────────────────────
static async Task Async(Action action)
{
    await Task.Run(action);
}

// ═══════════════════════════════════════════════════════════
// TYPY
// ═══════════════════════════════════════════════════════════

// ── Value Object ─────────────────────────────────────────────

record Money(decimal Amount)
{
    public Money Add(Money other) => new(Amount + other.Amount);
    public Money Subtract(Money other) => new(Amount - other.Amount);
    public bool IsPositive => Amount > 0;
}

// ── Domain — encja BankAccount ───────────────────────────────

class BankAccount
{
    private decimal _balance;

    public Guid   Id    { get; }
    public string Owner { get; }

    public decimal Balance => _balance;

    public BankAccount(Guid id, string owner)
    {
        Id    = id;
        Owner = owner;
        _balance = 0m;
    }

    public void Deposit(Money amount)
    {
        if (amount.Amount <= 0)
            throw new ArgumentException("Kwota wpłaty musi być dodatnia");
        _balance += amount.Amount;
    }

    public void Withdraw(Money amount)
    {
        if (amount.Amount <= 0)
            throw new ArgumentException("Kwota wypłaty musi być dodatnia");
        if (amount.Amount > _balance)
            throw new InvalidOperationException($"Niewystarczające środki: saldo {_balance}, żądanie {amount.Amount}");
        _balance -= amount.Amount;
    }
}

// ── Porty (Application) ───────────────────────────────────────

interface IAccountRepository
{
    Task<BankAccount?> FindByIdAsync(Guid id);
    Task AddAsync(BankAccount account);
    Task SaveAsync(BankAccount account);
}

interface INotificationService
{
    Task NotifyAsync(string message);
}

// ── Komendy ───────────────────────────────────────────────────

record TransferCommand(Guid FromId, Guid ToId, Money Amount);

// ── Use Case ─────────────────────────────────────────────────

class TransferFundsUseCase(IAccountRepository repo, INotificationService notify)
{
    public async Task ExecuteAsync(TransferCommand cmd)
    {
        var sender = await repo.FindByIdAsync(cmd.FromId)
            ?? throw new InvalidOperationException($"Konto nadawcy {cmd.FromId} nie istnieje");
        var receiver = await repo.FindByIdAsync(cmd.ToId)
            ?? throw new InvalidOperationException($"Konto odbiorcy {cmd.ToId} nie istnieje");

        // Logika biznesowa w encjach — nie w Use Case!
        sender.Withdraw(cmd.Amount);
        receiver.Deposit(cmd.Amount);

        await repo.SaveAsync(sender);
        await repo.SaveAsync(receiver);

        await notify.NotifyAsync($"Przelew {cmd.Amount.Amount} PLN z {sender.Owner} do {receiver.Owner}");
    }
}

// ── Fake Infrastructure (do testów) ─────────────────────────

class FakeAccountRepository : IAccountRepository
{
    private readonly Dictionary<Guid, BankAccount> _db = [];

    public Task<BankAccount?> FindByIdAsync(Guid id)
    {
        _db.TryGetValue(id, out var acc);
        return Task.FromResult(acc);
    }

    public Task AddAsync(BankAccount account)
    {
        _db[account.Id] = account;
        return Task.CompletedTask;
    }

    public Task SaveAsync(BankAccount account)
    {
        _db[account.Id] = account;
        return Task.CompletedTask;
    }
}

class FakeNotificationService : INotificationService
{
    public int NotificationsSent { get; private set; }

    public Task NotifyAsync(string message)
    {
        NotificationsSent++;
        return Task.CompletedTask;
    }
}
