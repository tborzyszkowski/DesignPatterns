# Zadania — Wzorzec CQRS

## Zadanie 1 — Sklep z kawą (podstawowe CQRS)

**Cel:** Zaprojektuj prosty system CQRS dla kawiarni.

**Wymagania:**

Komendy:
- `DodajPozycjeDoMenuCommand(string nazwa, decimal cena, string kategoria)`
- `ZmienCeneCommand(Guid id, decimal nowaCena)`
- `UsunZMenuCommand(Guid id)`

Zapytania:
- `PobierzMenuQuery()` → lista wszystkich pozycji
- `PobierzPoKategoriiQuery(string kategoria)` → filtrowanie
- `PobierzDrogiePozycjeQuery(decimal minCena)` → pozycje powyżej ceny

Implementuj:
- Interfejsy `ICommand`, `IQuery<TResult>`, `ICommandHandler<T>`, `IQueryHandler<TQ,TR>`
- In-memory storage jako `List<PozycjaMenu>`
- Prosty dispatcher oparty na słowniku typów

**Wskazówka:** Na początku zrób wszystko w jednym pliku `Program.cs` — podziel na klasy dopiero gdy kod zacznie rosnąć.

<details>
<summary>Rozwiązanie</summary>

```csharp
// Interfejsy CQRS
public interface ICommand { }
public interface IQuery<TResult> { }
public interface ICommandHandler<T> where T : ICommand
{
    void Handle(T command);
}
public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
{
    TResult Handle(TQuery query);
}

// Model domenowy
public record PozycjaMenu(Guid Id, string Nazwa, decimal Cena, string Kategoria);

// Komendy
public record DodajPozycjeCommand(string Nazwa, decimal Cena, string Kategoria) : ICommand;
public record ZmienCeneCommand(Guid Id, decimal NowaCena) : ICommand;
public record UsunZMenuCommand(Guid Id) : ICommand;

// Zapytania
public record PobierzMenuQuery() : IQuery<IReadOnlyList<PozycjaMenu>>;
public record PobierzPoKategoriiQuery(string Kategoria) : IQuery<IReadOnlyList<PozycjaMenu>>;

// In-memory storage
var menu = new List<PozycjaMenu>();

// Handlery komend
var dodajHandler = new DodajHandler(menu);
dodajHandler.Handle(new DodajPozycjeCommand("Espresso", 8.50m, "Kawa"));
dodajHandler.Handle(new DodajPozycjeCommand("Cappuccino", 11.00m, "Kawa"));

// Handlery zapytań
var pobierzHandler = new PobierzMenuHandler(menu);
var wynik = pobierzHandler.Handle(new PobierzMenuQuery());
foreach (var p in wynik) Console.WriteLine($"  {p.Nazwa}: {p.Cena:C}");

class DodajHandler(List<PozycjaMenu> menu) : ICommandHandler<DodajPozycjeCommand>
{
    public void Handle(DodajPozycjeCommand cmd)
        => menu.Add(new PozycjaMenu(Guid.NewGuid(), cmd.Nazwa, cmd.Cena, cmd.Kategoria));
}
class PobierzMenuHandler(List<PozycjaMenu> menu) : IQueryHandler<PobierzMenuQuery, IReadOnlyList<PozycjaMenu>>
{
    public IReadOnlyList<PozycjaMenu> Handle(PobierzMenuQuery _) => menu.AsReadOnly();
}
```

**Wyjaśnienie:** Komendy zmieniają stan (dodają/usuwają/modyfikują). Zapytania tylko odczytują — nie wolno im modyfikować listy. Handler może być prostą klasą lub metodą lokalną.

</details>

---

## Zadanie 2 — Separacja modeli Write/Read

**Cel:** Rozszerz rozwiązanie z Zadania 1 o osobne modele odczytu i zapisu.

**Wymagania:**

Write Model (domena):
```csharp
public class PozycjaMenuDomena
{
    public Guid Id { get; private set; }
    public string Nazwa { get; private set; }
    private decimal _cena;
    
    public void ZmienCene(decimal nowaCena)
    {
        if (nowaCena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        _cena = nowaCena;
    }
    // ... prywatne pola, logika biznesowa
}
```

Read Model (DTO):
```csharp
public record PozycjaMenuDto(Guid Id, string Nazwa, string Cena, string Kategoria, bool Dostepna);
// Cena jako string "8,50 zł" — gotowa do wyświetlenia
```

Dodaj mapowanie z Write Model → Read Model w handlerze zapytania.

<details>
<summary>Rozwiązanie</summary>

```csharp
// Write Model z logiką biznesową
public class PozycjaMenuDomena
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Nazwa { get; private set; }
    public decimal Cena { get; private set; }
    public string Kategoria { get; private set; }
    public bool Dostepna { get; private set; } = true;

    public PozycjaMenuDomena(string nazwa, decimal cena, string kategoria)
    {
        if (string.IsNullOrWhiteSpace(nazwa)) throw new ArgumentException("Nazwa nie może być pusta");
        if (cena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        Nazwa = nazwa; Cena = cena; Kategoria = kategoria;
    }

    public void ZmienCene(decimal nowaCena)
    {
        if (nowaCena <= 0) throw new ArgumentException("Cena musi być dodatnia");
        Cena = nowaCena;
    }

    public void Dezaktywuj() => Dostepna = false;
}

// Read Model (DTO) — zoptymalizowany pod wyświetlanie
public record PozycjaMenuDto(Guid Id, string Nazwa, string CenaFormatowana, 
    string Kategoria, bool Dostepna);

// Mapowanie w Query Handlerze
class PobierzMenuHandler(List<PozycjaMenuDomena> repo) 
    : IQueryHandler<PobierzMenuQuery, IReadOnlyList<PozycjaMenuDto>>
{
    public IReadOnlyList<PozycjaMenuDto> Handle(PobierzMenuQuery _)
        => repo.Select(p => new PozycjaMenuDto(
            p.Id, p.Nazwa, $"{p.Cena:F2} zł", p.Kategoria, p.Dostepna
        )).ToList().AsReadOnly();
}
```

**Wyjaśnienie:** Write Model chroni niezmienniki (walidacja w konstruktorze i metodach). Read Model jest uproszczony — może mieć dane sformatowane, wyliczone pola i inne transformacje bez wpływu na domenę.

</details>

---

## Zadanie 3 — Event Sourcing dla systemu bankowego

**Cel:** Zaimplementuj prosty Event Store dla konta bankowego.

**Wymagania:**

Zdarzenia domenowe:
- `KontaOtwarte(Guid kontoId, string wlasciciel, decimal saloPoczatkowe)`
- `SrodkiWplacone(Guid kontoId, decimal kwota)`
- `SrodkiWyplacone(Guid kontoId, decimal kwota)`

Event Store — prosta lista zdarzeń.

Odbudowanie stanu konta ze zdarzeń:
```csharp
var konto = new KontoBankowe();
foreach (var zdarzenie in eventStore.GetEvents(kontoId))
    konto.Apply(zdarzenie);
```

Read Model — projekcja aktualnego salda z historii zdarzeń.

<details>
<summary>Rozwiązanie</summary>

```csharp
// Zdarzenia domenowe
public abstract record DomainEvent(Guid AggregateId, DateTime OccurredAt);
public record KontoOtwarteEvent(Guid KontoId, string Wlasciciel, decimal SaldoPoczatkowe)
    : DomainEvent(KontoId, DateTime.UtcNow);
public record SrodkiWplaconeEvent(Guid KontoId, decimal Kwota)
    : DomainEvent(KontoId, DateTime.UtcNow);
public record SrodkiWyploconeEvent(Guid KontoId, decimal Kwota)
    : DomainEvent(KontoId, DateTime.UtcNow);

// Event Store
public class EventStore
{
    private readonly List<DomainEvent> _events = [];
    public void Save(DomainEvent e) => _events.Add(e);
    public IEnumerable<DomainEvent> GetEvents(Guid aggregateId)
        => _events.Where(e => e.AggregateId == aggregateId);
}

// Agregat odbudowywany ze zdarzeń
public class KontoBankowe
{
    public Guid Id { get; private set; }
    public string Wlasciciel { get; private set; } = "";
    public decimal Saldo { get; private set; }

    public void Apply(DomainEvent e)
    {
        switch (e)
        {
            case KontoOtwarteEvent o:
                Id = o.KontoId; Wlasciciel = o.Wlasciciel; Saldo = o.SaldoPoczatkowe; break;
            case SrodkiWplaconeEvent w:
                Saldo += w.Kwota; break;
            case SrodkiWyploconeEvent wy:
                if (wy.Kwota > Saldo) throw new InvalidOperationException("Brak środków");
                Saldo -= wy.Kwota; break;
        }
    }
}

// Użycie
var store = new EventStore();
var kontoId = Guid.NewGuid();
store.Save(new KontoOtwarteEvent(kontoId, "Jan Kowalski", 1000m));
store.Save(new SrodkiWplaconeEvent(kontoId, 500m));
store.Save(new SrodkiWyploconeEvent(kontoId, 200m));

var konto = new KontoBankowe();
foreach (var e in store.GetEvents(kontoId)) konto.Apply(e);
Console.WriteLine($"Saldo: {konto.Saldo} zł"); // 1300 zł
```

**Wyjaśnienie:** Event Store zapamiętuje wszystkie zdarzenia. Stan odbudowujemy od zera przez odtworzenie sekwencji zdarzeń — nigdy nie tracimy historii. Każde zdarzenie jest niemutowalne (record).

</details>

---

## Zadanie 4 — Kiedy CQRS, kiedy CRUD?

**Cel:** Dla poniższych scenariuszy zdecyduj, czy CQRS jest uzasadniony. Podaj argument.

| Scenariusz | CQRS? | Uzasadnienie |
|------------|-------|--------------|
| Blog osobisty (1 autor, 50 czytelników) | ? | ? |
| Portal e-commerce (10 000 zamówień/dzień) | ? | ? |
| System bankowy z historią transakcji | ? | ? |
| Aplikacja todo dla jednego użytkownika | ? | ? |
| System raportowania (99% reads, 1% writes) | ? | ? |
| CMS dla redakcji (20 redaktorów, 1M czytelników) | ? | ? |

<details>
<summary>Odpowiedzi i uzasadnienia</summary>

| Scenariusz | CQRS? | Uzasadnienie |
|------------|-------|--------------|
| Blog osobisty | **NIE** | Prosty CRUD wystarczy. Overhead CQRS nieproporcjonalny do skali. |
| Portal e-commerce | **TAK** | Różne obciążenie writes (zamówienia) i reads (katalog produktów). Osobne bazy dla odczytu i zapisu. |
| System bankowy | **TAK + Event Sourcing** | Audyt wymaga historii. ES daje pełną historię transakcji za darmo. |
| Aplikacja todo | **NIE** | Nadmierna inżynieria. CRUD w 50 linii kodu. |
| System raportowania | **TAK** | 99% reads — osobny model odczytu zoptymalizowany pod raporty. Denormalizacja. |
| CMS | **TAK** | Różna logika: redaktorzy (writes z walidacją, wersjowaniem), czytelnicy (proste reads, cache). |

**Reguła ogólna:** CQRS jest uzasadniony gdy:
- reads i writes mają bardzo różne wymagania skalowania,
- model odczytu jest znacznie prostszy niż model zapisu,
- potrzebna jest historia operacji (Event Sourcing),
- różne zespoły pracują nad odczytem i zapisem.

</details>
