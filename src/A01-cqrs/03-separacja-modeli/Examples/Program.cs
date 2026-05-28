// ============================================================
// Temat 03 — Separacja modeli Write/Read
// Pokazuje: bogaty Write Model, lekkie Read Model DTO,
//           projekcje do różnych widoków
// ============================================================

Console.WriteLine("=== CQRS — Separacja modeli Write/Read ===\n");

var baza = new InMemoryBaza();
var commandSide = new ZamowienieCommandSide(baza);
var querySide   = new ZamowienieQuerySide(baza);

// ─── Write Side — bogata domena ───────────────────────────
Console.WriteLine("─── Write Side: Komendy z logiką biznesową ───");

var klient1 = Guid.NewGuid();
var klient2 = Guid.NewGuid();

var zam1 = commandSide.ZlozZamowienie(klient1, "Jan Kowalski");
commandSide.DodajPozycje(zam1, "Laptop Pro", 1, 4500m);
commandSide.DodajPozycje(zam1, "Mysz bezprzewodowa", 2, 99m);
commandSide.PotwierdzzZamowienie(zam1);

var zam2 = commandSide.ZlozZamowienie(klient2, "Anna Nowak");
commandSide.DodajPozycje(zam2, "Monitor 4K", 1, 2200m);
// zam2 nie jest potwierdzone

Console.WriteLine($"Zamówienie {zam1.ToString()[..8]} — potwierdzone");
Console.WriteLine($"Zamówienie {zam2.ToString()[..8]} — oczekujące");

// Próba zmiany potwierdzonego zamówienia
Console.WriteLine("\nPróba dodania pozycji do potwierdzonego zamówienia:");
try
{
    commandSide.DodajPozycje(zam1, "Klawiatura", 1, 199m);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Błąd (oczekiwany): {ex.Message}");
}

// ─── Read Side — różne projekcje ──────────────────────────
Console.WriteLine("\n─── Read Side: Różne DTO dla różnych widoków ───");

Console.WriteLine("\nWidok listy (ZamowienieListaDto):");
foreach (var dto in querySide.PobierzListe())
{
    Console.WriteLine($"  Nr {dto.NumerZamowienia,-8} | {dto.KlientNazwa,-15} | {dto.Wartosc,10} | {dto.Status}");
}

Console.WriteLine("\nWidok szczegółów zamówienia 1:");
var szczegoly = querySide.PobierzSzczegoly(zam1);
if (szczegoly != null)
{
    Console.WriteLine($"  Klient:    {szczegoly.KlientNazwa}");
    Console.WriteLine($"  Status:    {szczegoly.Status}");
    Console.WriteLine($"  Pozycje:");
    foreach (var poz in szczegoly.Pozycje)
        Console.WriteLine($"    {poz.Nazwa,-25} x{poz.Ilosc}  {poz.Wartosc}");
    Console.WriteLine($"  Razem:     {szczegoly.Wartosc}");
}

Console.WriteLine("\nRaport sprzedaży wg kategorii (SprzedazDto):");
var raport = querySide.RaportSprzedazy();
foreach (var r in raport)
    Console.WriteLine($"  Status: {r.Status,-12} | Liczba: {r.LiczbaZamowien,3} | Wartość: {r.Wartosc}");

// ─── Podsumowanie separacji ───────────────────────────────
Console.WriteLine("\n─── Kluczowe różnice ───");
Console.WriteLine("Write Model: Chroni niezmienniki, private pola, metody domenowe");
Console.WriteLine("Read Model:  Płaskie DTO, gotowe do wyświetlenia, kilka widoków na te same dane");
Console.WriteLine("Projekcja:   Mapowanie Write → Read przy każdym zapytaniu (tu: in-memory)");

// ============================================================
// TYPY
// ============================================================

// ── Write Model — bogata domena ──────────────────────────────
enum StatusZamowienia { Oczekujace, Potwierdzone, Anulowane }

class PozycjaZamowienia
{
    public string Nazwa      { get; init; } = "";
    public int    Ilosc      { get; init; }
    public decimal CenaJedn  { get; init; }
    public decimal Wartosc   => Ilosc * CenaJedn;
}

class ZamowienieAggregate
{
    public Guid              Id          { get; } = Guid.NewGuid();
    public Guid              KlientId    { get; private set; }
    public string            KlientNazwa { get; private set; } = "";
    public int               Numer       { get; private set; }
    public DateTime          DataZlozenia{ get; private set; }
    public StatusZamowienia  Status      { get; private set; } = StatusZamowienia.Oczekujace;

    private readonly List<PozycjaZamowienia> _pozycje = [];
    public IReadOnlyList<PozycjaZamowienia> Pozycje => _pozycje.AsReadOnly();
    public decimal Wartosc => _pozycje.Sum(p => p.Wartosc);

    public ZamowienieAggregate(Guid klientId, string klientNazwa, int numer)
    {
        KlientId = klientId; KlientNazwa = klientNazwa;
        Numer = numer; DataZlozenia = DateTime.UtcNow;
    }

    public void DodajPozycje(string nazwa, int ilosc, decimal cenaJedn)
    {
        if (Status != StatusZamowienia.Oczekujace)
            throw new InvalidOperationException("Można dodawać pozycje tylko do oczekujących zamówień");
        if (ilosc <= 0) throw new ArgumentException("Ilość musi być dodatnia");
        if (cenaJedn <= 0) throw new ArgumentException("Cena musi być dodatnia");
        _pozycje.Add(new PozycjaZamowienia { Nazwa = nazwa, Ilosc = ilosc, CenaJedn = cenaJedn });
    }

    public void Potwierdz()
    {
        if (Status != StatusZamowienia.Oczekujace)
            throw new InvalidOperationException("Można potwierdzić tylko oczekujące zamówienie");
        if (!_pozycje.Any()) throw new InvalidOperationException("Zamówienie musi mieć pozycje");
        Status = StatusZamowienia.Potwierdzone;
    }

    public void Anuluj()
    {
        if (Status == StatusZamowienia.Anulowane)
            throw new InvalidOperationException("Zamówienie jest już anulowane");
        Status = StatusZamowienia.Anulowane;
    }
}

// ── Read Model — DTO dla różnych widoków ─────────────────────
record ZamowienieListaDto(
    Guid Id, string NumerZamowienia, string KlientNazwa,
    string DataZlozenia, string Wartosc, string Status);

record PozycjaDto(string Nazwa, int Ilosc, string Wartosc);

record ZamowienieDetailsDto(
    Guid Id, string NumerZamowienia, string KlientNazwa,
    IReadOnlyList<PozycjaDto> Pozycje, string Wartosc, string Status);

record SprzedazDto(string Status, int LiczbaZamowien, string Wartosc);

// ── In-memory baza (prosta symulacja) ────────────────────────
class InMemoryBaza
{
    public List<ZamowienieAggregate> Zamowienia { get; } = [];
    private int _numerator = 1000;
    public int NastepnyNumer() => ++_numerator;
}

// ── Command Side (Write) ──────────────────────────────────────
class ZamowienieCommandSide(InMemoryBaza db)
{
    public Guid ZlozZamowienie(Guid klientId, string klientNazwa)
    {
        var zam = new ZamowienieAggregate(klientId, klientNazwa, db.NastepnyNumer());
        db.Zamowienia.Add(zam);
        return zam.Id;
    }

    public void DodajPozycje(Guid zamId, string nazwa, int ilosc, decimal cena)
    {
        var zam = db.Zamowienia.First(z => z.Id == zamId);
        zam.DodajPozycje(nazwa, ilosc, cena);
    }

    public void PotwierdzzZamowienie(Guid zamId)
    {
        var zam = db.Zamowienia.First(z => z.Id == zamId);
        zam.Potwierdz();
    }
}

// ── Query Side (Read) — Projekcje ─────────────────────────────
class ZamowienieQuerySide(InMemoryBaza db)
{
    // Projekcja na DTO listy
    public IReadOnlyList<ZamowienieListaDto> PobierzListe()
        => db.Zamowienia
             .Select(z => new ZamowienieListaDto(
                 z.Id,
                 $"ZAM-{z.Numer}",
                 z.KlientNazwa,
                 z.DataZlozenia.ToString("yyyy-MM-dd"),
                 $"{z.Wartosc:F2} zł",
                 z.Status.ToString()))
             .ToList()
             .AsReadOnly();

    // Projekcja na DTO szczegółów
    public ZamowienieDetailsDto? PobierzSzczegoly(Guid id)
    {
        var z = db.Zamowienia.FirstOrDefault(x => x.Id == id);
        if (z == null) return null;
        var pozycje = z.Pozycje
            .Select(p => new PozycjaDto(p.Nazwa, p.Ilosc, $"{p.Wartosc:F2} zł"))
            .ToList()
            .AsReadOnly();
        return new ZamowienieDetailsDto(
            z.Id, $"ZAM-{z.Numer}", z.KlientNazwa,
            pozycje, $"{z.Wartosc:F2} zł", z.Status.ToString());
    }

    // Projekcja na raport sprzedaży
    public IReadOnlyList<SprzedazDto> RaportSprzedazy()
        => db.Zamowienia
             .GroupBy(z => z.Status)
             .Select(g => new SprzedazDto(
                 g.Key.ToString(),
                 g.Count(),
                 $"{g.Sum(z => z.Wartosc):F2} zł"))
             .ToList()
             .AsReadOnly();
}
