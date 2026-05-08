# 03. Struktura GoF Proxy

## Szczegółowy opis

## Rolę we wzorcu

1. `Subject` - wspólny kontrakt dla klienta i obiektu docelowego.
2. `RealSubject` - docelowa implementacja wykonująca operacje biznesowa.
3. `Proxy` - implementuje `Subject`, kontroluje dostęp i deleguje do `RealSubject`.
4. `Client` - pracuje na `Subject`, bez zależności od konkretnej implementacji.

Jak działa współpraca ról:

1. `Client` wywołuje operacje przez interfejs `Subject`.
2. `Proxy` wykonuje logikę pre/post, np. autoryzację, cache, logowanie lub lazy init.
3. `Proxy` deleguje wywołanie do `RealSubject` albo zwraca wynik z cache.
4. `Client` pozostaje odseparowany od szczegółów tworzenia i zabezpieczen obiektu docelowego.

## Diagramy

![Diagram klas](diagrams/proxy_class.png)

Źródło: [diagrams/01-class.puml](diagrams/01-class.puml)

Opis diagramu klas:

1. Relacja `Subject <|.. RealSubject` pokazuje implementacje wspólnego kontraktu.
2. Relacja `Subject <|.. Proxy` pokazuje podstawialnosc proxy z perspektywy klienta.
3. Relacja `Proxy --> RealSubject` oznacza delegację wywołań do obiektu docelowego.
4. Relacja `Client --> Subject` utrzymuje klienta niezaleznym od konkretow implementacyjnych.

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Program ilustruje każda z czterech ról GoF (`ISubject`, `RealSubject`, `Proxy`, `Client`).
Proxy jest Caching Proxy: pierwsze wywołanie pełni delegację do `RealSubject`, kolejne zwraca wynik z cache.
W logach widoczne są pre-check, delegacja i post-processing.

```bash
cd src/10-proxy/03-struktura-gof/Examples
dotnet run
```

Co robi program:

1. Definiuje kontrakt `IReportService`, na którym pracuje klient.
2. Udostępnia `RealReportService` jako `RealSubject` wykonujący operacje docelowe.
3. Implementuje `ReportServiceProxy`, który loguje wywołania i kontroluje autoryzację.
4. W kodzie klienta obiekt jest widziany jako `IReportService`, więc szczegóły implementacji są ukryte.

```csharp
IReportService userProxy = new ReportServiceProxy(new RealReportService(), user, Console.WriteLine);
Console.WriteLine(userProxy.GetMonthlyReport(3));
```

Interpretacja wyniku:

1. Najpierw widac logikę proxy (`Proxy: ...`), a dopiero potem wykonanie operacji w `RealReportService`.
2. Dla zwyklego użytkownika usuwanie raportow kończy sie kontrolowanym `UnauthorizedAccessException`.
3. Wzorzec realizuje cel GoF: dodanie kontroli dostępu bez zmiany kodu klienta.

Uruchom:

```bash
cd src/10-proxy/04-static-proxy/Examples
dotnet run
```
