# ZADANIA - Wzorzec Proxy

## Zadanie 1 - Protection Proxy

**Scenariusz:** System CMS. Metoda `PublishArticle()` moze byc wywolana tylko przez `Editor` i `Admin`. Metoda `DeleteArticle()` tylko przez `Admin`.

Wymagania:

1. Zdefiniuj `IArticleService` z metodami `GetArticle()`, `PublishArticle()`, `DeleteArticle()`.
1. Zaimplementuj `RealArticleService`.
1. Napisz `ArticleServiceProxy` sprawdzajacy role przed kazda operacja.
1. Pokaz 3 konteksty: `Viewer`, `Editor`, `Admin` i oczekiwane efekty.

Rozwiazanie (skrot):

1. Proxy sprawdza role w pre-checku, rzuca `UnauthorizedAccessException` przy braku uprawnienia.
1. `RealArticleService` nie zna zasad autoryzacji — SRP zachowane.
1. Test: `Viewer.PublishArticle()` => wyjatek; `Editor.PublishArticle()` => sukces; `Admin.DeleteArticle()` => sukces.

## Zadanie 2 - Virtual Proxy

**Scenariusz:** Edytor dokumentow. Duzy plik PDF (50 MB) jest ladowany z dysku. Uzytkownik moze przejrzec liste dokumentow, ale otworzyc tylko wybrany.

Wymagania:

1. Zdefiniuj `IDocument` z metodami `Open()` i `GetTitle()`.
1. `RealDocument` laduje plik w konstruktorze (symulacja `Thread.Sleep(500)`).
1. `DocumentProxy` zwraca `GetTitle()` bez ladowania pliku; laduje plik dopiero przy `Open()`.
1. Pokaz: tworzenie 5 proxy, wywolanie `GetTitle()` dla wszystkich, `Open()` tylko dla jednego.

Rozwiazanie (skrot):

1. `_real ??= RealDocument.Load(_path)` w `Open()`.
1. `GetTitle()` zwraca zapamiétany tytul bez tworzenia `RealDocument`.
1. Output: 5x title bez I/O; 1x loading przy `Open()`.

## Zadanie 3 - Caching Proxy

**Scenariusz:** API kursow walut. Wywolanie zewnetrzne trwa 400 ms. Ta sama waluta jest pytana wielokrotnie w ciagu minuty.

Wymagania:

1. Zdefiniuj `IExchangeRateService` z metoda `GetRate(string currency): decimal`.
1. `RealExchangeRateService` symuluje opoznienie `Thread.Sleep(400)`.
1. `CachingExchangeRateProxy` przechowuje wyniki w `Dictionary<string, (decimal rate, DateTime expires)>` z TTL 60 s.
1. Pokaz: 3 zapytania o EUR (pierwsze = miss, dwa nastepne = hit), 1 zapytanie o USD (miss).

Rozwiazanie (skrot):

1. Cache sprawdza `expires > DateTime.UtcNow`; przy trafieniu zwraca rate bez delegacji.
1. Log: `[CACHE MISS] EUR`, `[CACHE HIT] EUR`, `[CACHE HIT] EUR`, `[CACHE MISS] USD`.

## Zadanie 4 - Remote Proxy

**Scenariusz:** Serwis pogodowy dostepny przez HTTP. Klient ma wywolywac `IWeatherService.GetForecast(city)` jak lokalny obiekt.

Wymagania:

1. Zdefiniuj `IWeatherService` z metoda `GetForecast(string city): string`.
1. `WeatherServiceProxy` symuluje wywolanie HTTP (log + `Thread.Sleep(100)`) i zwraca stub.
1. Klient wywoluje `IWeatherService` — nie wie, ze to siec.

Rozwiazanie (skrot):

1. Proxy ukrywa `HttpClient` (lub symulacje) za interfejsem.
1. Klient nie zna URL ani szczegolów HTTP.

## Zadanie 5 - Dynamic Proxy C#

**Scenariusz:** Masz wiele interfejsow serwisowych. Chcesz zmierzyc czas wykonania kazdej metody bez pisania osobnej klasy Proxy dla kazdego.

Wymagania:

1. Zdefiniuj `IOrderService` i `IInventoryService` z kilkoma metodami.
1. Napisz `TimingProxy<T> : DispatchProxy` logujacy czas w milisekundach.
1. Uzyj `ProxyFactory.Create<T>(real)` dla obu serwisow.
1. Wywolaj metody — w logach widoczne czasy dla obu interfejsow.

Rozwiazanie (skrot):

1. `override Invoke`: `Stopwatch.StartNew()` -> `method.Invoke(Target, args)` -> log elapsed.
1. Jeden `TimingProxy<T>` obsluguje dowolny interfejs.

## Zadanie 6 - Procedura decyzyjna

Dla kazdego scenariusza wybierz wzorzec i uzasadnij.

### Scenariusz 6A

Masz biblioteke kurierska z metodami `SendPackage(Parcel)` i `TrackShipment(id)`. Twoj kontrakt to `IDeliveryService` ze swoimi typami.

```
Pytanie                                    Odpowiedz
Zmieniam kontrakt obcego API?              [ ]
Ten sam kontrakt + kontrola uprawnien?     [ ]
Ten sam kontrakt + lazy init?              [ ]
Ten sam kontrakt + ukrycie sieci?          [ ]
Ten sam kontrakt + cache wynikow?          [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6B

Masz `IReportRepository` z metoda `FindReports(filter)`. Zapytania sa drogie i te same filtry powtarzaja sie co 5 minut.

```
Pytanie                                    Odpowiedz
Zmieniam kontrakt obcego API?              [ ]
Ten sam kontrakt + cache wynikow?          [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6C

Masz `IPaymentService` z metoda `ChargeCard()`. Operacje moga wykonac tylko uzytkownik z rola `FinanceTeam`.

```
Pytanie                                    Odpowiedz
Zachowujesz ten sam kontrakt?              [ ]
Kontrola uprawnien przed wywolaniem?       [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Scenariusz 6D

Masz `INotificationSender`. Chcesz dologowac SMS-y i e-maile niezaleznie — kolejno SMS-logger, potem email-logger.

```
Pytanie                                    Odpowiedz
Zachowujesz ten sam kontrakt?              [ ]
Nakladasz zachowania warstwowo?            [ ]
```

Wzorzec: ________________  Uzasadnienie: ________________________________

### Klucz do odpowiedzi

- 6A: Adapter (translacja sygnatury)
- 6B: Caching Proxy (cache wynikow przy tym samym kontrakcie)
- 6C: Protection Proxy (kontrola uprawnien)
- 6D: Dekorator (addytywne nakladanie logerow)

## Pytania kontrolne

1. Co odroznia Proxy od Adaptera — zachowaj jeden kontrakt vs zmien kontrakt?
1. Czym rozni sie Virtual Proxy od Protection Proxy?
1. Kiedy uzywasz Caching Proxy, a kiedy Dekoratora z logerem?
1. Dlaczego Dynamic Proxy utrudnia debugowanie?
1. Kiedy Static Proxy jest lepszy niz Dynamic Proxy?
1. Co sie stanie, kiedy wlozysz logike biznesowa do Proxy zamiast do RealSubject?
1. Jak zabezpieczyc sie przed niekontrolowanym rozrostem warstw proxy?
1. Jak przetestowac Protection Proxy dla sciezki dostepu zabronionego?
