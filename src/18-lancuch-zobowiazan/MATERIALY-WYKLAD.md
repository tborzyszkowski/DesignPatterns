# Materiały wykładowe — Łańcuch Zobowiązań (CoR)

> Czas: 90 minut | Poziom: zaawansowany | Wymagania: znajomość C#, OOP, podstawy wzorców GoF

---

## Plan wykładu

| Blok | Czas | Temat | Materiał |
|------|------|-------|---------|
| 1 | 0:00–0:15 | Idea i historia | `01-idea-i-kontekst/` |
| 2 | 0:15–0:30 | Struktura GoF | `03-struktura-gof/` |
| 3 | 0:30–0:45 | Typy implementacji | `04-typy-implementacji/` |
| 4 | 0:45–1:05 | Większy przykład (live coding) | `05-wiekszy-przyklad/` |
| 5 | 1:05–1:20 | Alternatywy i decyzja | `06-alternatywy-i-decyzja/` |
| 6 | 1:20–1:30 | Podsumowanie + pytania | — |

---

## Blok 1 — Idea i historia (15 min)

### Diagrams do pokazania
- `01-idea-i-kontekst/diagrams/cor_problem.png` — problem God Handler
- `01-idea-i-kontekst/diagrams/cor_concept.png` — koncepcja łańcucha
- `01-idea-i-kontekst/diagrams/cor_history.png` — oś czasu

### Kluczowe pytania do dyskusji
1. *"Macie metodę z 10 ifami. Co jest z nią nie tak?"* → prowadzi do God Handler
2. *"Jak obsługuje walidację ASP.NET Core Middleware? Czy to CoR?"*
3. *"Jakie frameworki .NET widzieliście, które używają czegoś podobnego?"*

### Przykład otwierający (3 min)
```csharp
// ZANIM — jedno miejsce wie o wszystkim
bool Authorize(HttpRequest req)
{
    if (!CheckIpAllowlist(req)) return false;
    if (!ValidatePassword(req)) return false;
    if (!CheckMfa(req)) return false;
    if (!HasRole(req, "Admin")) return false;
    return true;
}
```
→ Pytanie: *"Co się stanie, kiedy dojdzie wymóg geolokalizacji? Albo captcha?"*

### Definicja GoF (2 min)
> Unikaj sprzęgania nadawcy żądania z jego odbiorcą, dając więcej niż jednemu
> obiektowi szansę obsługi żądania. Połącz obiekty odbierające w łańcuch i
> przekazuj żądanie wzdłuż łańcucha, aż jakiś obiekt je obsłuży.

---

## Blok 2 — Struktura GoF (15 min)

### Diagrams do pokazania
- `03-struktura-gof/diagrams/cor_class_diagram.png` — diagram klas z rolami GoF
- `03-struktura-gof/diagrams/cor_sequence.png` — diagram sekwencji

### Omawiane pojęcia
| Rola GoF | Przykład w C# |
|---|---|
| Handler | `interface IHandler` |
| BaseHandler | `abstract class BaseHandler` (opcjonalnie) |
| ConcreteHandlerA/B | Konkretne klasy obsługujące |
| Client | Buduje łańcuch i wywołuje pierwszy handler |

### Ćwiczenie na żywo (5 min)
Popros studentów, żeby narysowali na kartce diagram klas dla walidacji formularza:
`RequiredValidator → EmailFormatValidator → UniqueEmailValidator`

---

## Blok 3 — Typy implementacji (15 min)

### Diagrams do pokazania
- `04-typy-implementacji/diagrams/cor_impl_types.png` — 4 typy

### Zestawienie do omówienia

**Typ 1: Klasyczny OOP**
```csharp
interface IValidator
{
    IValidator SetNext(IValidator next);
    ValidationResult? Validate(string value);
}
```
✔ Testowalny, czytelny | ✗ Więcej klas

**Typ 2: Func<> (delegatowy)**
```csharp
pipeline.Use((input, next) => next(input.Trim()));
```
✔ Zwięzły, composable | ✗ Trudny w debugowaniu

**Typ 3: Middleware (ASP.NET Core)**
```csharp
app.Use(async (ctx, next) => { ... await next(ctx); ... });
```
✔ Standard w .NET | ✗ Zależność od frameworka

**Typ 4: IPipelineBehavior (MediatR)**
```csharp
public class LoggingBehavior<TReq,TRes> : IPipelineBehavior<TReq,TRes> { ... }
```
✔ CQRS, DI-friendly | ✗ Wymaga MediatR

### Pytanie do dyskusji
*"Które podejście wybralibyście w nowym projekcie? Dlaczego?"*

---

## Blok 4 — Większy przykład: Bankomat (20 min)

### Scenariusz (2 min)
Bankomat musi wydać 380 zł używając banknotów 200, 100, 50, 20, 10 zł.

### Live coding (12 min)

Kolejność pisania kodu:
1. Interfejs `IDispenser` (2 min)
2. Klasa `BaseDispenser` z `SetNext` i `PassToNext` (3 min)
3. `NoteDispenser` z logiką `Dispense` (4 min)
4. `InsufficientFundsDispenser` jako Null Object (1 min)
5. `ATM` jako fasada (2 min)

### Testy (5 min)
Pokaż `Tests/ATMTests.cs` — zwróć uwagę na:
- Testowanie ogniwa w **izolacji** (bez łańcucha)
- Test integracyjny przez `ATM`
- Test stanu granicznego (brak banknotów)

### Diagrams do pokazania
- `05-wiekszy-przyklad/diagrams/cor_atm_class.png`
- `05-wiekszy-przyklad/diagrams/cor_atm_sequence.png`

---

## Blok 5 — Alternatywy i decyzja (15 min)

### Diagrams do pokazania
- `06-alternatywy-i-decyzja/diagrams/cor_decision_matrix.png`
- `06-alternatywy-i-decyzja/diagrams/cor_alternatives.png`

### Macierz porównawcza (na tablicy lub slajdzie)

```
Problem: nowe zamówienie → zapis + e-mail + SMS + analityka

  CoR:      email → db → (sms jeśli urgent)   ← może pominąć
  Observer: email, db, sms, analytics          ← zawsze wszyscy
  Strategy: StandardNotify lub UrgentNotify    ← jeden algorytm
  Decorator: AuditDec(SmsDec(EmailDec(Core)))  ← wszystkie warstwy
```

### Pytania do dyskusji
1. *"Jaka jest różnica między CoR a Decorator?"* → Behavioral vs Structural; przerwanie vs zawsze
2. *"Kiedy Observer jest LEPSZY od CoR?"* → Gdy nie można dopuścić do pominięcia odbiorcy
3. *"Jakie jest ryzyko stosowania długich łańcuchów CoR?"* → Trudne debugowanie, performance

---

## Blok 6 — Podsumowanie (10 min)

### Kluczowe wnioski
1. CoR rozdziela nadawcę od odbiorcy — jeden handler obsługuje, reszta przekazuje
2. Łańcuch można modyfikować w runtime — ogniwa są wymiennymi obiektami
3. W .NET CoR pojawia się jako Middleware, MediatR Behaviors, EventArgs.Handled
4. Preferuj **Null Object** jako ogniwo końcowe zamiast `if (_next != null)`
5. Wybierz CoR gdy: sekwencyjne przetwarzanie + możliwość przerwania

### Sygnały, że CoR jest właściwym wzorcem
- "Jeśli A nie obsłuży, przekaż do B"
- Zbiór handlerów rośnie / zmienia się w runtime
- Każde ogniwo ma różny warunek obsługi

### Sygnały, że należy wybrać coś innego
- Wszyscy muszą być zawsze powiadamiani → Observer
- Wymieniasz jeden algorytm → Strategy
- Dekorujesz bez możliwości przerwania → Decorator

---

## Pytania sprawdzające

1. Czym różni się `SetNext()` od konstruktora w `BaseHandler`?
2. Co to jest **Null Object** i jaką rolę pełni w CoR?
3. Napisz na tablicy interfejs `IHandler` z metodami `SetNext` i `Handle`.
4. Kiedy ogniwo **nie powinno** wołać `PassToNext`?
5. Jak ASP.NET Core Middleware implementuje CoR?

---

## Materiały dodatkowe dla studentów

- 📘 `01-idea-i-kontekst/README.md` — pełna historia i przykłady z .NET
- 🏦 `05-wiekszy-przyklad/` — kompletny przykład bankomatu z testami
- 🔀 `06-alternatywy-i-decyzja/` — porównanie wzorców z kodem
- 📝 `ZADANIA.md` — ćwiczenia do samodzielnego wykonania
