namespace Cqrs.Biblioteka;

// ============================================================
// CQRS Kontrakty — interfejsy
// ============================================================

public interface ICommand { }
public interface IQuery<TResult> { }

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task HandleAsync(TCommand command, CancellationToken ct = default);
}

public interface IQueryHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
    Task<TResult> HandleAsync(TQuery query, CancellationToken ct = default);
}

// ============================================================
// DOMENA — Write Model (Aggregate Root)
// ============================================================

public enum StatusWypozyczenia { Aktywne, Zwrocone }

public class Wypozyczenie
{
    public Guid       UzytkownikId  { get; init; }
    public string     UzytkownikNazwa { get; init; } = "";
    public DateTime   DataWypozyczenia { get; init; }
    public DateTime?  DataZwrotu    { get; private set; }
    public StatusWypozyczenia Status => DataZwrotu.HasValue
        ? StatusWypozyczenia.Zwrocone
        : StatusWypozyczenia.Aktywne;

    public Wypozyczenie(Guid uzytkownikId, string uzytkownikNazwa, DateTime dataWypozyczenia)
    {
        UzytkownikId   = uzytkownikId;
        UzytkownikNazwa = uzytkownikNazwa;
        DataWypozyczenia = dataWypozyczenia;
    }

    internal void Zwroc(DateTime dataZwrotu)
    {
        if (DataZwrotu.HasValue)
            throw new InvalidOperationException("To wypożyczenie zostało już zwrócone");
        DataZwrotu = dataZwrotu;
    }
}

public class Ksiazka
{
    public Guid         Id      { get; private set; }
    public string       Tytul   { get; private set; } = "";
    public string       Autor   { get; private set; } = "";
    public string       ISBN    { get; private set; } = "";
    public int          RokWydania { get; private set; }
    public bool         Aktywna { get; private set; } = true;

    private readonly List<Wypozyczenie> _wypozyczenia = [];
    public IReadOnlyList<Wypozyczenie> Wypozyczenia => _wypozyczenia.AsReadOnly();

    public bool CzyDostepna =>
        Aktywna && !_wypozyczenia.Any(w => w.Status == StatusWypozyczenia.Aktywne);

    // Prywatny konstruktor — tworzenie przez fabrykę
    private Ksiazka() { }

    public static Ksiazka Stworz(Guid id, string tytul, string autor, string isbn, int rokWydania)
    {
        if (string.IsNullOrWhiteSpace(tytul)) throw new ArgumentException("Tytuł jest wymagany");
        if (string.IsNullOrWhiteSpace(autor)) throw new ArgumentException("Autor jest wymagany");
        if (rokWydania < 1400 || rokWydania > DateTime.UtcNow.Year + 1)
            throw new ArgumentException($"Nieprawidłowy rok wydania: {rokWydania}");
        return new Ksiazka { Id = id, Tytul = tytul, Autor = autor, ISBN = isbn, RokWydania = rokWydania };
    }

    public void Wypozycz(Guid uzytkownikId, string uzytkownikNazwa, DateTime dataTx)
    {
        if (!Aktywna)
            throw new InvalidOperationException($"Książka '{Tytul}' jest wycofana ze zbiorów");
        if (!CzyDostepna)
        {
            var aktywne = _wypozyczenia.First(w => w.Status == StatusWypozyczenia.Aktywne);
            throw new InvalidOperationException(
                $"Książka '{Tytul}' jest aktualnie wypożyczona przez {aktywne.UzytkownikNazwa}");
        }
        _wypozyczenia.Add(new Wypozyczenie(uzytkownikId, uzytkownikNazwa, dataTx));
    }

    public void Zwroc(Guid uzytkownikId, DateTime dataTx)
    {
        var wypozyczenie = _wypozyczenia
            .FirstOrDefault(w => w.UzytkownikId == uzytkownikId && w.Status == StatusWypozyczenia.Aktywne);
        if (wypozyczenie == null)
            throw new InvalidOperationException(
                $"Użytkownik {uzytkownikId} nie ma aktywnego wypożyczenia książki '{Tytul}'");
        wypozyczenie.Zwroc(dataTx);
    }

    public void Wycofaj()
    {
        if (!CzyDostepna)
            throw new InvalidOperationException("Nie można wycofać wypożyczonej książki");
        Aktywna = false;
    }
}

// ============================================================
// REPOZYTORIA (Write side)
// ============================================================

public interface IKsiazkaWriteRepository
{
    Task<Ksiazka?> PobierzAsync(Guid id);
    Task ZapiszAsync(Ksiazka ksiazka);
}

// In-memory implementacja
public class InMemoryKsiazkaWriteRepository : IKsiazkaWriteRepository
{
    private readonly Dictionary<Guid, Ksiazka> _db = [];

    public Task<Ksiazka?> PobierzAsync(Guid id)
    {
        _db.TryGetValue(id, out var k);
        return Task.FromResult(k);
    }

    public Task ZapiszAsync(Ksiazka ksiazka)
    {
        _db[ksiazka.Id] = ksiazka;
        return Task.CompletedTask;
    }

    public IEnumerable<Ksiazka> All => _db.Values;
}

// ============================================================
// KOMENDY i ich handlery
// ============================================================

// --- Dodaj książkę ---
public record DodajKsiazkeCommand(
    Guid Id, string Tytul, string Autor, string ISBN, int RokWydania) : ICommand;

public class DodajKsiazkeHandler(IKsiazkaWriteRepository repo)
    : ICommandHandler<DodajKsiazkeCommand>
{
    public async Task HandleAsync(DodajKsiazkeCommand cmd, CancellationToken ct = default)
    {
        var istniejaca = await repo.PobierzAsync(cmd.Id);
        if (istniejaca != null)
            throw new InvalidOperationException($"Książka o Id {cmd.Id} już istnieje");
        var ksiazka = Ksiazka.Stworz(cmd.Id, cmd.Tytul, cmd.Autor, cmd.ISBN, cmd.RokWydania);
        await repo.ZapiszAsync(ksiazka);
    }
}

// --- Wypożycz książkę ---
public record WypozyczKsiazkeCommand(
    Guid KsiazkaId, Guid UzytkownikId, string UzytkownikNazwa) : ICommand;

public class WypozyczKsiazkeHandler(IKsiazkaWriteRepository repo)
    : ICommandHandler<WypozyczKsiazkeCommand>
{
    public async Task HandleAsync(WypozyczKsiazkeCommand cmd, CancellationToken ct = default)
    {
        var ksiazka = await repo.PobierzAsync(cmd.KsiazkaId)
            ?? throw new InvalidOperationException($"Książka {cmd.KsiazkaId} nie istnieje");
        ksiazka.Wypozycz(cmd.UzytkownikId, cmd.UzytkownikNazwa, DateTime.UtcNow);
        await repo.ZapiszAsync(ksiazka);
    }
}

// --- Zwróć książkę ---
public record ZwrocKsiazkeCommand(Guid KsiazkaId, Guid UzytkownikId) : ICommand;

public class ZwrocKsiazkeHandler(IKsiazkaWriteRepository repo)
    : ICommandHandler<ZwrocKsiazkeCommand>
{
    public async Task HandleAsync(ZwrocKsiazkeCommand cmd, CancellationToken ct = default)
    {
        var ksiazka = await repo.PobierzAsync(cmd.KsiazkaId)
            ?? throw new InvalidOperationException($"Książka {cmd.KsiazkaId} nie istnieje");
        ksiazka.Zwroc(cmd.UzytkownikId, DateTime.UtcNow);
        await repo.ZapiszAsync(ksiazka);
    }
}

// --- Wycofaj książkę ---
public record WycofajKsiazkeCommand(Guid KsiazkaId) : ICommand;

public class WycofajKsiazkeHandler(IKsiazkaWriteRepository repo)
    : ICommandHandler<WycofajKsiazkeCommand>
{
    public async Task HandleAsync(WycofajKsiazkeCommand cmd, CancellationToken ct = default)
    {
        var ksiazka = await repo.PobierzAsync(cmd.KsiazkaId)
            ?? throw new InvalidOperationException($"Książka {cmd.KsiazkaId} nie istnieje");
        ksiazka.Wycofaj();
        await repo.ZapiszAsync(ksiazka);
    }
}

// ============================================================
// READ MODELS (DTO) i zapytania
// ============================================================

public record KsiazkaListaDto(
    Guid Id, string Tytul, string Autor, string ISBN, bool DostepnaDoWypozyczenia,
    string? AktualnyWypozyczajacy);

public record WypozyczenieDto(
    Guid KsiazkaId, string KsiazakTytul, string KsiazkaAutor,
    DateTime DataWypozyczenia, DateTime? DataZwrotu, string Status);

public record KsiazkaHistoriaDto(
    Guid KsiazkaId, string Tytul, IReadOnlyList<WypozyczenieHistoriaItem> Historia);

public record WypozyczenieHistoriaItem(
    string UzytkownikNazwa, DateTime DataWypozyczenia, DateTime? DataZwrotu,
    string Status, int? LiczbaDniWypozyczenia);

// --- Zapytania ---
public record PobierzDostepneKsiazki() : IQuery<IReadOnlyList<KsiazkaListaDto>>;
public record PobierzWszystkieKsiazki() : IQuery<IReadOnlyList<KsiazkaListaDto>>;
public record PobierzWypozyczeniaUzytkownikaQuery(Guid UzytkownikId)
    : IQuery<IReadOnlyList<WypozyczenieDto>>;
public record PobierzHistorieKsiazkiQuery(Guid KsiazkaId)
    : IQuery<KsiazkaHistoriaDto?>;

// ============================================================
// HANDLERY ZAPYTAŃ
// ============================================================

public class PobierzDostepneKsiazkiHandler(InMemoryKsiazkaWriteRepository repo)
    : IQueryHandler<PobierzDostepneKsiazki, IReadOnlyList<KsiazkaListaDto>>
{
    public Task<IReadOnlyList<KsiazkaListaDto>> HandleAsync(
        PobierzDostepneKsiazki _, CancellationToken ct = default)
    {
        IReadOnlyList<KsiazkaListaDto> wynik = repo.All
            .Where(k => k.CzyDostepna)
            .Select(MapujNaDto)
            .ToList().AsReadOnly();
        return Task.FromResult(wynik);
    }

    private static KsiazkaListaDto MapujNaDto(Ksiazka k)
    {
        var aktywneWyp = k.Wypozyczenia.FirstOrDefault(w => w.Status == StatusWypozyczenia.Aktywne);
        return new KsiazkaListaDto(k.Id, k.Tytul, k.Autor, k.ISBN, k.CzyDostepna,
            aktywneWyp?.UzytkownikNazwa);
    }
}

public class PobierzWszystkieKsiazkiHandler(InMemoryKsiazkaWriteRepository repo)
    : IQueryHandler<PobierzWszystkieKsiazki, IReadOnlyList<KsiazkaListaDto>>
{
    public Task<IReadOnlyList<KsiazkaListaDto>> HandleAsync(
        PobierzWszystkieKsiazki _, CancellationToken ct = default)
    {
        IReadOnlyList<KsiazkaListaDto> wynik = repo.All
            .Select(k =>
            {
                var aktywneWyp = k.Wypozyczenia.FirstOrDefault(w => w.Status == StatusWypozyczenia.Aktywne);
                return new KsiazkaListaDto(k.Id, k.Tytul, k.Autor, k.ISBN, k.CzyDostepna,
                    aktywneWyp?.UzytkownikNazwa);
            })
            .ToList().AsReadOnly();
        return Task.FromResult(wynik);
    }
}

public class PobierzWypozyczeniaUzytkownikaHandler(InMemoryKsiazkaWriteRepository repo)
    : IQueryHandler<PobierzWypozyczeniaUzytkownikaQuery, IReadOnlyList<WypozyczenieDto>>
{
    public Task<IReadOnlyList<WypozyczenieDto>> HandleAsync(
        PobierzWypozyczeniaUzytkownikaQuery q, CancellationToken ct = default)
    {
        IReadOnlyList<WypozyczenieDto> wynik = repo.All
            .SelectMany(k => k.Wypozyczenia
                .Where(w => w.UzytkownikId == q.UzytkownikId)
                .Select(w => new WypozyczenieDto(
                    k.Id, k.Tytul, k.Autor,
                    w.DataWypozyczenia, w.DataZwrotu,
                    w.Status.ToString())))
            .OrderByDescending(w => w.DataWypozyczenia)
            .ToList().AsReadOnly();
        return Task.FromResult(wynik);
    }
}

public class PobierzHistorieKsiazkiHandler(InMemoryKsiazkaWriteRepository repo)
    : IQueryHandler<PobierzHistorieKsiazkiQuery, KsiazkaHistoriaDto?>
{
    public Task<KsiazkaHistoriaDto?> HandleAsync(
        PobierzHistorieKsiazkiQuery q, CancellationToken ct = default)
    {
        var ksiazka = repo.All.FirstOrDefault(k => k.Id == q.KsiazkaId);
        if (ksiazka == null) return Task.FromResult<KsiazkaHistoriaDto?>(null);

        var historia = ksiazka.Wypozyczenia
            .Select(w =>
            {
                int? dni = w.DataZwrotu.HasValue
                    ? (int)(w.DataZwrotu.Value - w.DataWypozyczenia).TotalDays
                    : null;
                return new WypozyczenieHistoriaItem(
                    w.UzytkownikNazwa, w.DataWypozyczenia, w.DataZwrotu,
                    w.Status.ToString(), dni);
            })
            .ToList().AsReadOnly();

        return Task.FromResult<KsiazkaHistoriaDto?>(
            new KsiazkaHistoriaDto(ksiazka.Id, ksiazka.Tytul, historia));
    }
}
