# 04. Static Proxy - implementacja i warianty

## Cel tematu

Zobaczyc klasyczny Proxy jako jawna klase, ktora kontroluje dostep i deleguje do RealSubject.

## Szczegolowe wyjasnienie koncepcji

Static Proxy to podejscie, w ktorym klasa proxy jest napisana recznie i implementuje ten sam interfejs co obiekt docelowy.

Najwazniejsze cechy:

1. Ta sama sygnatura metod w `Proxy` i `RealSubject`.
1. Klient pracuje na wspolnym kontrakcie (interfejsie), wiec moze dostac `RealSubject` albo `Proxy`.
1. `Proxy` przejmuje odpowiedzialnosc za logike przekrojowa: autoryzacje, logowanie, cache, walidacje, lazy loading.
1. Logika domenowa dalej pozostaje w `RealSubject`, dzieki czemu odpowiedzialnosci sa rozdzielone.

Kiedy to ma sens:

1. Gdy chcesz jawnie kontrolowac dostep do operacji krytycznych.
1. Gdy zalezy Ci na prostym i czytelnym kodzie bez mechanizmow runtime interception.
1. Gdy liczba interfejsow jest niewielka (bo dla wielu interfejsow rosnie boilerplate).

## Role i odpowiedzialnosci

1. `IReportService` (`Subject`) - kontrakt widoczny dla klienta.
1. `RealReportService` (`RealSubject`) - faktycznie realizuje operacje na raportach.
1. `ReportServiceProxy` (`Proxy`) - loguje i sprawdza role, a potem deleguje.
1. Kod kliencki - uzywa tylko `IReportService`.

## Co pokazuje kod przykladu

1. Interfejs IReportService.
1. RealReportService - implementacja docelowa.
1. ReportServiceProxy - kontrola roli + logowanie.
1. Dwa konteksty uzytkownika (`User`, `Admin`) i rozne zachowanie tej samej metody.

## Program ilustrujacy

Kod z: [Examples/Program.cs](Examples/Program.cs)

```csharp
UserContext user = new(UserRole.User);
UserContext admin = new(UserRole.Admin);

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

## Wyjasnienie programu krok po kroku

1. Tworzone sa dwa konteksty: zwykly uzytkownik i administrator.
1. Dla obu tworzony jest `ReportServiceProxy`, ktory opakowuje ten sam typ `RealReportService`.
1. Wywolanie `GetMonthlyReport(3)` zawsze przechodzi przez proxy, ktory loguje operacje i deleguje do obiektu wewnetrznego.
1. Wywolanie `DeleteAllReports()` dla roli `User` rzuca `UnauthorizedAccessException`.
1. To samo wywolanie dla roli `Admin` przechodzi walidacje i jest delegowane do `RealReportService`.

## Dlaczego to jest dobry przyklad Static Proxy

1. Pokazuje transparentnosc dla klienta: obie implementacje sa widziane jako `IReportService`.
1. Pokazuje centralizacje polityki dostepu (autoryzacja nie jest rozproszona po kodzie klienta).
1. Pokazuje, ze `RealReportService` nie musi znac nic o rolach i logowaniu.

## Oczekiwany efekt uruchomienia

1. Log dla `GetMonthlyReport(3)` i wynik `REPORT-03`.
1. Komunikat `Expected: Only Admin can delete reports.` dla zwyklego uzytkownika.
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
1. Przy wielu interfejsach rosnie ilosc kodu boilerplate.
