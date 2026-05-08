# 04. Static Proxy - implementacja i warianty

## Cel tematu

Zobaczyć klasyczny Proxy jako jawną klasę, która kontroluje dostęp i deleguje do RealSubject.

## Szczegółowe wyjaśnienie koncepcji

Static Proxy to podejście, w którym klasa proxy jest napisana ręcznie i implementuje ten sam interfejs co obiekt docelowy.

Najważniejsze cechy:

1. Ta sama sygnatura metod w `Proxy` i `RealSubject`.
1. Klient pracuje na wspólnym kontrakcie (interfejsie), więc może dostać `RealSubject` albo `Proxy`.
1. `Proxy` przejmuje odpowiedzialność za logikę przekrojową: autoryzację, logowanie, cache, walidację, lazy loading.
1. Logika domenowa dalej pozostaje w `RealSubject`, dzięki czemu odpowiedzialności są rozdzielone.

Kiedy to ma sens:

1. Gdy chcesz jawnie kontrolować dostęp do operacji krytycznych.
1. Gdy zależy Ci na prostym i czytelnym kodzie bez mechanizmów runtime interception.
1. Gdy liczba interfejsów jest niewielka (bo dla wielu interfejsów rośnie boilerplate).

## Rolę i odpowiedzialności

1. `IReportService` (`Subject`) - kontrakt widoczny dla klienta.
1. `RealReportService` (`RealSubject`) - faktycznie realizuje operacje na raportach.
1. `ReportServiceProxy` (`Proxy`) - loguje i sprawdza rolę, a potem deleguje.
1. Kod kliencki - używa tylko `IReportService`.

## Co pokazuje kod przykładu

1. Interfejs IReportService.
1. RealReportService - implementacja docelowa.
1. ReportServiceProxy - kontrola roli + logowanie.
1. Dwa konteksty użytkownika (`User`, `Admin`) i różne zachowanie tej samej metody.

## Program ilustrujący

Kod z: [Examples/Program.cs](Examples/Program.cs)

```csharp
UserContext user = new(UserRolę.User);
UserContext admin = new(UserRolę.Admin);

IReportService userProxy = new ReportServiceProxy(new RealReportService(), user, Console.WriteLine);
IReportService adminProxy = new ReportServiceProxy(new RealReportService(), admin, Console.WriteLine);

Console.WriteLine(userProxy.GetMonthlyReport(3));

try
{
	userProxy.DeleteAllReports();
}
catch (UnauthorizedAccessException ex)
{
	Console.WriteLine($"Expected: {ex.Message}");
}

adminProxy.DeleteAllReports();
```

## Wyjaśnienie programu krok po kroku

1. Tworzone są dwa konteksty: zwykły użytkownik i administrator.
1. Dla obu tworzony jest `ReportServiceProxy`, który opakowuje ten sam typ `RealReportService`.
1. Wywołanie `GetMonthlyReport(3)` zawsze przechodzi przez proxy, który loguje operacje i deleguje do obiektu wewnętrznego.
1. Wywołanie `DeleteAllReports()` dla roli `User` rzuca `UnauthorizedAccessException`.
1. To samo wywołanie dla roli `Admin` przechodzi walidację i jest delegowane do `RealReportService`.

## Dlaczego to jest dobry przykład Static Proxy

1. Pokazuje transparentność dla klienta: obie implementacje są widziane jako `IReportService`.
1. Pokazuje centralizację polityki dostępu (autoryzacja nie jest rozproszona po kodzie klienta).
1. Pokazuje, że `RealReportService` nie musi znać nic o rolach i logowaniu.

## Oczekiwany efekt uruchomienia

1. Log dla `GetMonthlyReport(3)` i wynik `REPORT-03`.
1. Komunikat `Expected: Only Admin can delete reports.` dla zwykłego użytkownika.
1. Log usuwania i komunikat z `RealReportService` dla administratora.

## Uruchom

```bash
cd src/10-proxy/04-static-proxy/Examples
dotnet run
```

## Testy

```bash
dotnet test src/10-proxy/04-static-proxy/Tests/Examples.Tests.csproj
```

## Wnioski

1. Static Proxy jest prosty i jawny.
1. Przy wielu interfejsach rosnie ilość kodu boilerplate.
