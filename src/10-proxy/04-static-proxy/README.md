# 04. Static Proxy - implementacja i warianty

## Cel tematu

Zobaczyc klasyczny Proxy jako jawna klase, ktora kontroluje dostep i deleguje do RealSubject.

## Co pokazuje kod

1. Interfejs IReportService.
2. RealReportService - implementacja docelowa.
3. ReportServiceProxy - kontrola roli + logowanie.

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
2. Przy wielu interfejsach rośnie ilosc kodu boilerplate.
