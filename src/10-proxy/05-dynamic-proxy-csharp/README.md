# 05. Dynamic Proxy w C#

## Cel tematu

Pokazac interception runtime bez pisania osobnej klasy proxy dla kazdego interfejsu.

## Co pokazuje kod

1. IOrderService i RealOrderService.
2. DispatchProxy generujacy proxy runtime.
3. Interceptor: log start/stop, pomiar czasu i obsluga wyjatkow.

## Uruchom

```bash
cd src/10-proxy/05-dynamic-proxy-csharp/Examples
dotnet run
```

## Testy

```bash
dotnet test src/10-proxy/05-dynamic-proxy-csharp/Tests/Examples.Tests.csproj
```

## Wnioski

1. Dynamic Proxy redukuje boilerplate.
2. Koszt: trudniejszy debugging i wiekszy narzut runtime.
