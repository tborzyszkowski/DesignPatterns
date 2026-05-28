# Zadania — Wzorzec Mediator

## Temat 01 — Idea i kontekst

### Z01.1 — Identyfikacja problemu
Dane klasy formularza rejestracji:
```csharp
class RegistrationForm {
    private Button _submit;
    private TextInput _email, _username, _password, _confirmPassword;
    private Checkbox _acceptTerms;
    private MessageLabel _error;
    // Każda klasa zna wszystkie pozostałe
}
```
a) Ile par bezpośrednich zależności tworzy ta struktura?  
b) Zastosuj wzorzec Mediator. Narysuj diagram klas przed i po.

### Z01.2 — Rys historyczny
Dlaczego w erze J2EE (2000) wzorzec Mediator zyskał szczególne znaczenie? Jakie problemy warstw aplikacji rozwiązywał?

---

## Temat 02 — Kiedy stosować

### Z02.1 — Oceń scenariusze
Czy zastosować Mediator? Uzasadnij:
- a) Kalkulacja pensji pracownika (wzór)
- b) Panel sterowania samochodem (klimatyzacja ↔ ogrzewanie ↔ radio)
- c) System alertów dla 1000 subskrybentów
- d) Wyszukiwarka z filtrami (cena, kategoria, ocena) wzajemnie na siebie wpływającymi

### Z02.2 — Event Bus z Unsubscribe
Rozszerz `SimpleEventBus` o `Unsubscribe<T>`. Napisz test:
```csharp
var count = 0;
var unsub = bus.Subscribe<MyEvent>(_ => count++);
bus.Publish(new MyEvent());   // count == 1
unsub.Dispose();
bus.Publish(new MyEvent());   // count nadal == 1
Assert.Equal(1, count);
```

---

## Temat 03 — Struktura GoF

### Z03.1 — Nowy uczestnik
Dodaj `FuelTruck` do systemu kontroli lotniczej z tematu 03. Reguła: gdy `FuelTruck` zgłosi gotowość, wieża powinna poinformować czekający samolot.

### Z03.2 — Mapowanie ról
Wskaż role GoF (Mediator/Colleague) dla:
- a) `IHubContext<T>` / `Hub<T>` w SignalR
- b) `EventAggregator` / `ViewModel` w Caliburn.Micro
- c) `IMediator` / `IRequestHandler` w MediatR

---

## Temat 04 — Typy implementacji

### Z04.1 — Wybór implementacji
Dla każdego scenariusza wybierz typ i uzasadnij:
- a) API zamówień z walidacją, logowaniem i transakcją
- b) Formularz meldunkowy w WPF
- c) Czat real-time dla 500 użytkowników
- d) System aukcyjny z broadcast'em ceny

### Z04.2 — Pipeline Behavior
Dodaj do `FunctionalMediator` middleware walidacyjny:
```csharp
pipeline.Use(ValidationMiddleware.Create(msg => {
    if (msg.Payload.Length > 100)
        throw new InvalidOperationException("Wiadomość za długa");
}));
```

---

## Temat 05 — Wady, zalety, alternatywy

### Z05.1 — Refaktoryzacja God Object
Dany God Mediator:
```csharp
class AppMediator {
    public void Notify(object s, string e) {
        if (e is "login" or "logout") { /* 50 linii */ }
        if (e is "order_placed" or "order_paid") { /* 80 linii */ }
        if (e is "item_shipped" or "item_returned") { /* 60 linii */ }
    }
}
```
Podziel go na 3 wyspecjalizowane mediatory. Pokaż diagram przed i po.

### Z05.2 — Czat: Mediator vs Observer
Zaimplementuj prosty czat dwoma sposobami:
- Mediator (unicast + broadcast)
- Observer (tylko broadcast)
Wyjaśnij różnicę w możliwościach.

---

## Temat 06 — Projekt końcowy

### Z06.P — Smart Home Hub ★★★

Zaimplementuj system Smart Home używając wzorca Mediator:

**Uczestnicy:**
- `SmartLamp` — włącz/wyłącz, jasność
- `Thermostat` — temperatura, tryb (grzanie/chłodzenie)
- `SecurityAlarm` — aktywuj/dezaktywuj, alerty
- `SmartLock` — zablokuj/odblokuj drzwi
- `PresenceSensor` — wykrywa obecność w domu

**Scenariusze do obsłużenia przez Hub:**
1. Wychodząc z domu (`PresenceSensor` → brak osoby): wyłącz lampy, zablokuj drzwi, aktywuj alarm
2. Wchodząc do domu: odblokuj drzwi, dezaktywuj alarm, włącz oświetlenie
3. Alarm włączony + ktoś w domu: powiadom właściciela

**Wymagania:**
- Interfejs `ISmartHomeHub` jako Mediator
- Klasa bazowa `SmartDevice` jako Colleague
- Co najmniej 15 testów xUnit

---

## Pytania na egzamin

1. Czym różni się Mediator od Fasady? Podaj przykład każdego.
2. Co to jest "God Object" w kontekście Mediatora? Jak mu zapobiec?
3. Kiedy użyjesz Observer zamiast Mediatora?
4. Jakie wzorce .NET/ASP.NET Core implementują koncepcję Mediatora?
5. Opisz sekwencję wywołań: Colleague → Mediator → inny Colleague.
