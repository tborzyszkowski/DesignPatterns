// ============================================================
// Temat 05 — Wady, zalety i alternatywy CQRS
// Pokazuje: CRUD vs CQRS, zalety, wady, kiedy stosować
// ============================================================

Console.WriteLine("=== CQRS — Wady, zalety i alternatywy ===\n");

// ─── Podejście A: CRUD (prosty przypadek) ─────────────────
Console.WriteLine("─── Podejście A: CRUD ───");
Console.WriteLine("Pasuje do: prostej aplikacji todo, bloga, MVP\n");

var crudRepo = new ProduktCrudRepository();
crudRepo.Dodaj(new ProduktCrudDto(Guid.NewGuid(), "Laptop", "Szybki laptop", 3500m));
crudRepo.Dodaj(new ProduktCrudDto(Guid.NewGuid(), "Mysz", "Bezprzewodowa", 99m));

Console.WriteLine("Produkty (CRUD):");
foreach (var p in crudRepo.PobierzWszystkie())
    Console.WriteLine($"  {p.Nazwa,-15} {p.Cena:C}");

Console.WriteLine("\nZalety CRUD:");
Console.WriteLine("  + Prosty kod, mała złożoność");
Console.WriteLine("  + Mała ilość klas");
Console.WriteLine("  + Łatwy onboarding nowych deweloperów");
Console.WriteLine("Wady CRUD dla dużej skali:");
Console.WriteLine("  - Jeden model do wszystkiego — nie pasuje do złożonych widoków");
Console.WriteLine("  - Skalowanie reads i writes razem");
Console.WriteLine("  - Brak wyraźnej granicy między logiką zapisu a odczytu");

// ─── Podejście B: CQRS ────────────────────────────────────
Console.WriteLine("\n─── Podejście B: CQRS ───");
Console.WriteLine("Pasuje do: e-commerce, systemów enterprise, mikrousług\n");

var cqrsBaza = new SklepBaza();
var cqrsCommand = new SklepCommandSide(cqrsBaza);
var cqrsQuery   = new SklepQuerySide(cqrsBaza);

cqrsCommand.Dodaj("Klawiatura", "Mechaniczna RGB", 299m, "Elektronika");
cqrsCommand.Dodaj("Monitor 4K", "27 cali IPS", 2200m, "Elektronika");
cqrsCommand.Dodaj("Biurko", "Stojące z regulacją", 1800m, "Meble");

// Różne projekcje dla różnych widoków
Console.WriteLine("Widok listy (CQRS — Query):");
foreach (var dto in cqrsQuery.PobierzListe())
    Console.WriteLine($"  {dto.Nazwa,-20} {dto.CenaFormatowana,10}  [{dto.Kategoria}]");

Console.WriteLine($"\nWidok raportu:");
foreach (var r in cqrsQuery.RaportKategorii())
    Console.WriteLine($"  {r.Kategoria,-15} | Produkty: {r.LiczbaProduktow,3} | Śr. cena: {r.SredniaCena:C}");

Console.WriteLine("\nZalety CQRS:");
Console.WriteLine("  + Osobna optymalizacja reads i writes");
Console.WriteLine("  + Wiele Read Models na te same dane (różne projekcje)");
Console.WriteLine("  + Niezależne skalowanie (np. wiele instancji Read Side)");
Console.WriteLine("  + Wyraźny podział odpowiedzialności");
Console.WriteLine("Wady CQRS:");
Console.WriteLine("  - Więcej klas i interfejsów");
Console.WriteLine("  - Eventual consistency (przy osobnych bazach)");
Console.WriteLine("  - Większy overhead dla prostych przypadków");

// ─── Porównanie — kiedy co stosować ────────────────────────
Console.WriteLine("\n─── Reguły wyboru ───");
var scenariusze = new[]
{
    ("Blog osobisty",          "CRUD",     "Mała skala, jeden model pasuje do wszystkiego"),
    ("System raportowania",    "CQRS",     "99% reads, złożone zapytania — osobny Read Model"),
    ("E-commerce",             "CQRS",     "Różne widoki katalogu, koszyk, zamówienia"),
    ("System bankowy",         "CQRS+ES",  "Audyt, historia transakcji, event sourcing"),
    ("Aplikacja todo (1 user)","CRUD",     "Nadmierna inżynieria z CQRS"),
    ("Mikrousługi",            "CQRS",     "Każda usługa z własną bazą i modelem"),
};

Console.WriteLine($"\n{"Scenariusz",-30} {"Wybór",-10} Uzasadnienie");
Console.WriteLine(new string('-', 80));
foreach (var (sc, wybor, uzas) in scenariusze)
    Console.WriteLine($"  {sc,-28} {wybor,-10} {uzas}");

// ─── Złote zasady ────────────────────────────────────────
Console.WriteLine("\n─── Złote zasady ───");
Console.WriteLine("1. Nie stosuj CQRS domyślnie — oceń złożoność vs korzyści");
Console.WriteLine("2. Zacznij od CRUD — refaktoruj do CQRS gdy pojawi się potrzeba");
Console.WriteLine("3. CQRS nie wymaga Event Sourcing — można je stosować niezależnie");
Console.WriteLine("4. MediatR to nie CQRS — to narzędzie do implementacji CQRS");

// ============================================================
// TYPY
// ============================================================

// ── CRUD ────────────────────────────────────────────────────
record ProduktCrudDto(Guid Id, string Nazwa, string Opis, decimal Cena);

class ProduktCrudRepository
{
    private readonly List<ProduktCrudDto> _db = [];
    public void Dodaj(ProduktCrudDto p) => _db.Add(p);
    public void Usun(Guid id) => _db.RemoveAll(p => p.Id == id);
    public ProduktCrudDto? Pobierz(Guid id) => _db.FirstOrDefault(p => p.Id == id);
    public IReadOnlyList<ProduktCrudDto> PobierzWszystkie() => _db.AsReadOnly();
}

// ── CQRS ────────────────────────────────────────────────────
class ProduktEntity
{
    public Guid     Id         { get; init; } = Guid.NewGuid();
    public string   Nazwa      { get; set; } = "";
    public string   Opis       { get; set; } = "";
    public decimal  Cena       { get; set; }
    public string   Kategoria  { get; set; } = "";
    public DateTime DataDodania{ get; init; } = DateTime.UtcNow;
}

class SklepBaza
{
    public List<ProduktEntity> Produkty { get; } = [];
}

// Command Side
class SklepCommandSide(SklepBaza db)
{
    public void Dodaj(string nazwa, string opis, decimal cena, string kategoria)
    {
        if (string.IsNullOrWhiteSpace(nazwa)) throw new ArgumentException("Nazwa wymagana");
        if (cena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        db.Produkty.Add(new ProduktEntity { Nazwa = nazwa, Opis = opis, Cena = cena, Kategoria = kategoria });
    }
    public void ZmienCene(Guid id, decimal nowaCena)
    {
        var p = db.Produkty.First(x => x.Id == id);
        if (nowaCena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        p.Cena = nowaCena;
    }
}

// Read Models — różne DTO
record ProduktListaDto(Guid Id, string Nazwa, string CenaFormatowana, string Kategoria);
record KategoriaRaportDto(string Kategoria, int LiczbaProduktow, decimal SredniaCena);

// Query Side — projekcje
class SklepQuerySide(SklepBaza db)
{
    public IReadOnlyList<ProduktListaDto> PobierzListe()
        => db.Produkty
             .Select(p => new ProduktListaDto(p.Id, p.Nazwa, $"{p.Cena:F2} zł", p.Kategoria))
             .ToList().AsReadOnly();

    public IReadOnlyList<KategoriaRaportDto> RaportKategorii()
        => db.Produkty
             .GroupBy(p => p.Kategoria)
             .Select(g => new KategoriaRaportDto(g.Key, g.Count(), g.Average(p => p.Cena)))
             .ToList().AsReadOnly();
}
