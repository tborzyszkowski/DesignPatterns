// ============================================================
// Temat 01 — Idea i kontekst CQRS
// Pokazuje: problem CRUD, zasadę CQS, motywację CQRS
// ============================================================

Console.WriteLine("=== CQRS — Idea i kontekst ===\n");

// ─── Część 1: Problem z CRUD ───────────────────────────────
Console.WriteLine("─── 1. Problem z CRUD ───");
Console.WriteLine("Jeden model Produkt używany do odczytu i zapisu:");

var sklep = new SklepCrud();
sklep.Dodaj(new Produkt(Guid.NewGuid(), "Laptop", "Szybki laptop", 3500m, "Elektronika", 10));
sklep.Dodaj(new Produkt(Guid.NewGuid(), "Mysz", "Bezprzewodowa mysz", 89m, "Elektronika", 50));
sklep.Dodaj(new Produkt(Guid.NewGuid(), "Biurko", "Biurko stojące", 1200m, "Meble", 5));

// Odczyt — potrzebujemy tylko Id, Nazwa, Cena
Console.WriteLine("\nWidok listy (potrzeba: Id, Nazwa, Cena):");
foreach (var p in sklep.PobierzWszystkie())
    Console.WriteLine($"  [{p.Id.ToString()[..8]}] {p.Nazwa,-20} {p.Cena,8:C}");
// Ale wczytaliśmy też Opis, Kategoria, StanMagazynowy — 3 zbędne pola!

Console.WriteLine("\nProblemy CRUD:");
Console.WriteLine("  - Odczyt wczytuje wszystkie pola (zbędne bajty przez sieć)");
Console.WriteLine("  - Ta sama baza zoptymalizowana pod zapisy i zapytania");
Console.WriteLine("  - Trudno skalować reads i writes osobno");

// ─── Część 2: Zasada CQS ───────────────────────────────────
Console.WriteLine("\n─── 2. Zasada CQS (Bertrand Meyer, 1988) ───");

var stos = new StosCqs<int>();
stos.Wcisnij(1);
stos.Wcisnij(2);
stos.Wcisnij(3);

Console.WriteLine($"Wierzchołek (Query - nie zmienia): {stos.Wierzcholek()}");
Console.WriteLine($"Pusty? (Query): {stos.CzyPusty()}");
stos.Zdejmij(); // Command - zmienia stan, nic nie zwraca
Console.WriteLine($"Po Zdejmij (Command): wierzchołek = {stos.Wierzcholek()}");

Console.WriteLine("\nZasada CQS:");
Console.WriteLine("  Command: zmienia stan, nie zwraca danych");
Console.WriteLine("  Query:   zwraca dane, NIE zmienia stanu");

// ─── Część 3: CQRS — rozdzielone ścieżki ─────────────────
Console.WriteLine("\n─── 3. CQRS — osobne klasy dla zapisu i odczytu ───");

var baza = new BazaProduktow();
var writeRepo = new ProduktWriteRepository(baza);
var readRepo  = new ProduktReadRepository(baza);

// Zapis — bogaty model domenowy
var id1 = Guid.NewGuid();
writeRepo.Dodaj(new ProduktWrite(id1, "Klawiatura", "Mechaniczna klawiatura RGB", 299m, "Elektronika", 20));
writeRepo.ZmienCene(id1, 279m);

// Odczyt — lekkie DTO
Console.WriteLine("Lista produktów (tylko Id, Nazwa, Cena):");
foreach (var dto in readRepo.PobierzListe())
    Console.WriteLine($"  {dto.Nazwa,-20} {dto.Cena:C}");

Console.WriteLine("\nKorzyści CQRS:");
Console.WriteLine("  - Zapytania korzystają z osobnego, uproszczonego modelu");
Console.WriteLine("  - Każda strona może być niezależnie optymalizowana");
Console.WriteLine("  - Czytelniejszy kod — mniejsze klasy, jedna odpowiedzialność");

// ─── Podsumowanie ─────────────────────────────────────────
Console.WriteLine("\n─── Podsumowanie ───");
Console.WriteLine("CQS  = zasada na poziomie metod (jedna klasa)");
Console.WriteLine("CQRS = zasada na poziomie architektury (osobne stosy)");
Console.WriteLine("CQRS naturalnie wynika z CQS zastosowanej do całego systemu.");

// ============================================================
// TYPY
// ============================================================

// --- CRUD (stary styl) ---
record Produkt(Guid Id, string Nazwa, string Opis, decimal Cena, string Kategoria, int StanMagazynowy);

class SklepCrud
{
    private readonly List<Produkt> _produkty = [];
    public void Dodaj(Produkt p) => _produkty.Add(p);
    public IReadOnlyList<Produkt> PobierzWszystkie() => _produkty.AsReadOnly();
}

// --- CQS ---
class StosCqs<T>
{
    private readonly Stack<T> _dane = new();
    // Command — zmienia stan, nie zwraca
    public void Wcisnij(T v) => _dane.Push(v);
    public void Zdejmij()    => _dane.Pop();
    // Query — zwraca, nie zmienia
    public T Wierzcholek() => _dane.Peek();
    public bool CzyPusty() => _dane.Count == 0;
}

// --- CQRS (Write i Read osobno) ---
record ProduktWrite(Guid Id, string Nazwa, string Opis, decimal Cena, string Kategoria, int StanMagazynowy)
{
    public decimal Cena { get; private set; } = Cena;
    public void ZmienCene(decimal nowaCena)
    {
        if (nowaCena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        Cena = nowaCena;
    }
}

record ProduktListaDto(Guid Id, string Nazwa, decimal Cena);  // lekkie DTO do odczytu

class BazaProduktow
{
    public List<ProduktWrite> Produkty { get; } = [];
}

class ProduktWriteRepository(BazaProduktow baza)
{
    public void Dodaj(ProduktWrite p) => baza.Produkty.Add(p);
    public void ZmienCene(Guid id, decimal nowaCena)
    {
        var p = baza.Produkty.FirstOrDefault(x => x.Id == id)
            ?? throw new InvalidOperationException("Nie znaleziono");
        p.ZmienCene(nowaCena);
    }
}

class ProduktReadRepository(BazaProduktow baza)
{
    public IReadOnlyList<ProduktListaDto> PobierzListe()
        => baza.Produkty
               .Select(p => new ProduktListaDto(p.Id, p.Nazwa, p.Cena))
               .ToList()
               .AsReadOnly();
}
