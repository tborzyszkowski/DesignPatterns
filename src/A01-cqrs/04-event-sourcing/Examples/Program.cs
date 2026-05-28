// ============================================================
// Temat 04 — CQRS + Event Sourcing
// Pokazuje: Event Store, agregat odbudowywany ze zdarzeń,
//           projekcje Read Model, eventual consistency
// ============================================================

Console.WriteLine("=== CQRS + Event Sourcing — Konto bankowe ===\n");

var eventStore    = new EventStore();
var saldoView     = new SaldoProjection();
var historiaView  = new HistoriaTransakcjiProjection();
var projektor     = new Projektor([saldoView, historiaView]);

// Rejestracja projektora jako obserwatora event store
eventStore.OnEventSaved += projektor.Handle;

// ─── Otwarcie konta ───────────────────────────────────────
Console.WriteLine("─── Otwarcie konta ───");
var commandHandler = new KontoBankoweCommandHandler(eventStore);

var kontoId = Guid.NewGuid();
commandHandler.Handle(new OtworzKontoCommand(kontoId, "Jan Kowalski", 1000m));

Drukuj("Po otwarciu konta", saldoView, kontoId);

// ─── Wpłaty i wypłaty ─────────────────────────────────────
Console.WriteLine("\n─── Operacje na koncie ───");
commandHandler.Handle(new WplacSrodkiCommand(kontoId, 500m));
commandHandler.Handle(new WplacSrodkiCommand(kontoId, 200m));
commandHandler.Handle(new WyplacSrodkiCommand(kontoId, 300m));
commandHandler.Handle(new WplacSrodkiCommand(kontoId, 100m));

Drukuj("Po operacjach", saldoView, kontoId);

// ─── Historia transakcji (Read Model) ─────────────────────
Console.WriteLine("\n─── Historia transakcji ───");
var historia = historiaView.PobierzHistorie(kontoId);
foreach (var t in historia)
    Console.WriteLine($"  {t.Data:HH:mm:ss.fff}  {t.Typ,-18}  {t.Kwota,10:C}  Saldo: {t.SaldoPo:C}");

// ─── Próba wypłaty powyżej salda ──────────────────────────
Console.WriteLine("\n─── Walidacja niezmiennika ───");
try
{
    commandHandler.Handle(new WyplacSrodkiCommand(kontoId, 99999m));
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"  Błąd (oczekiwany): {ex.Message}");
}

// ─── Odbudowanie stanu ze zdarzeń (Event Replay) ──────────
Console.WriteLine("\n─── Event Replay — odbudowanie stanu ───");
Console.WriteLine($"Liczba zdarzeń w Event Store: {eventStore.LiczbaZdarzen(kontoId)}");

var konto = new KontoBankowe();
foreach (var e in eventStore.GetEvents(kontoId))
    konto.Apply(e);

Console.WriteLine($"Saldo odbudowane ze zdarzeń: {konto.Saldo:C}");
Console.WriteLine($"Saldo w projekcji:            {saldoView.PobierzSaldo(kontoId):C}");
Console.WriteLine($"Zgodność: {konto.Saldo == saldoView.PobierzSaldo(kontoId)}");

// ─── Drugie konto ─────────────────────────────────────────
Console.WriteLine("\n─── Drugie konto ───");
var konto2Id = Guid.NewGuid();
commandHandler.Handle(new OtworzKontoCommand(konto2Id, "Anna Nowak", 500m));
commandHandler.Handle(new WplacSrodkiCommand(konto2Id, 750m));

Console.WriteLine("Wszystkie salda:");
foreach (var s in saldoView.PobierzWszystkie())
    Console.WriteLine($"  {s.WlascicielNazwa,-20}  {s.Saldo:C}");

static void Drukuj(string etap, SaldoProjection proj, Guid id)
{
    var saldo = proj.PobierzSaldo(id);
    Console.WriteLine($"{etap}: {saldo:C}");
}

// ============================================================
// TYPY
// ============================================================

// ── Zdarzenia domenowe ───────────────────────────────────────
abstract record DomainEvent(Guid AggregateId, DateTime OccurredAt, int Version);

record KontoOtwarteEvent(Guid KontoId, string Wlasciciel, decimal SaldoPoczatkowe, int Version)
    : DomainEvent(KontoId, DateTime.UtcNow, Version);

record SrodkiWplaconeEvent(Guid KontoId, decimal Kwota, int Version)
    : DomainEvent(KontoId, DateTime.UtcNow, Version);

record SrodkiWyploconeEvent(Guid KontoId, decimal Kwota, int Version)
    : DomainEvent(KontoId, DateTime.UtcNow, Version);

// ── Event Store — tylko append ───────────────────────────────
class EventStore
{
    private readonly List<DomainEvent> _events = [];
    public event Action<DomainEvent>? OnEventSaved;

    public void Save(DomainEvent e)
    {
        _events.Add(e);
        OnEventSaved?.Invoke(e);
    }

    public IEnumerable<DomainEvent> GetEvents(Guid aggregateId)
        => _events.Where(e => e.AggregateId == aggregateId).OrderBy(e => e.Version);

    public int LiczbaZdarzen(Guid aggregateId)
        => _events.Count(e => e.AggregateId == aggregateId);
}

// ── Agregat — odbudowywany ze zdarzeń ────────────────────────
class KontoBankowe
{
    public Guid   Id            { get; private set; }
    public string Wlasciciel    { get; private set; } = "";
    public decimal Saldo        { get; private set; }
    private int _version;

    // Odbudowanie ze zdarzeń (Event Replay)
    public void Apply(DomainEvent e)
    {
        switch (e)
        {
            case KontoOtwarteEvent o:
                Id = o.KontoId; Wlasciciel = o.Wlasciciel; Saldo = o.SaldoPoczatkowe; break;
            case SrodkiWplaconeEvent w:
                Saldo += w.Kwota; break;
            case SrodkiWyploconeEvent wy:
                Saldo -= wy.Kwota; break;
        }
        _version = e.Version;
    }

    // Komenda — generuje zdarzenia
    public IEnumerable<DomainEvent> WplacSrodki(decimal kwota)
    {
        if (kwota <= 0) throw new ArgumentException("Kwota musi być dodatnia");
        var e = new SrodkiWplaconeEvent(Id, kwota, _version + 1);
        Apply(e);
        yield return e;
    }

    public IEnumerable<DomainEvent> WyplacSrodki(decimal kwota)
    {
        if (kwota <= 0) throw new ArgumentException("Kwota musi być dodatnia");
        if (kwota > Saldo) throw new InvalidOperationException($"Niewystarczające saldo ({Saldo:C}), żądano {kwota:C}");
        var e = new SrodkiWyploconeEvent(Id, kwota, _version + 1);
        Apply(e);
        yield return e;
    }

    public static (KontoBankowe konto, IEnumerable<DomainEvent> events) Otworz(
        Guid id, string wlasciciel, decimal saldo)
    {
        if (saldo < 0) throw new ArgumentException("Saldo początkowe nie może być ujemne");
        var konto = new KontoBankowe();
        var e = new KontoOtwarteEvent(id, wlasciciel, saldo, 1);
        konto.Apply(e);
        return (konto, [e]);
    }
}

// ── Komendy ──────────────────────────────────────────────────
record OtworzKontoCommand(Guid KontoId, string Wlasciciel, decimal SaldoPoczatkowe);
record WplacSrodkiCommand(Guid KontoId, decimal Kwota);
record WyplacSrodkiCommand(Guid KontoId, decimal Kwota);

// ── Command Handler ───────────────────────────────────────────
class KontoBankoweCommandHandler(EventStore store)
{
    public void Handle(OtworzKontoCommand cmd)
    {
        var (_, events) = KontoBankowe.Otworz(cmd.KontoId, cmd.Wlasciciel, cmd.SaldoPoczatkowe);
        foreach (var e in events) store.Save(e);
    }

    public void Handle(WplacSrodkiCommand cmd)
    {
        var konto = Odbuduj(cmd.KontoId);
        foreach (var e in konto.WplacSrodki(cmd.Kwota)) store.Save(e);
    }

    public void Handle(WyplacSrodkiCommand cmd)
    {
        var konto = Odbuduj(cmd.KontoId);
        foreach (var e in konto.WyplacSrodki(cmd.Kwota)) store.Save(e);
    }

    private KontoBankowe Odbuduj(Guid id)
    {
        var konto = new KontoBankowe();
        foreach (var e in store.GetEvents(id)) konto.Apply(e);
        return konto;
    }
}

// ── Projekcje (Read Model) ────────────────────────────────────
record TransakcjaDto(DateTime Data, string Typ, decimal Kwota, decimal SaldoPo);
record SaldoDto(Guid KontoId, string WlascicielNazwa, decimal Saldo);

class SaldoProjection
{
    private readonly Dictionary<Guid, SaldoDto> _salda = [];

    public void Handle(DomainEvent e)
    {
        switch (e)
        {
            case KontoOtwarteEvent o:
                _salda[o.KontoId] = new SaldoDto(o.KontoId, o.Wlasciciel, o.SaldoPoczatkowe); break;
            case SrodkiWplaconeEvent w:
                _salda[w.KontoId] = _salda[w.KontoId] with { Saldo = _salda[w.KontoId].Saldo + w.Kwota }; break;
            case SrodkiWyploconeEvent wy:
                _salda[wy.KontoId] = _salda[wy.KontoId] with { Saldo = _salda[wy.KontoId].Saldo - wy.Kwota }; break;
        }
    }

    public decimal PobierzSaldo(Guid kontoId)
        => _salda.TryGetValue(kontoId, out var s) ? s.Saldo : 0m;

    public IReadOnlyList<SaldoDto> PobierzWszystkie()
        => _salda.Values.ToList().AsReadOnly();
}

class HistoriaTransakcjiProjection
{
    private readonly Dictionary<Guid, List<TransakcjaDto>> _historia = [];

    public void Handle(DomainEvent e)
    {
        switch (e)
        {
            case KontoOtwarteEvent o:
                _historia[o.KontoId] = [new TransakcjaDto(o.OccurredAt, "Otwarcie konta", o.SaldoPoczatkowe, o.SaldoPoczatkowe)]; break;
            case SrodkiWplaconeEvent w when _historia.TryGetValue(w.KontoId, out var h):
                var saldoW = h.LastOrDefault()?.SaldoPo ?? 0 + w.Kwota;
                h.Add(new TransakcjaDto(w.OccurredAt, "Wpłata", w.Kwota, saldoW + w.Kwota)); break;
            case SrodkiWyploconeEvent wy when _historia.TryGetValue(wy.KontoId, out var h2):
                var saldoWy = h2.LastOrDefault()?.SaldoPo ?? 0;
                h2.Add(new TransakcjaDto(wy.OccurredAt, "Wypłata", wy.Kwota, saldoWy - wy.Kwota)); break;
        }
    }

    public IReadOnlyList<TransakcjaDto> PobierzHistorie(Guid kontoId)
        => _historia.TryGetValue(kontoId, out var h) ? h.AsReadOnly() : [];
}

// ── Projektor — deleguje do wszystkich projekcji ──────────────
class Projektor(IEnumerable<object> projekcje)
{
    private readonly List<object> _projekcje = projekcje.ToList();

    public void Handle(DomainEvent e)
    {
        foreach (var p in _projekcje)
        {
            if (p is SaldoProjection sp) sp.Handle(e);
            else if (p is HistoriaTransakcjiProjection hp) hp.Handle(e);
        }
    }
}
