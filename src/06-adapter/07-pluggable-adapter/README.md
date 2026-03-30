# 07. Pluggable Adapter

## O co chodzi

Pluggable Adapter polega na dynamicznym doborze adaptera na podstawie typu źródła danych lub konfiguracji. Klient korzysta z jednego interfejsu, a adapter wybierany jest z rejestru.

W praktyce to wzorzec często łączony z pluginami i DI: nowe adaptery dodajesz przez rejestrację komponentu, bez zmian w kodzie klienta.

## Zastosowanie

- integracja wielu dostawców API,
- architektura pluginowa,
- stopniowe podpinanie nowych źródeł danych bez zmiany klienta.

## Korzyści i koszty

Korzyści:

1. Rozszerzalność zgodna z Open/Closed.
2. Mniejszy wpływ zmian dostawcy na logikę biznesową.
3. Możliwość aktywacji adapterów przez konfigurację środowiska.

Koszty:

1. Dodatkowa warstwa diagnostyki (co wybrało się i dlaczego).
2. Potrzeba obsługi błędów rejestracji i konfliktów kluczy.
3. Konieczność wersjonowania kontraktów adapterów.

## Historia

Wariant popularyzował się wraz z systemami ETL i middleware, gdzie źródła danych zmieniały się częściej niż logika biznesowa klienta.

Wyjaśnienie ETL:

- ETL (Extract, Transform, Load) to proces integracji danych:
1. Extract - pobranie danych ze źródła (np. API, plik, baza).
2. Transform - ujednolicenie formatu i semantyki danych.
3. Load - zapis do docelowego systemu.
- W takim przepływie adaptery najczęściej realizują część Transform: zamieniają różne wejścia (`json`, `xml`, `csv`) na wspólny format dla klienta.

## Dobre praktyki

1. Loguj decyzję wyboru adaptera (source type, wersja, wynik).
2. Waliduj rejestr przy starcie aplikacji (brak duplikatów i pustych kluczy).
3. Dodaj strategię fallback, gdy adapter nie istnieje.
4. Trzymaj mapowanie formatu poza kodem klienta (konfiguracja, DI, plugin manifest).

Co oznacza strategia fallback:

1. To plan awaryjny, gdy `Resolve(sourceType)` nie znajdzie adaptera.
2. Fallback może mieć formę:
- czytelnego błędu domenowego,
- adaptera domyślnego (np. passthrough),
- przekierowania do kolejki dead-letter,
- degradacji funkcji (np. zapis surowego payloadu do dalszej analizy).
3. W tym przykładzie fallback to kontrolowany wyjątek `InvalidOperationException`, przechwycony w `try/catch` i zalogowany jako `[Fallback/blad]`.

Co oznacza Trzymaj mapowanie formatu poza kodem klienta:

1. Klient nie powinien zawierać `if/else` typu `if (json) ... else if (xml) ...`.
2. Decyzja jaki adapter wybrać powinna być konfigurowana poza klientem:
- konfiguracja aplikacji (np. mapowanie `sourceType -> adapter`),
- kontener DI (rejestracja implementacji `IMessageAdapter`),
- plugin manifest (lista adapterów ładowanych dynamicznie).
3. Efekt: klient zależy od jednego kontraktu i nie zmienia się przy dodaniu nowego formatu.

## Diagramy

![Pluggable class](diagrams/pluggable_class.png)

Źródło: [diagrams/01-pluggable-class.puml](diagrams/01-pluggable-class.puml)

Szczegółowe wyjaśnienie diagramu klas:

1. `IMessageAdapter` definiuje wspólny kontrakt (`SourceType`, `Adapt(...)`).
2. `JsonAdapter` i `XmlAdapter` to konkretne implementacje kontraktu.
3. `AdapterRegistry --> IMessageAdapter` oznacza, że rejestr zna tylko interfejs, nie konkretne klasy.
4. `Client --> AdapterRegistry` pokazuje, że klient nie komunikuje się bezpośrednio z konkretnymi adapterami.
5. To realizuje Open/Closed: nowy adapter można dodać przez rejestrację, bez zmian w kliencie.

![Pluggable sequence](diagrams/pluggable_sequence.png)

Źródło: [diagrams/02-pluggable-sequence.puml](diagrams/02-pluggable-sequence.puml)

Szczegółowe wyjaśnienie diagramu sekwencji:

1. Klient prosi rejestr o adapter przez `Resolve("json")`.
2. Rejestr zwraca implementację pasującą do klucza `sourceType`.
3. Klient wywołuje `Adapt(input)` na zwróconym adapterze.
4. Adapter oddaje znormalizowany wynik, niezależnie od wejściowego formatu.
5. Jeśli adapter nie istnieje, uruchamia się ścieżka fallback (w kodzie: wyjątek + obsługa błędu).

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

W przykładzie klient korzysta z rejestru adapterów, a wybór odbywa się po `sourceType` (`json`, `xml`, `csv`).

Zakres przykładu:

1. Dynamiczna rejestracja adapterów.
2. Bezpieczne rozwiązywanie adaptera z czytelnym błędem.
3. Demonstracja rozszerzenia o nowy adapter bez modyfikacji logiki klienta.

Szczegółowe wyjaśnienie programu:

1. Definicja kontraktu:
- `IMessageAdapter` narzuca dwa elementy: klucz `SourceType` i funkcję translacji `Adapt(...)`.

2. Implementacje adapterów:
- `JsonAdapter`, `XmlAdapter`, `CsvAdapter` realizują ten sam kontrakt, ale inaczej mapują dane wejściowe.

3. Rejestr adapterów (`AdapterRegistry`):
- przechowuje mapę `sourceType -> adapter`,
- waliduje rejestrację (pusty klucz i duplikaty są blokowane),
- udostępnia dwa style rozwiązywania:
	- `TryResolve(...)` (bez wyjątków),
	- `Resolve(...)` (z wyjątkiem, gdy brak adaptera).

4. Przepływ `Main()`:
- start z adapterami `json` i `xml`,
- użycie ich przez `Resolve(...).Adapt(...)`,
- dynamiczne dołączenie pluginu `CsvAdapter` przez `Register(...)`,
- próba `Resolve("yaml")` kończy się fallbackiem (obsłużony wyjątek).

5. Dlaczego to dobry przykład pluggable adapter:
- nowy format (`csv`) został dodany bez zmiany logiki klienta,
- klient nie zna klas konkretnych adapterów,
- błąd braku adaptera jest kontrolowany i jawny.

### TryResolve vs Resolve - krótkie porównanie

| Metoda | Kiedy używać | Co zwraca | Skutek błędu (brak adaptera) | Wpływ na flow |
| --- | --- | --- | --- | --- |
| `TryResolve(sourceType, out adapter)` | Gdy brak adaptera jest normalnym przypadkiem biznesowym (np. opcjonalny format) | `bool` + adapter przez `out` | Brak wyjątku, metoda zwraca `false` | Kontrolowany branch `if/else`, łatwiejsza degradacja funkcji |
| `Resolve(sourceType)` | Gdy adapter jest wymagany i jego brak oznacza błąd konfiguracji/systemu | Adapter albo wyjątek | `InvalidOperationException` | Szybkie przerwanie ścieżki i wejście w handling błędów (fallback/log/alert) |

Praktyczna reguła:

1. Użyj `TryResolve`, gdy chcesz prowadzić aplikację dalej mimo braku adaptera.
2. Użyj `Resolve`, gdy brak adaptera ma być traktowany jako błąd krytyczny i ma być natychmiast widoczny.
