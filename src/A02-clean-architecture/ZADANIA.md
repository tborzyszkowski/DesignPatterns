# Zadania — Clean Architecture

## Zadanie 1: Sklep muzyczny — Use Case „Dodaj utwór"

Zaimplementuj Use Case `DodajUtworCommand` dla uproszczonego serwisu muzycznego.

**Wymagania:**
- Encja `Utwor` z polami: `Id`, `Tytul`, `Artysta`, `CzasTrwaniaSekundy`, `Gatunek`
- Reguła biznesowa: utwór musi mieć tytuł i artystę; czas trwania musi być z zakresu 10–3600 sekund
- Interfejs `IUtworRepository` z metodami `Save` i `FindById`
- Use Case `DodajUtworUseCase` zależny od interfejsu (nie implementacji)
- Implementacja in-memory repozytorium

**Pytania do weryfikacji:**
- Gdzie powinien być zdefiniowany interfejs `IUtworRepository`: w Domain czy Application?
- Jak sprawdzić, że Use Case działa poprawnie bez użycia bazy danych?

<details>
<summary>Rozwiązanie i wyjaśnienie</summary>

```csharp
// ── Warstwa Domain ──────────────────────────────────────────
public record UtworId(Guid Value) { public static UtworId New() => new(Guid.NewGuid()); }

public class Utwor
{
    public UtworId Id { get; }
    public string Tytul { get; private set; }
    public string Artysta { get; private set; }
    public int CzasTrwaniaSekundy { get; private set; }
    public string Gatunek { get; private set; }

    public Utwor(UtworId id, string tytul, string artysta, int czas, string gatunek)
    {
        if (string.IsNullOrWhiteSpace(tytul))  throw new ArgumentException("Tytuł wymagany");
        if (string.IsNullOrWhiteSpace(artysta)) throw new ArgumentException("Artysta wymagany");
        if (czas < 10 || czas > 3600)           throw new ArgumentException("Czas: 10–3600 s");
        Id = id; Tytul = tytul; Artysta = artysta; CzasTrwaniaSekundy = czas; Gatunek = gatunek;
    }
}

// ── Warstwa Application ─────────────────────────────────────
public interface IUtworRepository
{
    void Save(Utwor u);
    Utwor? FindById(UtworId id);
}

public record DodajUtworCommand(string Tytul, string Artysta, int CzasTrwania, string Gatunek);

public class DodajUtworUseCase(IUtworRepository repo)
{
    public Utwor Execute(DodajUtworCommand cmd)
    {
        var u = new Utwor(UtworId.New(), cmd.Tytul, cmd.Artysta, cmd.CzasTrwania, cmd.Gatunek);
        repo.Save(u);
        return u;
    }
}

// ── Warstwa Infrastructure ───────────────────────────────────
public class InMemoryUtworRepository : IUtworRepository
{
    private Dictionary<Guid, Utwor> _db = new();
    public void Save(Utwor u) => _db[u.Id.Value] = u;
    public Utwor? FindById(UtworId id) => _db.TryGetValue(id.Value, out var u) ? u : null;
}

// ── Program (Composition Root) ───────────────────────────────
var repo = new InMemoryUtworRepository();
var uc = new DodajUtworUseCase(repo);
var u = uc.Execute(new DodajUtworCommand("Bohemian Rhapsody", "Queen", 354, "Rock"));
Console.WriteLine($"Dodano: {u.Tytul} — {u.Artysta} ({u.CzasTrwaniaSekundy}s)");
```

**Wyjaśnienie:** Interfejs `IUtworRepository` należy do warstwy Application (nie Domain), ponieważ to Use Cases go używają. Domain zawiera tylko encję `Utwor` z regułami biznesowymi. Infrastructure dostarcza implementację — Use Case tego nie widzi.

</details>

---

## Zadanie 2: Refaktoryzacja N-Tier do Clean Architecture

Masz klasyczny kod N-Tier z silnym sprzężeniem:

```csharp
// PRZED refaktoryzacją — wszystko w jednej warstwie
class ProductService
{
    private SqlConnection _db = new("Server=prod;Database=shop");

    public Product? GetProduct(int id)
    {
        _db.Open();
        var cmd = new SqlCommand($"SELECT * FROM Products WHERE Id={id}", _db);
        var reader = cmd.ExecuteReader();
        // ...brak walidacji SQL injection!
        _db.Close();
        return null; // uproszczenie
    }

    public void CreateProduct(string name, decimal price)
    {
        if (price <= 0) throw new Exception("Cena musi być dodatnia");
        _db.Open();
        var cmd = new SqlCommand(
            $"INSERT INTO Products (Name, Price) VALUES ('{name}', {price})", _db);
        cmd.ExecuteNonQuery();
        Console.WriteLine($"Email: Nowy produkt {name} dodany!"); // ścisłe sprzężenie do emaila
        _db.Close();
    }
}
```

**Zadanie:** Rozdziel ten kod na warstwy Clean Architecture. Zidentyfikuj:
- Co należy do Domain (encje, reguły biznesowe)?
- Co należy do Application (Use Cases, interfejsy)?
- Co należy do Infrastructure (implementacje)?

<details>
<summary>Rozwiązanie i wyjaśnienie</summary>

```csharp
// ── Warstwa Domain ──────────────────────────────────────────
public class Product
{
    public Guid Id { get; }
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Product(Guid id, string name, decimal price)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Nazwa wymagana");
        if (price <= 0) throw new ArgumentException("Cena musi być dodatnia");
        Id = id; Name = name; Price = price;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice <= 0) throw new ArgumentException("Cena musi być dodatnia");
        Price = newPrice;
    }
}

// ── Warstwa Application ─────────────────────────────────────
public interface IProductRepository
{
    void Save(Product p);
    Product? FindById(Guid id);
}

public interface INotificationService
{
    void Notify(string message);
}

public class CreateProductUseCase(IProductRepository repo, INotificationService notify)
{
    public Product Execute(string name, decimal price)
    {
        var p = new Product(Guid.NewGuid(), name, price);
        repo.Save(p);
        notify.Notify($"Nowy produkt: {name}");
        return p;
    }
}

// ── Warstwa Infrastructure ───────────────────────────────────
// Adapter 1: repozytorium (zamiast SqlConnection)
public class InMemoryProductRepository : IProductRepository
{
    private Dictionary<Guid, Product> _db = new();
    public void Save(Product p) => _db[p.Id] = p;
    public Product? FindById(Guid id) => _db.TryGetValue(id, out var p) ? p : null;
}

// Adapter 2: powiadomienia (zamiast Console.WriteLine w logice biznesowej)
public class EmailNotificationService : INotificationService
{
    public void Notify(string message) => Console.WriteLine($"[SMTP] {message}");
}
```

**Wyjaśnienie:** Kluczowe zmiany:
1. **Reguły biznesowe** (walidacja ceny) przeniesione do encji `Product` w Domain
2. **Interfejsy** `IProductRepository` i `INotificationService` zdefiniowane w Application
3. **Implementacje** (`InMemoryProductRepository`, `EmailNotificationService`) w Infrastructure
4. **Brak SQL injection** — parametryzacja w Infrastructure, nie w Domain
5. **Testowalność** — można testować `CreateProductUseCase` bez bazy danych i SMTP

</details>

---

## Zadanie 3: Testy jednostkowe bez bazy danych

Napisz minimum 4 testy jednostkowe dla poniższego Use Case, używając tylko obiektów in-memory (bez xUnit — wystarczy asercja ręczna lub użyj xUnit):

```csharp
public class TransferFundsUseCase(IAccountRepository accounts)
{
    public void Execute(Guid fromId, Guid toId, decimal amount)
    {
        var from = accounts.FindById(fromId)
            ?? throw new InvalidOperationException("Konto źródłowe nie istnieje");
        var to = accounts.FindById(toId)
            ?? throw new InvalidOperationException("Konto docelowe nie istnieje");
        from.Debit(amount);
        to.Credit(amount);
        accounts.Save(from);
        accounts.Save(to);
    }
}
```

**Scenariusze do przetestowania:**
1. Transfer poprawny — konta zaktualizowane
2. Niewystarczające środki — wyjątek z `Debit`
3. Konto źródłowe nie istnieje — wyjątek
4. Kwota zerowa lub ujemna — wyjątek

<details>
<summary>Rozwiązanie i wyjaśnienie</summary>

```csharp
// Encja Account z regułami biznesowymi
public class Account
{
    public Guid Id { get; }
    public decimal Balance { get; private set; }
    public Account(Guid id, decimal initialBalance) { Id = id; Balance = initialBalance; }
    public void Debit(decimal amount) {
        if (amount <= 0) throw new ArgumentException("Kwota musi być dodatnia");
        if (Balance < amount) throw new InvalidOperationException("Niewystarczające środki");
        Balance -= amount;
    }
    public void Credit(decimal amount) {
        if (amount <= 0) throw new ArgumentException("Kwota musi być dodatnia");
        Balance += amount;
    }
}

public interface IAccountRepository { Account? FindById(Guid id); void Save(Account a); }

// Fake repozytorium (stub)
public class FakeAccountRepository : IAccountRepository
{
    private Dictionary<Guid, Account> _db = new();
    public FakeAccountRepository(params Account[] accounts)
        => Array.ForEach(accounts, a => _db[a.Id] = a);
    public Account? FindById(Guid id) => _db.TryGetValue(id, out var a) ? a : null;
    public void Save(Account a) => _db[a.Id] = a;
}

// Testy
void Assert(bool condition, string msg) {
    if (!condition) throw new Exception($"FAIL: {msg}");
    Console.WriteLine($"PASS: {msg}");
}

// Test 1: poprawny transfer
{
    var a1 = new Account(Guid.NewGuid(), 1000m);
    var a2 = new Account(Guid.NewGuid(), 500m);
    var repo = new FakeAccountRepository(a1, a2);
    new TransferFundsUseCase(repo).Execute(a1.Id, a2.Id, 300m);
    Assert(a1.Balance == 700m, "Konto źródłowe: 1000-300=700");
    Assert(a2.Balance == 800m, "Konto docelowe: 500+300=800");
}

// Test 2: niewystarczające środki
{
    var a1 = new Account(Guid.NewGuid(), 100m);
    var a2 = new Account(Guid.NewGuid(), 0m);
    var repo = new FakeAccountRepository(a1, a2);
    try { new TransferFundsUseCase(repo).Execute(a1.Id, a2.Id, 200m); Assert(false, "Nie rzucił wyjątku"); }
    catch (InvalidOperationException) { Assert(true, "Niewystarczające środki — wyjątek"); }
}

// Test 3: konto nie istnieje
{
    var repo = new FakeAccountRepository();
    try { new TransferFundsUseCase(repo).Execute(Guid.NewGuid(), Guid.NewGuid(), 100m); }
    catch (InvalidOperationException) { Assert(true, "Brak konta — wyjątek"); }
}

// Test 4: kwota zerowa
{
    var a1 = new Account(Guid.NewGuid(), 500m);
    var a2 = new Account(Guid.NewGuid(), 0m);
    var repo = new FakeAccountRepository(a1, a2);
    try { new TransferFundsUseCase(repo).Execute(a1.Id, a2.Id, 0m); }
    catch (ArgumentException) { Assert(true, "Kwota zerowa — wyjątek"); }
}
```

**Wyjaśnienie:** Kluczem jest `FakeAccountRepository` — dzięki temu testujemy **tylko logikę Use Case** bez żadnej infrastruktury. To możliwe dlatego, że `TransferFundsUseCase` zależy od interfejsu `IAccountRepository`, a nie od konkretnej implementacji.

</details>

---

## Zadanie 4: Zaprojektuj architekturę systemu rezerwacji sal

Zaprojektuj Clean Architecture dla uproszczonego systemu rezerwacji sal konferencyjnych.

**Wymagania biznesowe:**
- Sale konferencyjne mają pojemność i dostępne godziny
- Użytkownicy mogą rezerwować salę na określony czas
- Nie można dokonać dwóch rezerwacji tej samej sali w pokrywającym się czasie
- Po dokonaniu rezerwacji wysyłane jest powiadomienie e-mail

**Zadanie:** Narysuj diagram warstw (lub opisz słownie):
- Jakie klasy/interfejsy znajdą się w każdej warstwie?
- Jakie są granice odpowiedzialności?
- Gdzie zdefiniować interfejsy, a gdzie implementacje?

<details>
<summary>Propozycja rozwiązania</summary>

**Warstwa Domain:**
```
- Sala (encja): Id, Nazwa, Pojemnosc, GodzinyOtwarcia
- Rezerwacja (encja): Id, SalaId, UzytkownikId, OdGodziny, DoGodziny
- RezerwacjaId (value object)
- SalaId (value object)
- Reguła biznesowa: Sala.CzyDostepna(od, do) — sprawdza konflikty
- DomainException: SalaNiedostepnaException
```

**Warstwa Application:**
```
- IRejestrSal (interfejs repozytorium)
- IRejestRezerwacji (interfejs repozytorium)
- IEmailService (port powiadomień)
- ZarezerwujSaleUseCase — sprawdza dostępność, tworzy rezerwację, wysyła email
- PobierzDostepneSaleUseCase — zwraca wolne sale w danym czasie
- AnulujRezerwacjeUseCase
- RezerwacjaDto, SalaDto (DTOs)
```

**Warstwa Infrastructure:**
```
- InMemoryRejestrSal (implementacja IRejestrSal)
- InMemoryRejestRezerwacji (implementacja IRejestRezerwacji)
- SmtpEmailService (implementacja IEmailService)
- (docelowo: EFCore repositories)
```

**Warstwa Presentation / Composition Root:**
```
- Program.cs / Startup.cs — konfiguracja DI
- SalaController (jeśli ASP.NET Core)
- CLI interface (dla przykładu konsolowego)
```

**Kluczowa reguła konfliktu rezerwacji w Domain:**

```csharp
public class Sala
{
    private List<Rezerwacja> _rezerwacje = [];

    public bool CzyDostepna(DateTime od, DateTime do) =>
        !_rezerwacje.Any(r =>
            r.Status != StatusRezerwacji.Anulowana &&
            od < r.DoGodziny && do > r.OdGodziny);  // overlap check

    public Rezerwacja Zarezerwuj(Guid uzytkownikId, DateTime od, DateTime do)
    {
        if (!CzyDostepna(od, do))
            throw new SalaNiedostepnaException(Id, od, do);
        var rez = new Rezerwacja(RezerwacjaId.New(), Id, uzytkownikId, od, do);
        _rezerwacje.Add(rez);
        return rez;
    }
}
```

</details>
