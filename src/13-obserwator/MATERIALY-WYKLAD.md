# Materiały do wykładu — Wzorzec Obserwator

> **Czas wykładu:** ok. 90 minut (+ 15 minut pytania)
> **Poziom:** intermediate (studenci znają dziedziczenie, interfejsy, delegaty)
> **Cel:** Zrozumienie wzorca Obserwator — motywacja, struktura GoF, warianty C#, kiedy stosować

---

## Agenda wykładu

| Czas | Blok | Forma |
|---|---|---|
| 0–10 min | Rozgrzewka i problem | Dyskusja |
| 10–25 min | Idea i rozwiązanie GoF | Wykład + diagram |
| 25–35 min | Push vs Pull | Wykład + porównanie |
| 35–50 min | Trzy warianty C# | Live coding |
| 50–65 min | Duży przykład: Stacja Pogodowa | Demo |
| 65–75 min | Kiedy stosować, kiedy nie | Dyskusja |
| 75–85 min | Alternatywy | Wykład |
| 85–90 min | Podsumowanie i pytania | |

---

## Blok 1 — Rozgrzewka (0–10 min)

### Pytanie otwierające do studentów

> "Wyobraźcie sobie aplikację pogodową. Mamy jeden czujnik temperatury.
> Dane muszą trafiać do: wyświetlacza LCD, aplikacji mobilnej i systemu alarmowego.
> **Jak byście to zaimplementowali bez żadnego wzorca?**"

Czekaj na odpowiedzi. Typowe propozycje studentów:
- "Wywołamy metody wyświetlaczy bezpośrednio z czujnika."
- "Użyjemy statycznych metod."

### Pokaż problem (kod naiwny)

```csharp
class WeatherStation
{
    private LcdDisplay _lcd;
    private MobileApp _mobile;
    private AlarmSystem _alarm;

    public void SetTemperature(float temp)
    {
        _lcd.ShowTemperature(temp);
        _mobile.UpdateTemperature(temp);
        _alarm.CheckTemperature(temp);
        // Co gdy pojawi się nowy wyświetlacz? Musimy MODYFIKOWAĆ czujnik!
    }
}
```

**Pytanie:** "Co się stanie gdy klient zamówi 4. wyświetlacz? Albo gdy mobilna aplikacja jest opcjonalna?"

Odpowiedź: naruszenie OCP, ścisłe powiązanie (tight coupling), nieelastyczny design.

---

## Blok 2 — Idea i rozwiązanie GoF (10–25 min)

### Analogia z życia

> "Wyobraźcie sobie subskrypcję newslettera.
> Gazeta (Subject) nie wie nic o czytelnikach (Observer).
> Czytelnicy sami się subskrybują i wypisują.
> Gazeta wysyła nowe wydanie do wszystkich subskrybentów."

### Rozwiązanie: interfejs + lista

Pokaż diagram klas GoF z [03-struktura-gof-i-jak-dziala/diagrams/01-class-gof.puml](03-struktura-gof-i-jak-dziala/diagrams/01-class-gof.puml).

```csharp
interface IWeatherObserver
{
    void Update(WeatherData data);
}

class WeatherStation
{
    private List<IWeatherObserver> _observers = new();

    public void Subscribe(IWeatherObserver obs) => _observers.Add(obs);
    public void Unsubscribe(IWeatherObserver obs) => _observers.Remove(obs);

    public void SetMeasurements(float temp, float hum, float press)
    {
        var data = new WeatherData(temp, hum, press);
        foreach (var obs in _observers.ToList())
            obs.Update(data);
    }
}
```

**Podkreśl:** czujnik nie zna konkretnych klas wyświetlaczy — zna tylko interfejs `IWeatherObserver`.

### Pytanie sprawdzające

> "Kto w tym wzorcu 'musi wiedzieć' o istnieniu obserwatora?"

Odpowiedź: tylko Subject trzyma listę. Observer nie wie o innych observerach.

---

## Blok 3 — Push vs Pull (25–35 min)

### Kluczowe pytanie

> "W metodzie `Update()` — kto dostarcza dane do Observera?"

Pokaż oba warianty z [03-struktura-gof-i-jak-dziala/Examples/Program.cs](03-struktura-gof-i-jak-dziala/Examples/Program.cs).

**Push:** `void Update(float temp, float hum, float press)` — Subject decyduje co wysyła.

**Pull:** `void Update(IWeatherData source)` — Observer bierze co potrzebuje.

### Tabela porównawcza (narysuj na tablicy)

```
                    PUSH            PULL
Interface Update    Update(data)    Update(source)
Dane                Snapshot        Observer pobiera na żądanie
Spójność            Gwarantowana    Może być niespójna
Elastyczność        Niska           Wysoka
Zależność           Mała            Observer → ISubject
```

### Pytanie do grupy

> "Kiedy Pull może dać niespójne dane?"

Odpowiedź: gdy Subject zmieni stan między `NotifyAll()` a momentem gdy Observer woła `source.Temperature`.

---

## Blok 4 — Live coding: trzy warianty C# (35–50 min)

Otwórz [04-typy-implementacji-i-wybor/Examples/Program.cs](04-typy-implementacji-i-wybor/Examples/Program.cs).

### Wariant 1 — Ręczny interfejs

Napisz z grupą od zera (ok. 5 min):
- `ITempObserver` z `OnTemperatureChanged(float)`.
- `TemperatureSensor` z listą i `Subscribe/Unsubscribe`.
- `Display` implementujący `ITempObserver`.

### Wariant 2 — Zdarzenia C#

```csharp
public event EventHandler<TempChangedEventArgs>? TemperatureChanged;
// += i -= zamiast Subscribe/Unsubscribe
```

**Pokaż wyciek pamięci** — obserwator zarejestrowany ale nie wypisany.

### Wariant 3 — IObserver\<T\> BCL

Pokaż kontrakt z BCL:
- `OnNext(T)` — normalne dane
- `OnError(Exception)` — błąd
- `OnCompleted()` — koniec strumienia

**Ważna uwaga:** `IDisposable` z `Subscribe()` zastępuje ręczne `-=`.

---

## Blok 5 — Demo: Stacja Pogodowa (50–65 min)

Uruchom: `cd src/13-obserwator/05-duzy-przyklad-i-alternatywy/Examples && dotnet run`

Omów każdy wyświetlacz:
- `CurrentConditionsDisplay` — bieżące warunki.
- `StatisticsDisplay` — min/max/avg.
- `ForecastDisplay` — prognoza z deltą ciśnienia.
- `HeatIndexDisplay` — formuła NOAA, konwersja Celsius ↔ Fahrenheit.

Pokaż wypisanie `HeatIndexDisplay` po 2. pomiarze — podkreśl że czujnik nie wie o tej zmianie.

Uruchom testy: `cd Tests && dotnet test --verbosity normal`

Omów test `Unsubscribe_DuringNotification_DoesNotThrow` — dlaczego kopiujemy listę.

---

## Blok 6 — Kiedy stosować, kiedy nie (65–75 min)

Pokaż diagram z [02-kiedy-stosowac-zalety-wady/diagrams/01-decision-tree.puml](02-kiedy-stosowac-zalety-wady/diagrams/01-decision-tree.puml).

### Scenariusze do dyskusji (poproś studentów o decyzję)

1. "Aplikacja WPF — kliknięcie przycisku obsługuje walidacja + HTTP."
   → zdarzenia C# (konwencja .NET)

1. "GPS 10×/s — filtruj prędkość > 5 km/h, agreguj co 5 sek."
   → `IObservable<T>` / Rx.NET

1. "Logowanie każdego wywołania metody w serwisie."
   → AOP / Dekorator (nie Obserwator!)

1. "Konfiguracja ładowana raz na start."
   → prosta zależność (nie Obserwator!)

---

## Blok 7 — Alternatywy (75–85 min)

Pokaż diagram [05-duzy-przyklad-i-alternatywy/diagrams/03-alternatives.puml](05-duzy-przyklad-i-alternatywy/diagrams/03-alternatives.puml).

### Mediator

> "Co gdy obserwatory muszą komunikować się ze sobą?"

Przykład: w systemie chatroom każdy użytkownik wysyła wiadomości do mediatora, który rozsyła do pozostałych. Obserwator jest tu niewystarczający — Subject byłby sprzężony ze wszystkimi.

### Pub/Sub

> "Co gdy producent i konsument żyją w różnych serwisach?"

Przykład: zamówienie złożone (Serwis A) → Message Bus → Powiadomienie (Serwis B) + Faktura (Serwis C). Obserwator wymaga referencji — tutaj broker pośredniczy.

### Polling

> "Kiedy push jest za drogi?"

Przykład: plik konfiguracyjny sprawdzany co minutę. Zmiana rzadka, polling tani.

---

## Blok 8 — Podsumowanie (85–90 min)

### Wzorzec w jednym zdaniu

> "Obserwator definiuje zależność jeden-do-wielu między obiektami: gdy Subject zmienia stan, wszyscy zarejestrowani Observerzy są automatycznie powiadamiani."

### Kluczowe punkty do zapamiętania

1. Subject zarządza listą Observer przez **interfejs** — nigdy przez konkretne klasy.
1. **Push** — Subject wysyła dane; **Pull** — Observer pobiera dane ze Subject.
1. Trzy warianty C#: ręczny interfejs / zdarzenia / `IObservable<T>`.
1. Zawsze **kopiuj listę** obserwatorów przed iteracją.
1. Przy `event` — zawsze **wypisuj** (`-=`) lub używaj `IDisposable`.
1. Jeśli obserwatory komunikują się ze sobą → **Mediator**; jeśli różne procesy → **Pub/Sub**.

### Pytania końcowe do studentów

- "Jaka jest różnica między Obserwatorem a wzorcem Mediator?"
- "Kiedy `IObservable<T>` jest lepszym wyborem niż ręczny interfejs?"
- "Co się stanie gdy Observer rzuci wyjątek w `Update()`?"

---

## Materiały dodatkowe dla studentów

- Zadania: [ZADANIA.md](ZADANIA.md)
- Kod 01: [01-idea-i-kontekst/Examples/Program.cs](01-idea-i-kontekst/Examples/Program.cs)
- Kod 02: [02-kiedy-stosowac-zalety-wady/Examples/Program.cs](02-kiedy-stosowac-zalety-wady/Examples/Program.cs)
- Kod 03: [03-struktura-gof-i-jak-dziala/Examples/Program.cs](03-struktura-gof-i-jak-dziala/Examples/Program.cs)
- Kod 04: [04-typy-implementacji-i-wybor/Examples/Program.cs](04-typy-implementacji-i-wybor/Examples/Program.cs)
- Kod 05: [05-duzy-przyklad-i-alternatywy/Examples/Program.cs](05-duzy-przyklad-i-alternatywy/Examples/Program.cs)
- Literatura: GoF s. 293–313; Head First Design Patterns rozdz. 2; https://refactoring.guru/design-patterns/observer
