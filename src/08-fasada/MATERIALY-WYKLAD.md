# Materialy wykladowe - Wzorzec Fasada (Facade)

## Cel wykladu

Przekazać wiedzę o wzorcu Fasada: motywacje, role, typy implementacji, kryteria decyzji
i zwiazek z ACL, bezpieczeństwem oraz bibliotekami standardowymi.

## Plan wykładu (90 minut)

1. Motywacja: problem zlozonosci klienta i eksplozja zaleznosci (15 min).
2. Idea Fasady: uproszczenie, ukrywanie, jeden punkt wejscia (10 min).
3. Formalna struktura GoF: role i przeplyw wywołań (20 min).
4. Typy implementacji: prosta, aplikacyjna, bezpieczeństwa, ACL, async (20 min).
5. Wiekszy przyklad end-to-end i alternatywy (15 min).
6. Fasady w bibliotekach standardowych (.NET) (10 min).

## Material do tablicy / slajdow

### Slajd 1 — Problem bez fasady

Klient bezposrednio:

1. Wywoluje AuthService.Authorize.
2. Pobiera dane z InventoryService.HasStock.
3. Oblicza cene przez PricingService.Calculate.
4. Laduje platnosc przez PaymentService.Charge.
5. Tworzy wysylke przez ShippingService.Create.
6. Wysyla powiadomienie przez NotificationService.Send.

Efekt: logika powtarza sie w kazdym kliencie, zmiana podsystemu uderza we wszystkich.

### Slajd 2 — Idea Fasady

Fasada daje:

1. Jeden prosty kontrakt klienta: `PlaceOrder(request)`.
2. Ukryta kolejnosc krokow, walidacja, obsluga bledow.
3. Stabilne API nawet gdy subsystemy ewoluuja.

Klient wie tylko tyle ile musi — reszte ukrywa fasada.

### Slajd 3 — Formalna struktura GoF

Trzy role:

1. Client — zna tylko interfejs fasady.
2. Facade — koordynuje wywolania subsystemow.
3. Subsystem A / B / C — realizuja konkretne operacje.

Zasada: fasada nie staje sie pielgrzymem subsystemu, deleguje i koordynuje.

### Slajd 4 — Typy implementacji

1. Prosta (proceduralna) — jedna klasa, metoda use-case, bez stanu.
   Kiedy: mala skala, prosta orkiestracja.

2. Aplikacyjna (use-case) — mapowanie DTO, walidacja, polityki bledow domenowych.
   Kiedy: warstwa aplikacji w DDD, CQRS.

3. Bezpieczeństwa (secure facade) — autoryzacja, audyt, maskowanie danych.
   Kiedy: operacje administracyjne, dane wrazliwe.

4. Integracyjna z ACL — tlumaczenie kontraktow systemu zewnetrznego.
   Kiedy: integracja z obcym API o innym modelu domenowym.

5. Asynchroniczna — orkiestracja Task, timeout, retry.
   Kiedy: kroki I/O-bound, wysoka skalowalnosc.

### Slajd 5 — Fasada vs alternatywy

Fasada: prosty synchroniczny use-case, zlozony wewnetrzny orkiestrator.

Mediator: wielokierunkowa komunikacja wielu komponentow.

Application Service: fasada w warstwie aplikacji DDD z transakcja.

API Gateway / BFF: granica systemowa, wielu klientow zewnetrznych.

Workflow / Saga: dlugotrwaly proces, transakcje rozproszone.

### Slajd 6 — Najczestsze pulapki

1. God object: fasada rosnaca bez granicy — podziel na wyspecjalizowane fasady.
2. Przeciek subsystemu: fasada zwraca wyjatki techniczne zamiast domenowych.
3. Mylenie z Adaptera: Adapter laczy niezgodne API, Fasada upraszcza zlozony system.
4. Fanout bez fasady: ten sam przeply powielony w wielu klientach.

## FAQ

### Czym rozni sie Fasada od Adaptera?

Adapter pozwala wspolpracowac niezgodnym interfejsom — naprawia niedopasowanie.
Fasada upraszcza dostep do zlozonegu subsystemu — redukuje wiedze klienta.
Mozna laczyc oba: fasada wywoluje wewnatrz adapter do obcego API.

### Czym rozni sie Fasada od ACL?

Fasada redukuje zlozonosc i ukrywa orchestracje.
ACL (Anti-Corruption Layer) tlumaczy model pojecia obcego systemu na model domenowy.
W praktyce fasada moze zawierac komponenty ACL, gdy integruje zewnetrzny system.

### Jak testowac fasade?

1. Testuj przez interfejs fasady, nie przez szczegoly subsystemow.
2. Wstrzykuj makiety subsystemow przez konstruktor.
3. Sprawdzaj kontrakt wyjscia: sukces, rozne tryby bledu, brak przecieku wyjatkow technicznych.

### Kiedy fasada staje sie god object?

Gdy ma wiecej niz kilka odrebnych obszarow biznesowych.
Sygnal: metody fasady nie maja ze soba nic wspolnego.
Rozwiazanie: podziel na wyspecjalizowane fasady z jasno zdefiniowanym use-case.

### Jak HttpClient jest fasada?

HttpClient ukrywa HTTP handlers, pooling polaczen, serializacje, timeouty.
Klient wywoluje tylko `GetAsync`, `PostAsync` — nie zna wewnetrznej maszyny stanow.
To przyklad fasady ewoluujacej razem z platformou, nie klasyczny GoF 1:1.

## Literatura

1. GoF, Design Patterns, rozdzial Facade.
2. Refactoring.Guru (Facade): https://refactoring.guru/design-patterns/facade
3. Martin Fowler, Anti-Corruption Layer: https://martinfowler.com/bliki/AntiCorruptionLayer.html
4. Microsoft Docs, HttpClient: https://learn.microsoft.com/dotnet/api/system.net.http.httpclient
5. Microsoft Docs, ILogger: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger
