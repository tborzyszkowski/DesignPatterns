# Materiały do wykładu — Wzorzec Mediator

## Plan wykładu (90 minut)

| Blok | Czas | Temat |
|------|------|-------|
| 1 | 0–15 min | Problem i motywacja |
| 2 | 15–30 min | Definicja, historia, kontekst |
| 3 | 30–45 min | Struktura GoF — diagram i kod |
| 4 | 45–60 min | Typy implementacji |
| 5 | 60–75 min | Wady, zalety, alternatywy |
| 6 | 75–90 min | Przykład ATC + podsumowanie |

---

## Blok 1 — Problem (0–15 min)

### Pytanie otwierające do studentów:
> "Wyobraźcie sobie aplikację z 6 komponentami UI, które muszą reagować na zmiany w innych. Ile linii kodu potrzeba, żeby to obsłużyć?"

### Demonstracja problemu:
Narysuj na tablicy siatkę 6 komponentów z liniami między każdą parą → `6*(6-1)/2 = 15` zależności.

### Slajd: Siatka zależności vs. Hub

```
PROBLEM: N*(N-1)/2 połączeń        ROZWIĄZANIE: N połączeń
A ←→ B ←→ C                        A ──→ M ←── B
↕ ↗ ↕ ↘ ↕                                  ↑
D ←→ E ←→ F                        C ──→ M ←── D
```

### Kod problemu (pokazać 2 minuty):
```csharp
class Button {
    private TextInput _input;     // ← zna TextInput
    private Checkbox _remember;   // ← zna Checkbox
    private Label _error;         // ← zna Label
    // ...zmiana w Button → zmiany wszędzie
}
```

---

## Blok 2 — Definicja i historia (15–30 min)

### Definicja GoF:
> "Zdefiniuj obiekt, który hermetyzuje sposób interakcji zbioru obiektów. Mediator zapewnia luźne sprzężenie, zapobiegając bezpośredniemu odwoływaniu się obiektów do siebie."

### Oś czasu (diagram):
- 1994 — GoF: Gang of Four, pierwsze formalne opisanie
- 2000 — J2EE Session Facade (Mediator w warstwie serwisowej)
- 2003 — MVC: Controller jako mediator między Model i View
- 2010 — CQRS: Command/Query Separation
- 2016 — MediatR: popularna implementacja w .NET
- 2020 — SignalR Hubs, Blazor EventCallbacks

### Pytanie dyskusyjne:
> "Gdzie w frameworkach, których używacie na co dzień, widzicie Mediator?"

Oczekiwane odpowiedzi: ASP.NET Controller, EventAggregator (Prism), MediatR, SignalR Hub.

---

## Blok 3 — Struktura GoF (30–45 min)

### Diagram klas na tablicy:
```
«interface»
IMediator
  + Notify(sender, event)
       △
       │
ConcreteMediator ──→ ColleagueA
      └──────────→ ColleagueB
                        △
                    BaseColleague
                   # mediator: IMediator
```

### Kod na żywo (10 minut):
Pokazać `LoginDialog` z tematu 01 — od zera:
1. Interfejs `IDialogMediator`
2. Klasa `UIComponent` z `SetMediator`
3. `Button`, `TextInput`
4. `LoginDialogMediator.Notify` z pattern matching

### Kluczowe obserwacje dla studentów:
- Uczestnik (`Button`) zna tylko **interfejs** `IDialogMediator`, nie `LoginDialogMediator`
- Cała logika "co po kliknięciu" jest w Mediatorze, nie w `Button`
- Możliwość wymiany Mediatora bez zmiany `Button`

---

## Blok 4 — Typy implementacji (45–60 min)

### Zestawienie na slajdzie:

| Typ | Kiedy | Przykład |
|-----|-------|---------|
| Klasyczny GoF | Dialog z konkretnymi typami | `LoginDialog` |
| Delegaty | Luźne sprzężenie, dynamic | `EventBus` |
| MediatR | CQRS, API | `IMediator.Send()` |
| Hub | Real-time WebSocket | `SignalR Hub` |

### Demonstracja MediatR (5 minut):
```csharp
// Command
record CreateOrder(string ProductId) : IRequest<OrderDto>;

// Handler
class CreateOrderHandler : IRequestHandler<CreateOrder, OrderDto> {
    public Task<OrderDto> Handle(CreateOrder cmd, CancellationToken ct) { ... }
}

// Wywołanie
var order = await mediator.Send(new CreateOrder("PROD-001"));
```

### Pipeline Behaviors — concept:
```
Request → [Logging] → [Validation] → [Transaction] → Handler
                                                          ↓
Response ← [Logging] ← [Validation] ← [Transaction] ← result
```

---

## Blok 5 — Wady, zalety, alternatywy (60–75 min)

### Ćwiczenie: "Który wzorzec?"
Daj studentom 4 scenariusze (2 minuty każdy):
1. N komponentów UI — **Mediator**
2. Powiadom wszystkich o nowym wpisie — **Observer**
3. Uproszczone API do subsystemu — **Facade**
4. Walidacja → płatność → wysyłka — **CoR**

### God Object — anty-wzorzec:
```csharp
// ❌ ZŁY Mediator
class GodMediator {
    public void Notify(object s, string e) {
        // 500 linii switch...
    }
}

// ✔ DOBRY podział
class AuthMediator { /* login, logout */ }
class OrderMediator { /* zamówienia */ }
class ShipmentMediator { /* wysyłka */ }
```

### Pytanie dyskusyjne:
> "Kiedy Mediator staje się anty-wzorcem? Co mówi Zasada Jednej Odpowiedzialności?"

---

## Blok 6 — Przykład ATC + podsumowanie (75–90 min)

### Demonstracja na żywo:
Uruchomić `06-wiekszy-przyklad/Examples` — pokazać output i wyjaśnić:
- Jak `LOT101` nie wie o `Runway01`
- Jak wieża zarządza kolejką
- Jak działa priorytet dla dużych samolotów

### Testy xUnit (2 minuty):
```bash
cd src/19-mediator/06-wiekszy-przyklad/Tests
dotnet test --verbosity normal
```

### Podsumowanie — diagram na tablicy:
```
Problem: N*(N-1)/2 zależności
   ↓
Rozwiązanie: IMediator + Colleagues
   ↓
Implementacje: GoF / Delegaty / MediatR / Hub
   ↓
Unikaj: God Object — dziel na mniejsze mediatory
   ↓
Alternatywy: Observer (broadcast), Facade (uproszczenie), CoR (sekwencja)
```

---

## Pytania do dyskusji

1. Czy `Controller` w MVC to Mediator? Uzasadnij.
2. Jaką rolę pełni `EventAggregator` w aplikacjach MVVM?
3. Czy można łączyć Mediator z Observerem? Podaj przykład.
4. Jak przetestować ConcreteMediator bez uruchamiania wszystkich uczestników?

---

## Materiały dodatkowe

- Kod źródłowy: `src/19-mediator/`
- Stara wersja: `old_version/19Mediator/`
- [Refactoring Guru — Mediator](https://refactoring.guru/design-patterns/mediator)
- [MediatR GitHub](https://github.com/jbogard/MediatR)
- [SignalR Hubs](https://learn.microsoft.com/aspnet/core/signalr/hubs)
