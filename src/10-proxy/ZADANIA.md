# ZADANIA - Wzorzec Proxy

## Zadanie 1 - Protection Proxy

**Scenariusz:** System CMS. Metoda `PublishArticle()` może być wywołana tylko przez `Editor` i `Admin`. Metoda `DeleteArticle()` tylko przez `Admin`.

Wymagania:

1. Zdefiniuj `IArticleService` z metodami `GetArticle()`, `PublishArticle()`, `DeleteArticle()`.
1. Zaimplementuj `RealArticleService`.
1. Napisz `ArticleServiceProxy` sprawdzający rolę przed każdą operacją.
1. Pokaż 3 konteksty: `Viewer`, `Editor`, `Admin` i oczekiwane efekty.

Rozwiązanie (skrót):

1. Proxy sprawdza rolę w pre-checku, rzuca `UnauthorizedAccessException` przy braku uprawnienia.
1. `RealArticleService` nie zna zasad autoryzacji — SRP zachowane.
1. Test: `Viewer.PublishArticle()` => wyjątek; `Editor.PublishArticle()` => sukces; `Admin.DeleteArticle()` => sukces.

## Zadanie 2 - Virtual Proxy

**Scenariusz:** Edytor dokumentów. Duży plik PDF (50 MB) jest ładowany z dysku. Użytkownik może przejrzeć listę dokumentów, ale otworzyć tylko wybrany.

Wymagania:

1. Zdefiniuj `IDocument` z metodami `Open()` i `GetTitle()`.
1. `RealDocument` ładuje plik w konstruktorze (symulacja `Thread.Sleep(500)`).
1. `DocumentProxy` zwraca `GetTitle()` bez ładowania pliku; ładuje plik dopiero przy `Open()`.
1. Pokaż: tworzenie 5 proxy, wywołanie `GetTitle()` dla wszystkich, `Open()` tylko dla jednego.

Rozwiązanie (skrót):

1. `_real ??= RealDocument.Load(_path)` w `Open()`.
1. `GetTitle()` zwraca zapamiętany tytuł bez tworzenia `RealDocument`.
1. Output: 5x title bez I/O; 1x loading przy `Open()`.

## Zadanie 3 - Caching Proxy

**Scenariusz:** API kursów walut. Wywołanie zewnętrzne trwa 400 ms. Ta sama waluta jest pytana wielokrotnie w ciągu minuty.

Wymagania:

1. Zdefiniuj `IExchangeRateService` z metodą `GetRate(string currency): decimal`.
1. `RealExchangeRateService` symuluje opóźnienie `Thread.Sleep(400)`.
1. `CachingExchangeRateProxy` przechowuje wyniki w `Dictionary<string, (decimal rate, DateTime expires)>` z TTL 60 s.
1. Pokaż: 3 zapytania o EUR (pierwsze = miss, dwa następne = hit), 1 zapytanie o USD (miss).

Rozwiązanie (skrót):

1. Cache sprawdza `expires > DateTime.UtcNow`; przy trafieniu zwraca rate bez delegacji.
1. Log: `[CACHE MISS] EUR`, `[CACHE HIT] EUR`, `[CACHE HIT] EUR`, `[CACHE MISS] USD`.

## Zadanie 4 - Remote Proxy

**Scenariusz:** Serwis pogodowy dostępny przez HTTP. Klient ma wywoływać `IWeatherService.GetForecast(city)` jak lokalny obiekt.

Wymagania:

1. Zdefiniuj `IWeatherService` z metodą `GetForecast(string city): string`.
1. `WeatherServiceProxy` symuluje wywołanie HTTP (log + `Thread.Sleep(100)`) i zwraca stub.
1. Klient wywołuje `IWeatherService` — nie wie, że to sieć.

Rozwiązanie (skrót):

1. Proxy ukrywa `HttpClient` (lub symulację) za interfejsem.
1. Klient nie zna URL ani szczegółów HTTP.

## Zadanie 5 - Dynamic Proxy C#

**Scenariusz:** Masz wiele interfejsów serwisowych. Chcesz zmierzyć czas wykonania każdej metody bez pisania osobnej klasy Proxy dla każdego.

Wymagania:

1. Zdefiniuj `IOrderService` i `IInventoryService` z kilkoma metodami.
1. Napisz `TimingProxy<T> : DispatchProxy` logujący czas w milisekundach.
1. Użyj `ProxyFactory.Create<T>(real)` dla obu serwisów.
1. Wywołaj metody — w logach widoczne czasy dla obu interfejsów.

Rozwiązanie (skrót):

1. `override Invoke`: `Stopwatch.StartNew()` -> `method.Invoke(Target, args)` -> log elapsed.
1. Jeden `TimingProxy<T>` obsługuje dowolny interfejs.

## Zadanie 6 - Procedura decyzyjna

Dla każdego scenariusza wybierz wzorzec i uzasadnij.

### Scenariusz 6A

Masz bibliotekę kurierską z metodami `SendPackage(Parcel)` i `TrackShipment(id)`. Twój kontrakt to `IDeliveryService` ze swoimi typami.

```
Pytanie                                    Odpowiedź
Zmieniam kontrakt obcego API?              [ ]
Ten sam kontrakt + kontrola uprawnień?     [ ]
Ten sam kontrakt + lazy init?              [ ]
Ten sam kontrakt + ukrycie sieci?          [ ]
Ten sam kontrakt + cache wyników?          [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6B

Masz `IReportRepository` z metodą `FindReports(filter)`. Zapytania są drogie i te same filtry powtarzają się co 5 minut.

```
Pytanie                                    Odpowiedź
Zmieniam kontrakt obcego API?              [ ]
Ten sam kontrakt + cache wyników?          [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6C

Masz `IPaymentService` z metodą `ChargeCard()`. Operacje może wykonać tylko użytkownik z rolą `FinanceTeam`.

```
Pytanie                                    Odpowiedź
Zachowujesz ten sam kontrakt?              [ ]
Kontrola uprawnień przed wywołaniem?       [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6D

Masz `INotificationSender`. Chcesz dologować SMS-y i e-maile niezależnie — kolejno SMS-logger, potem email-logger.

```
Pytanie                                    Odpowiedź
Zachowujesz ten sam kontrakt?              [ ]
Nakladasz zachowania warstwowo?            [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Klucz do odpowiedzi

- 6A: Adapter (translacja sygnatury)
- 6B: Caching Proxy (cache wyników przy tym samym kontrakcie)
- 6C: Protection Proxy (kontrola uprawnień)
- 6D: Dekorator (addytywne nakładanie logerow)

## Pytania kontrolne

1. Co odróżnią Proxy od Adaptera — zachowaj jeden kontrakt vs zmień kontrakt?
1. Czym różni sie Virtual Proxy od Protection Proxy?
1. Kiedy używasz Caching Proxy, a kiedy Dekoratora z logerem?
1. Dlaczego Dynamic Proxy utrudnia debugowanie?
1. Kiedy Static Proxy jest lepszy niz Dynamic Proxy?
1. Co sie stanie, kiedy wlozysz logikę biznesowa do Proxy zamiast do RealSubject?
1. Jak zabezpieczyć sie przed niekontrolowanym rozrostem warstw proxy?
1. Jak przetestować Protection Proxy dla ścieżki dostępu zabronionego?
