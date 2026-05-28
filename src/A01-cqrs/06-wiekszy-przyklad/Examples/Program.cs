using Cqrs.Biblioteka;

Console.WriteLine("=== CQRS — Wypożyczalnia Książek ===\n");

// Konfiguracja (w produkcji przez DI container)
var repo = new InMemoryKsiazkaWriteRepository();

var dodajHandler     = new DodajKsiazkeHandler(repo);
var wypozyczHandler  = new WypozyczKsiazkeHandler(repo);
var zwrocHandler     = new ZwrocKsiazkeHandler(repo);
var wycofajHandler   = new WycofajKsiazkeHandler(repo);

var dostepneHandler  = new PobierzDostepneKsiazkiHandler(repo);
var wszystkieHandler = new PobierzWszystkieKsiazkiHandler(repo);
var wypozyczeUzytHandler = new PobierzWypozyczeniaUzytkownikaHandler(repo);
var historiaHandler  = new PobierzHistorieKsiazkiHandler(repo);

// ─── Dodawanie książek ────────────────────────────────────
Console.WriteLine("─── 1. Dodawanie książek ───");

var k1 = Guid.NewGuid();
var k2 = Guid.NewGuid();
var k3 = Guid.NewGuid();
var k4 = Guid.NewGuid();

await dodajHandler.HandleAsync(new DodajKsiazkeCommand(k1, "Wzorce projektowe", "Gang of Four", "978-83-01-12-3", 1994));
await dodajHandler.HandleAsync(new DodajKsiazkeCommand(k2, "Czysty kod", "Robert Martin", "978-83-01-45-6", 2008));
await dodajHandler.HandleAsync(new DodajKsiazkeCommand(k3, "Domain-Driven Design", "Eric Evans", "978-0-32-112-5", 2003));
await dodajHandler.HandleAsync(new DodajKsiazkeCommand(k4, "Refaktoryzacja", "Martin Fowler", "978-83-01-78-9", 2018));

Console.WriteLine("Dodano 4 książki.\n");

// ─── Sprawdzenie dostępnych ───────────────────────────────
Console.WriteLine("─── 2. Dostępne książki (Query) ───");
var dostepne = await dostepneHandler.HandleAsync(new PobierzDostepneKsiazki());
Console.WriteLine($"Dostępne: {dostepne.Count}");
foreach (var d in dostepne)
    Console.WriteLine($"  [{d.Id.ToString()[..8]}] {d.Tytul,-30} {d.Autor}");

// ─── Wypożyczenia ─────────────────────────────────────────
Console.WriteLine("\n─── 3. Wypożyczenia (Command) ───");

var user1 = Guid.NewGuid();
var user2 = Guid.NewGuid();

await wypozyczHandler.HandleAsync(new WypozyczKsiazkeCommand(k1, user1, "Jan Kowalski"));
await wypozyczHandler.HandleAsync(new WypozyczKsiazkeCommand(k2, user1, "Jan Kowalski"));
await wypozyczHandler.HandleAsync(new WypozyczKsiazkeCommand(k3, user2, "Anna Nowak"));

Console.WriteLine("Jan Kowalski wypożyczył: Wzorce projektowe + Czysty kod");
Console.WriteLine("Anna Nowak wypożyczyła: Domain-Driven Design");

// ─── Próba podwójnego wypożyczenia ────────────────────────
Console.WriteLine("\n─── 4. Ochrona niezmiennika ───");
try
{
    await wypozyczHandler.HandleAsync(new WypozyczKsiazkeCommand(k1, user2, "Anna Nowak"));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Błąd (oczekiwany): {ex.Message}");
}

// ─── Stan po wypożyczeniach ───────────────────────────────
Console.WriteLine("\n─── 5. Wszystkie książki po wypożyczeniach (Query) ───");
var wszystkie = await wszystkieHandler.HandleAsync(new PobierzWszystkieKsiazki());
foreach (var k in wszystkie)
{
    var status = k.DostepnaDoWypozyczenia ? "dostepna" : $"wypożyczona przez {k.AktualnyWypozyczajacy}";
    Console.WriteLine($"  {k.Tytul,-30} | {status}");
}

// ─── Wypożyczenia użytkownika ─────────────────────────────
Console.WriteLine("\n─── 6. Wypożyczenia Jana Kowalskiego (Query) ───");
var wypozyczeJana = await wypozyczeUzytHandler.HandleAsync(
    new PobierzWypozyczeniaUzytkownikaQuery(user1));
foreach (var w in wypozyczeJana)
    Console.WriteLine($"  {w.KsiazakTytul,-30} | status: {w.Status}");

// ─── Zwroty ───────────────────────────────────────────────
Console.WriteLine("\n─── 7. Zwroty książek (Command) ───");
await zwrocHandler.HandleAsync(new ZwrocKsiazkeCommand(k1, user1));
await zwrocHandler.HandleAsync(new ZwrocKsiazkeCommand(k3, user2));
Console.WriteLine("Jan zwrócił: Wzorce projektowe");
Console.WriteLine("Anna zwróciła: Domain-Driven Design");

// ─── Historia książki ─────────────────────────────────────
Console.WriteLine("\n─── 8. Historia książki 'Wzorce projektowe' (Query) ───");
var historia = await historiaHandler.HandleAsync(new PobierzHistorieKsiazkiQuery(k1));
if (historia != null)
{
    Console.WriteLine($"Książka: {historia.Tytul}");
    foreach (var h in historia.Historia)
    {
        var dni = h.LiczbaDniWypozyczenia.HasValue ? $"{h.LiczbaDniWypozyczenia} dni" : "aktywne";
        Console.WriteLine($"  {h.UzytkownikNazwa,-20} | {h.Status,-10} | {dni}");
    }
}

// ─── Wycofanie książki ────────────────────────────────────
Console.WriteLine("\n─── 9. Wycofanie książki ───");
await wycofajHandler.HandleAsync(new WycofajKsiazkeCommand(k4));
Console.WriteLine("Książka 'Refaktoryzacja' wycofana ze zbiorów.");

var dostepnePoWycofaniu = await dostepneHandler.HandleAsync(new PobierzDostepneKsiazki());
Console.WriteLine($"Dostępne po wycofaniu: {dostepnePoWycofaniu.Count}");

Console.WriteLine("\n=== Koniec demonstracji ===");
