# Zadania — Łańcuch Zobowiązań

Skonsolidowane ćwiczenia dla wszystkich tematów modułu.

---

## Temat 01 — Idea i kontekst

### Z1.1 Prosta autoryzacja
Zaimplementuj łańcuch `IpBlockHandler → RateLimitHandler → TokenHandler`. Każde ogniwo powinno móc zatrzymać żądanie i zwrócić komunikat błędu. Przetestuj: żądanie z zablokowanego IP, zbyt wiele żądań na minutę, brak tokenu.

### Z1.2 Wstawienie dynamiczne
Do istniejącego łańcucha `A → B → C` wstaw `AuditHandler` między `B` a `C` w czasie działania programu (runtime).

---

## Temat 02 — Kiedy stosować

### Z2.1 Drzewo decyzyjne
Dla każdego z poniższych problemów wskaż, czy CoR jest właściwym rozwiązaniem i uzasadnij:
- a) Walidacja danych wejściowych formularza
- b) Obliczanie ceny z rabatami (kilka reguł rabatowych)
- c) Wysłanie powiadomienia do wszystkich menedżerów
- d) Przetwarzanie żądania HTTP w frameworku webowym

### Z2.2 Event Bubbling
Zaimplementuj CoR symulujący bąbelkowanie zdarzeń w GUI: `Button → Panel → Window`. Kliknięcie na `Button` powinno być obsłużone przez `Button`, ale klawisz Escape powinien trafić aż do `Window`.

---

## Temat 03 — Struktura GoF

### Z3.1 NullObject jako ogniwo końcowe
Zaimplementuj klasę `FallbackHandler`, która zawsze przetwarza żądanie (np. zwraca odpowiedź domyślną). Użyj go jako ostatniego ogniwa zamiast sprawdzania `if (_next != null)`.

### Z3.2 Odwracanie łańcucha
Masz łańcuch `A → B → C`. Napisz metodę `Reverse()`, która zmienia kolejność na `C → B → A` bez modyfikacji klas handlerów.

---

## Temat 04 — Typy implementacji

### Z4.1 Delegatowy Pipeline z cofaniem
Rozszerz `DelegatePipeline<TInput, TOutput>` o możliwość obsługi błędów — jeśli ogniwo rzuci wyjątek, loguj go i kontynuuj (lub zatrzymaj — do wyboru).

### Z4.2 IPipelineBehavior — Retry
Zaimplementuj `RetryBehavior<TReq, TRes>`, który przy błędzie ponawia wywołanie `next()` do N razy z wykładniczym czasem oczekiwania (używając symulacji `await Task.Delay`).

---

## Temat 05 — Większy przykład (Bankomat)

### Z5.1 Nowy nominał 500 zł
Dodaj obsługę banknotu 500 zł. Upewnij się, że testy nadal przechodzą. Napisz dodatkowy test dla wypłaty 1000 zł.

### Z5.2 Stan graniczny — brak banknotów
Napisz test: ATM z `[200]=1, [100]=0, [50]=0, [20]=0, [10]=0` próbuje wypłacić 400 zł. Oczekiwany wynik: `Success=false`.

### Z5.3 Logowanie wypłat
Dodaj `AuditDispenser` (dekorator), który loguje każdą operację `Dispense` do listy w pamięci. Napisz test sprawdzający, że lista zawiera wpis po wypłacie.

---

## Temat 06 — Alternatywy

### Z6.1 CoR vs Observer
Zaimplementuj ten sam scenariusz (powiadomienie o zamówieniu) raz jako CoR, raz jako Observer. Opisz, jak zmienić CoR tak, żeby zachowywał się jak Observer (wszyscy obsługują).

### Z6.2 Wybór wzorca — uzasadnienie
Dla każdego scenariusza wskaż najlepszy wzorzec i uzasadnij:
- a) Middleware HTTP z logowaniem i autentykacją
- b) System powiadomień — e-mail, push, SMS wszystkie naraz
- c) Kalkulator z wymiennym algorytmem zaokrąglania
- d) Opakowanie zapytania do bazy o cache i retry

---

## Projekt końcowy

Zaimplementuj **system obsługi zgłoszeń IT** (help desk):

1. Zgłoszenie przechodzi przez łańcuch: `SpamFilter → Classifier → PriorityEscalation → AgentAssignment`
2. Każde ogniwo może zatrzymać zgłoszenie lub przekazać dalej
3. Użyj dowolnego typu implementacji (OOP lub Middleware)
4. Napisz co najmniej 5 testów jednostkowych
5. Przygotuj diagram klas (puml)
