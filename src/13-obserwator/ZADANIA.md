# Zadania — Wzorzec Obserwator

## Zadania podstawowe

### Zadanie 1 — Inwestorzy na giełdzie

Zaimplementuj system powiadamiania inwestorów o zmianie ceny akcji.

**Wymagania:**
- Klasa `Share` (akcja) przechowuje symbol i cenę; obsługuje subskrypcję i wypisanie.
- Interfejs `IInvestor` z metodą `OnPriceChanged(string symbol, decimal price)`.
- Klasa `Investor` (imię, próg kupna `minBuy`, próg sprzedaży `maxSell`):
  - Gdy `price <= minBuy` → wypisuje "KUP".
  - Gdy `price >= maxSell` → wypisuje "SPRZEDAJ".
  - W przeciwnym razie → "Obserwuję".
- Dodaj conajmniej 3 inwestorów do akcji AAPL i zasymuluj 4 zmiany ceny.
- Po 2. zmianie jeden inwestor powinien się wypisać.

**Wskazówka:** Pamiętaj o bezpiecznej iteracji (`_observers.ToList()`).

---

### Zadanie 2 — System powiadomień e-mail

Zaimplementuj system powiadamiania po rejestracji nowego użytkownika.

**Wymagania:**
- Klasa `UserRegistrationService` z metodą `RegisterUser(string name, string email)`.
- Interfejs `IRegistrationObserver` z metodą `OnUserRegistered(string name, string email)`.
- Trzy obserwatory:
  - `WelcomeEmailSender` — wypisuje "Wysyłam e-mail powitalny do {email}".
  - `AdminNotifier` — wypisuje "Admin: nowy użytkownik {name}".
  - `AuditLogger` — wypisuje "AUDIT: rejestracja {name} o {czas}".
- Zasymuluj rejestrację 3 użytkowników, przy trzecim wypisz `AuditLogger`.

---

## Zadania średnie

### Zadanie 3 — Wyświetlacz Heat Index

Zaimplementuj `HeatIndexDisplay` obserwujący `WeatherStation` z Tematu 05.

**Wymagania:**
- Oblicz Heat Index według uproszczonej formuły NOAA (patrz [README Tematu 05](05-duzy-przyklad-i-alternatywy/README.md)).
- Wyświetlaj wynik w Celsius.
- Napisz test jednostkowy sprawdzający, że przy 35°C i 90% wilgotności Heat Index > 35°C.

**Wskazówka:** Formuła operuje na stopniach Fahrenheita — pamiętaj o konwersji.

---

### Zadanie 4 — Przepisanie Zadania 1 z użyciem zdarzeń C#

Przepisz Zadanie 1 (inwestorzy) używając mechanizmu zdarzeń C#.

**Wymagania:**
- Klasa `PriceChangedEventArgs : EventArgs` z właściwością `Price`.
- Klasa `Share` używa `event EventHandler<PriceChangedEventArgs>` zamiast listy obserwatorów.
- Subskrypcja przez `+=`, wypisanie przez `-=`.
- Zachowaj to samo zachowanie logiczne co w Zadaniu 1.

**Pytanie do refleksji:** Który wariant jest czytelniejszy? Kiedy zdarzenia C# są lepszym wyborem?

---

## Zadania zaawansowane

### Zadanie 5 — IObservable\<T\> i BCL

Zaimplementuj `TemperatureSensor` jako `IObservable<float>`.

**Wymagania:**
- Klasa `TemperatureSensor : IObservable<float>`.
- Klasa `Unsubscriber : IDisposable` do bezpiecznego wypisania.
- Trzy obserwatory implementujące `IObserver<float>`:
  - `AlarmObserver` — alarmuje gdy temperatura > 40°C.
  - `LogObserver` — loguje każdą wartość.
  - `AverageObserver` — oblicza i wypisuje bieżącą średnią.
- Zasymuluj serię pomiarów (18, 22, 25, 38, 42, 35).
- Po 4. pomiarze wypisz `AlarmObserver` przez `IDisposable.Dispose()`.

**Wskazówka:** Implementacja wzorowana na [Przykładach Tematu 04](04-typy-implementacji-i-wybor/Examples/Program.cs).

---

### Zadanie 6 — Procedura decyzyjna (analiza scenariuszy)

Dla każdego z poniższych scenariuszy uzasadnij wybór wzorca i wariantu implementacji:

1. System notyfikacji w aplikacji WPF — kliknięcie przycisku uruchamia walidację, spinner i wywołanie HTTP.
1. Czujnik GPS wysyłający pozycję 10×/s; chcesz filtrować ruch > 5 km/h i agregować co 5 sekund.
1. Moduł logowania mający logować każde wywołanie publicznej metody w serwisie.
1. Mikroserwis A publikuje zdarzenie "zamówienie złożone"; Mikroserwis B i C subskrybują bez wiedzy o A.
1. Dashboard akcji giełdowych: 50 akcji × 100 obserwujących inwestorów; dane zmieniają się 5×/s.

Dla każdego scenariusza podaj: **wzorzec/wariant** + **uzasadnienie** (2–3 zdania).

---

## Pytania kontrolne

1. Czym różni się model Push od modelu Pull w wzorcu Obserwator?
1. Dlaczego należy kopiować listę obserwatorów przed iteracją w `Notify()`?
1. Jakie ryzyko niesie `event` w C# jeśli nie wywołamy `-=`?
1. Kiedy użyć `IObservable<T>` zamiast ręcznego interfejsu?
1. Jaka jest różnica między Obserwatorem a Mediatorem?
1. W jakiej kolejności obserwatorzy otrzymują powiadomienia? Czy kolejność jest gwarantowana?
1. Co się stanie jeśli obserwator wyrzuci wyjątek w metodzie `Update()`? Jak to obsłużyć?
1. Kiedy Pub/Sub jest lepszym wyborem niż Obserwator?
