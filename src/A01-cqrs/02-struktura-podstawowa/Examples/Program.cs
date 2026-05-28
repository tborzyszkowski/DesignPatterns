// ============================================================
// Temat 02 — Struktura podstawowa CQRS
// Pokazuje: ICommand, IQuery, ICommandHandler, IQueryHandler,
//           prosty Dispatcher oparty na słowniku
// ============================================================

Console.WriteLine("=== CQRS — Struktura podstawowa ===\n");

// Konfiguracja — rejestracja handlerów
var sklep = new BazaDanych();
var dispatcher = new Dispatcher();

dispatcher.RegisterCommand<DodajProduktCommand>(new DodajProduktHandler(sklep));
dispatcher.RegisterCommand<ZmienCeneCommand>(new ZmienCeneHandler(sklep));
dispatcher.RegisterCommand<UsunProduktCommand>(new UsunProduktHandler(sklep));
dispatcher.RegisterQuery<PobierzWszystkieProduktyQuery, IReadOnlyList<ProduktDto>>(
    new PobierzWszystkieProduktyHandler(sklep));
dispatcher.RegisterQuery<PobierzPoKategoriiQuery, IReadOnlyList<ProduktDto>>(
    new PobierzPoKategoriiHandler(sklep));

// ─── Komendy ─────────────────────────────────────────────
Console.WriteLine("─── Wysyłanie komend (Commands) ───");

await dispatcher.SendCommandAsync(new DodajProduktCommand("Laptop Pro", 4500m, "Elektronika"));
await dispatcher.SendCommandAsync(new DodajProduktCommand("Mysz bezprzewodowa", 99m, "Elektronika"));
await dispatcher.SendCommandAsync(new DodajProduktCommand("Biurko narożne", 1800m, "Meble"));
await dispatcher.SendCommandAsync(new DodajProduktCommand("Krzesło ergonomiczne", 950m, "Meble"));

Console.WriteLine("Dodano 4 produkty.");

// Zmień cenę laptopa
var laptopId = sklep.Produkty.First(p => p.Nazwa == "Laptop Pro").Id;
await dispatcher.SendCommandAsync(new ZmienCeneCommand(laptopId, 4200m));
Console.WriteLine($"Zmieniono cenę laptopa na 4 200 zł.");

// ─── Zapytania ────────────────────────────────────────────
Console.WriteLine("\n─── Wysyłanie zapytań (Queries) ───");

var wszystkie = await dispatcher.SendQueryAsync<PobierzWszystkieProduktyQuery, IReadOnlyList<ProduktDto>>(
    new PobierzWszystkieProduktyQuery());

Console.WriteLine($"Wszystkie produkty ({wszystkie.Count}):");
foreach (var p in wszystkie)
    Console.WriteLine($"  {p.Nazwa,-25} {p.Cena,10:C}  [{p.Kategoria}]");

var elektronika = await dispatcher.SendQueryAsync<PobierzPoKategoriiQuery, IReadOnlyList<ProduktDto>>(
    new PobierzPoKategoriiQuery("Elektronika"));

Console.WriteLine($"\nElektronika ({elektronika.Count}):");
foreach (var p in elektronika)
    Console.WriteLine($"  {p.Nazwa,-25} {p.Cena,10:C}");

// ─── Usunięcie produktu ───────────────────────────────────
Console.WriteLine("\n─── Usunięcie produktu ───");
var myszId = sklep.Produkty.First(p => p.Nazwa == "Mysz bezprzewodowa").Id;
await dispatcher.SendCommandAsync(new UsunProduktCommand(myszId));

var poUsunieciu = await dispatcher.SendQueryAsync<PobierzWszystkieProduktyQuery, IReadOnlyList<ProduktDto>>(
    new PobierzWszystkieProduktyQuery());
Console.WriteLine($"Produkty po usunięciu: {poUsunieciu.Count}");

// ─── Struktura uczestników ───────────────────────────────
Console.WriteLine("\n─── Uczestnicy wzorca ───");
Console.WriteLine("ICommand           — znacznik komendy (zmiana stanu)");
Console.WriteLine("IQuery<TResult>    — zapytanie z typem wyniku");
Console.WriteLine("ICommandHandler<T> — logika biznesowa zapisu");
Console.WriteLine("IQueryHandler<Q,R> — logika pobierania danych");
Console.WriteLine("Dispatcher         — kieruje komendy/zapytania do handlerów");

// ============================================================
// TYPY
// ============================================================

// ── Interfejsy CQRS ─────────────────────────────────────────
interface ICommand { }
interface IQuery<TResult> { }
interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}
interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query);
}

// ── Modele ──────────────────────────────────────────────────
record ProduktDto(Guid Id, string Nazwa, decimal Cena, string Kategoria);

class ProduktEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nazwa { get; set; } = "";
    public decimal Cena { get; set; }
    public string Kategoria { get; set; } = "";
}

class BazaDanych
{
    public List<ProduktEntity> Produkty { get; } = [];
}

// ── Komendy ─────────────────────────────────────────────────
record DodajProduktCommand(string Nazwa, decimal Cena, string Kategoria) : ICommand;
record ZmienCeneCommand(Guid Id, decimal NowaCena) : ICommand;
record UsunProduktCommand(Guid Id) : ICommand;

// ── Handlery komend ─────────────────────────────────────────
class DodajProduktHandler(BazaDanych db) : ICommandHandler<DodajProduktCommand>
{
    public Task HandleAsync(DodajProduktCommand cmd)
    {
        if (string.IsNullOrWhiteSpace(cmd.Nazwa))
            throw new ArgumentException("Nazwa nie może być pusta");
        if (cmd.Cena <= 0)
            throw new ArgumentException("Cena musi być dodatnia");
        db.Produkty.Add(new ProduktEntity { Nazwa = cmd.Nazwa, Cena = cmd.Cena, Kategoria = cmd.Kategoria });
        return Task.CompletedTask;
    }
}

class ZmienCeneHandler(BazaDanych db) : ICommandHandler<ZmienCeneCommand>
{
    public Task HandleAsync(ZmienCeneCommand cmd)
    {
        var p = db.Produkty.FirstOrDefault(x => x.Id == cmd.Id)
            ?? throw new InvalidOperationException($"Produkt {cmd.Id} nie istnieje");
        if (cmd.NowaCena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        p.Cena = cmd.NowaCena;
        return Task.CompletedTask;
    }
}

class UsunProduktHandler(BazaDanych db) : ICommandHandler<UsunProduktCommand>
{
    public Task HandleAsync(UsunProduktCommand cmd)
    {
        var p = db.Produkty.FirstOrDefault(x => x.Id == cmd.Id)
            ?? throw new InvalidOperationException($"Produkt {cmd.Id} nie istnieje");
        db.Produkty.Remove(p);
        return Task.CompletedTask;
    }
}

// ── Zapytania ────────────────────────────────────────────────
record PobierzWszystkieProduktyQuery() : IQuery<IReadOnlyList<ProduktDto>>;
record PobierzPoKategoriiQuery(string Kategoria) : IQuery<IReadOnlyList<ProduktDto>>;

// ── Handlery zapytań ─────────────────────────────────────────
class PobierzWszystkieProduktyHandler(BazaDanych db)
    : IQueryHandler<PobierzWszystkieProduktyQuery, IReadOnlyList<ProduktDto>>
{
    public Task<IReadOnlyList<ProduktDto>> HandleAsync(PobierzWszystkieProduktyQuery _)
    {
        IReadOnlyList<ProduktDto> wynik = db.Produkty
            .Select(p => new ProduktDto(p.Id, p.Nazwa, p.Cena, p.Kategoria))
            .ToList()
            .AsReadOnly();
        return Task.FromResult(wynik);
    }
}

class PobierzPoKategoriiHandler(BazaDanych db)
    : IQueryHandler<PobierzPoKategoriiQuery, IReadOnlyList<ProduktDto>>
{
    public Task<IReadOnlyList<ProduktDto>> HandleAsync(PobierzPoKategoriiQuery q)
    {
        IReadOnlyList<ProduktDto> wynik = db.Produkty
            .Where(p => p.Kategoria.Equals(q.Kategoria, StringComparison.OrdinalIgnoreCase))
            .Select(p => new ProduktDto(p.Id, p.Nazwa, p.Cena, p.Kategoria))
            .ToList()
            .AsReadOnly();
        return Task.FromResult(wynik);
    }
}

// ── Dispatcher ───────────────────────────────────────────────
class Dispatcher
{
    private readonly Dictionary<Type, object> _commandHandlers = [];
    private readonly Dictionary<Type, object> _queryHandlers = [];

    public void RegisterCommand<TCommand>(ICommandHandler<TCommand> handler)
        where TCommand : ICommand
        => _commandHandlers[typeof(TCommand)] = handler;

    public void RegisterQuery<TQuery, TResult>(IQueryHandler<TQuery, TResult> handler)
        where TQuery : IQuery<TResult>
        => _queryHandlers[typeof(TQuery)] = handler;

    public Task SendCommandAsync<TCommand>(TCommand command)
        where TCommand : ICommand
    {
        if (!_commandHandlers.TryGetValue(typeof(TCommand), out var h))
            throw new InvalidOperationException($"Brak handlera dla {typeof(TCommand).Name}");
        return ((ICommandHandler<TCommand>)h).HandleAsync(command);
    }

    public Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query)
        where TQuery : IQuery<TResult>
    {
        if (!_queryHandlers.TryGetValue(typeof(TQuery), out var h))
            throw new InvalidOperationException($"Brak handlera dla {typeof(TQuery).Name}");
        return ((IQueryHandler<TQuery, TResult>)h).HandleAsync(query);
    }
}
