# Materiały do wykładu — CQRS

## Plan wykładu (90 minut)

| Czas | Temat | Slajdy / Demo |
|------|-------|--------------|
| 0–10 min | Problem z CRUD, zasada CQS | Diagram 01-idea |
| 10–25 min | Historia i definicja CQRS | Diagram 02-historia |
| 25–45 min | Struktura podstawowa — Command, Query, Handler, Dispatcher | Diagram 03-klasowy, demo topic 02 |
| 45–60 min | Separacja modeli Write/Read, projekcje | Diagram 04-modele, demo topic 03 |
| 60–75 min | CQRS + Event Sourcing | Diagram 05-event-store, demo topic 04 |
| 75–90 min | Kiedy stosować, wady, alternatywy, pytania | Diagram 06-decyzja |

---

## Kluczowe pojęcia

### Zasada CQS (Bertrand Meyer, 1988)

> „Każda metoda albo coś zmienia (*Command*), albo coś zwraca (*Query*) — nie robi obu naraz."

```csharp
// CQS — złamanie zasady (metoda robi obie rzeczy):
int PopAndReturn()  // zwraca I usuwa — źle!

// CQS — poprawnie:
void Push(int value);   // Command — zmienia stan
int Peek();             // Query  — nie zmienia stanu
```

### CQRS (Greg Young, 2010)

> „Stosujemy dwa osobne obiekty tam, gdzie wcześniej był jeden."

- **Command** — intencja zmiany stanu; nie zwraca danych (lub tylko ID)
- **Query** — pytanie o stan; nie zmienia stanu
- **CommandHandler** — wykonuje biznesową logikę zapisu
- **QueryHandler** — pobiera i transformuje dane do odczytu

---

## Diagramy do wykładu

### Temat 01 — Idea i kontekst

- `01-idea-i-kontekst/diagrams/cqrs_problem.png` — CRUD vs CQRS
- `01-idea-i-kontekst/diagrams/cqs_zasada.png` — zasada CQS
- `01-idea-i-kontekst/diagrams/cqrs_historia.png` — oś czasu

### Temat 02 — Struktura podstawowa

- `02-struktura-podstawowa/diagrams/cqrs_class.png` — diagram klas
- `02-struktura-podstawowa/diagrams/cqrs_sequence.png` — diagram sekwencji

### Temat 03 — Separacja modeli

- `03-separacja-modeli/diagrams/cqrs_models.png` — Write vs Read Model
- `03-separacja-modeli/diagrams/cqrs_projections.png` — projekcje

### Temat 04 — Event Sourcing

- `04-event-sourcing/diagrams/cqrs_event_store.png` — Event Store
- `04-event-sourcing/diagrams/cqrs_event_flow.png` — przepływ zdarzeń

### Temat 05 — Wady i zalety

- `05-wady-zalety-alternatywy/diagrams/cqrs_decision.png` — drzewo decyzji
- `05-wady-zalety-alternatywy/diagrams/cqrs_comparison.png` — tabela porównawcza

### Temat 06 — Większy przykład

- `06-wiekszy-przyklad/diagrams/cqrs_architecture.png` — architektura przykładu
- `06-wiekszy-przyklad/diagrams/cqrs_sequence_borrow.png` — sekwencja wypożyczenia

---

## Fragmenty kodu do omówienia na wykładzie

### Kontrakt Command i Query

```csharp
// Znacznik — Command nie zwraca danych
public interface ICommand { }
public interface ICommand<TResult> { }  // opcjonalnie ID nowego zasobu

// Query zawsze zwraca dane
public interface IQuery<TResult> { }

// Handlery
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
```

### Separacja modeli — Write vs Read

```csharp
// Write Model — bogata domena
public class Ksiazka
{
    private readonly List<Wypozyczenie> _wypozyczenia = [];
    public void Wypozycz(Guid uzytkownikId, DateTime data)
    {
        if (_wypozyczenia.Any(w => w.DataZwrotu == null))
            throw new InvalidOperationException("Książka jest już wypożyczona");
        _wypozyczenia.Add(new Wypozyczenie(uzytkownikId, data));
    }
}

// Read Model — płaskie DTO
public record KsiazkaDto(Guid Id, string Tytul, string Autor,
    bool DostepnaDoWypozyczenia, string? AktualnyWypozyczajacy);
```

### Event Sourcing — zdarzenia zamiast stanu

```csharp
// Zamiast zapisywać stan — zapisujemy zdarzenia
public abstract record DomainEvent(Guid AggregateId, DateTime OccurredAt);
public record KsiazkaWypozyczonaEvent(Guid KsiazkaId, Guid UzytkownikId, DateTime Data)
    : DomainEvent(KsiazkaId, Data);

// Read Model budowany z projekcji zdarzeń
public class KsiazkaProjection
{
    public void Apply(KsiazkaWypozyczonaEvent e)
        => DostepnaDoWypozyczenia = false;
}
```

---

## Pytania dyskusyjne

1. Czy CQRS to wzorzec GoF? Jakie inne wzorce architektoniczne znacie?
2. Kiedy separacja modelu odczytu i zapisu jest przesadą?
3. Jak eventual consistency wpływa na UX aplikacji?
4. Co jest trudniejsze do utrzymania: jeden model CRUD czy dwa modele CQRS?
5. Dlaczego CQRS naturalnie pasuje do Event Sourcing?

---

## Literatura

- [Greg Young — CQRS Documents](https://cqrs.files.wordpress.com/2010/11/cqrs_documents.pdf)
- [Martin Fowler — CQRS](https://martinfowler.com/bliki/CQRS.html)
- [Microsoft — CQRS Pattern](https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs)
- [Microsoft — Event Sourcing](https://learn.microsoft.com/en-us/azure/architecture/patterns/event-sourcing)
