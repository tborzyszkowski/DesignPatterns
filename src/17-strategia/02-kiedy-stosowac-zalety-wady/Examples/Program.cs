// =============================================================================
// Wzorzec Strategia — 02. Kiedy stosować, zalety i wady
// Demonstruje: sygnały stosowania, warianty implementacji, porównanie
// =============================================================================

// ─── CZĘŚĆ 1: Sygnał #1 — eksplozja warunków w klasie płatności ──────────────

Console.WriteLine("═══ CZĘŚĆ 1: Zapach kodu — klasa przed refaktoryzacją ═══\n");

var badPayment = new BadPaymentProcessor();
Console.WriteLine(badPayment.Process("CARD", 100m));
Console.WriteLine(badPayment.Process("PAYPAL", 250m));
Console.WriteLine(badPayment.Process("CRYPTO", 999m)); // nie obsługiwane!

// ─── CZĘŚĆ 2: Po refaktoryzacji do Strategii ─────────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 2: Po refaktoryzacji — wzorzec Strategia ═══\n");

PaymentContext payment = new(new CreditCardStrategy("4111-1111-1111-1111"));
Console.WriteLine(payment.Pay(100m));

payment.SetStrategy(new PayPalStrategy("user@example.com"));
Console.WriteLine(payment.Pay(250m));

payment.SetStrategy(new BankTransferStrategy("PL61109010140000071219812874"));
Console.WriteLine(payment.Pay(1500m));

// ─── CZĘŚĆ 3: Sygnał #2 — podmiana algorytmu w runtime ───────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 3: Podmiana strategii kompresji w runtime ═══\n");

var compressor = new Compressor(new GzipStrategy());
byte[] data = [1, 2, 3, 4, 5, 6, 7, 8];

Console.WriteLine(compressor.Compress(data));

compressor.SetStrategy(new ZipStrategy());
Console.WriteLine(compressor.Compress(data));

compressor.SetStrategy(new NoCompressionStrategy());
Console.WriteLine(compressor.Compress(data));

// ─── CZĘŚĆ 4: Wariant 1 — interfejs (standardowy GoF) ────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 4: Wariant 1 — strategia jako interfejs ═══\n");

IDiscountStrategy[] strategies = [
    new NoDiscount(),
    new PercentageDiscount(10),
    new SeasonalDiscount(25),
];

decimal price = 1000m;
foreach (var s in strategies)
    Console.WriteLine($"  {s.GetType().Name,25}: {s.Apply(price):C}");

// ─── CZĘŚĆ 5: Wariant 2 — klasa abstrakcyjna z logiką wspólną ────────────────

Console.WriteLine("\n═══ CZĘŚĆ 5: Wariant 2 — abstrakcyjna klasa bazowa ═══\n");

AbstractTaxStrategy[] taxStrategies = [
    new PolishTaxStrategy(),
    new GermanTaxStrategy(),
    new ZeroTaxStrategy(),
];

decimal netAmount = 1000m;
foreach (var t in taxStrategies)
{
    var result = t.Calculate(netAmount);
    Console.WriteLine($"  {t.GetType().Name,20}: brutto={result:C} (log: {t.LastLog})");
}

// ─── CZĘŚĆ 6: Wariant 3 — Func<> jako strategia ──────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 6: Wariant 3 — strategia jako Func<> (lambda) ═══\n");

Func<decimal, decimal>[] discountFuncs = [
    price => price,                           // brak rabatu
    price => price * 0.9m,                    // -10%
    price => price > 500m ? price * 0.8m : price, // progowy
];

foreach (var fn in discountFuncs)
    Console.WriteLine($"  {fn(800m):C}");

// ─── CZĘŚĆ 7: Wariant 4 — enum + słownik-fabryka ─────────────────────────────

Console.WriteLine("\n═══ CZĘŚĆ 7: Wariant 4 — enum + słownik-fabryka ═══\n");

var exporter = new ReportExporterFactory();
foreach (ExportFormat fmt in Enum.GetValues<ExportFormat>())
    Console.WriteLine($"  {fmt}: {exporter.Export("MójRaport", fmt)}");

// =============================================================================
// IMPLEMENTACJE
// =============================================================================

// ─── Zapach kodu — przed refaktoryzacją ──────────────────────────────────────

class BadPaymentProcessor
{
    public string Process(string method, decimal amount)
    {
        if (method == "CARD")
            return $"Płatność kartą: {amount:C}";
        else if (method == "PAYPAL")
            return $"Płatność PayPal: {amount:C}";
        else if (method == "BANK")
            return $"Przelew bankowy: {amount:C}";
        // każda nowa metoda = modyfikacja tej klasy!
        return $"Nieznana metoda: {method}";
    }
}

// ─── Wariant 1: Interfejs — płatności ────────────────────────────────────────

interface IPaymentStrategy
{
    string Pay(decimal amount);
}

class CreditCardStrategy(string cardNumber) : IPaymentStrategy
{
    public string Pay(decimal amount)
        => $"[CARD] Obciążono {cardNumber[..4]}**** kwotą {amount:C}";
}

class PayPalStrategy(string email) : IPaymentStrategy
{
    public string Pay(decimal amount)
        => $"[PAYPAL] Wysłano {amount:C} z {email}";
}

class BankTransferStrategy(string iban) : IPaymentStrategy
{
    public string Pay(decimal amount)
        => $"[BANK] Przelew {amount:C} na {iban[..10]}...";
}

class PaymentContext(IPaymentStrategy strategy)
{
    private IPaymentStrategy _strategy = strategy;
    public void SetStrategy(IPaymentStrategy s) => _strategy = s;
    public string Pay(decimal amount) => _strategy.Pay(amount);
}

// ─── Wariant 1: Interfejs — kompresja ────────────────────────────────────────

interface ICompressionStrategy
{
    string Compress(byte[] data);
}

class GzipStrategy : ICompressionStrategy
{
    public string Compress(byte[] data) => $"[GZIP] Skompresowano {data.Length}B → ~{data.Length / 3}B";
}

class ZipStrategy : ICompressionStrategy
{
    public string Compress(byte[] data) => $"[ZIP] Skompresowano {data.Length}B → ~{data.Length / 2}B";
}

class NoCompressionStrategy : ICompressionStrategy
{
    public string Compress(byte[] data) => $"[NONE] Brak kompresji, {data.Length}B";
}

class Compressor(ICompressionStrategy strategy)
{
    private ICompressionStrategy _strategy = strategy;
    public void SetStrategy(ICompressionStrategy s) => _strategy = s;
    public string Compress(byte[] data) => _strategy.Compress(data);
}

// ─── Wariant 1: Interfejs — rabaty ───────────────────────────────────────────

interface IDiscountStrategy
{
    decimal Apply(decimal price);
}

class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price;
}

class PercentageDiscount(decimal percent) : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * (1 - percent / 100);
}

class SeasonalDiscount(decimal percent) : IDiscountStrategy
{
    // Dodatkowa logika: sprawdzenie miesiąca (uproszczone)
    public decimal Apply(decimal price) => price * (1 - percent / 100);
}

// ─── Wariant 2: Klasa abstrakcyjna z logiką wspólną ──────────────────────────

abstract class AbstractTaxStrategy
{
    public string LastLog { get; private set; } = "";

    // Wspólna logika w klasie bazowej
    public decimal Calculate(decimal netAmount)
    {
        var tax = GetTaxRate();
        var gross = netAmount * (1 + tax);
        LastLog = $"netto={netAmount:C}, stawka={tax:P0}";
        return gross;
    }

    // Różna część — w podklasach
    protected abstract decimal GetTaxRate();
}

class PolishTaxStrategy : AbstractTaxStrategy
{
    protected override decimal GetTaxRate() => 0.23m; // VAT 23%
}

class GermanTaxStrategy : AbstractTaxStrategy
{
    protected override decimal GetTaxRate() => 0.19m; // MwSt 19%
}

class ZeroTaxStrategy : AbstractTaxStrategy
{
    protected override decimal GetTaxRate() => 0m;
}

// ─── Wariant 4: Enum + słownik-fabryka ───────────────────────────────────────

enum ExportFormat { Json, Csv, Xml }

class ReportExporterFactory
{
    private readonly Dictionary<ExportFormat, Func<string, string>> _exporters = new()
    {
        [ExportFormat.Json] = name => $"{{\"report\":\"{name}\"}}",
        [ExportFormat.Csv] = name => $"name\r\n{name}",
        [ExportFormat.Xml] = name => $"<report><name>{name}</name></report>",
    };

    public string Export(string reportName, ExportFormat format)
        => _exporters.TryGetValue(format, out var fn)
            ? fn(reportName)
            : throw new ArgumentException($"Nieznany format: {format}");
}
