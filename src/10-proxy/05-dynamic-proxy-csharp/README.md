# 05. Dynamic Proxy w C#

## Cel tematu

Pokazac interception runtime bez pisania osobnej klasy proxy dla kazdego interfejsu.

## Szczegolowe wyjasnienie koncepcji w C#

W C# dynamic proxy mozna zbudowac przez `DispatchProxy`, ktory generuje implementacje interfejsu w runtime.
Zamiast pisac recznie klase proxy dla kazdego kontraktu, definiujesz jedna klase interceptora i przechwytujesz wywolania metod.

Jak to dziala:

1. Klient pracuje na interfejsie, np. `IOrderService`.
1. `DispatchProxy.Create<T, TProxy>()` zwraca obiekt, ktory implementuje `T`.
1. Kazde wywolanie metody trafia do `Invoke(MethodInfo, object?[]?)`.
1. W `Invoke` mozna dodac logowanie, pomiar czasu, polityke retry, metryki, walidacje, itp.
1. Ostatecznie interceptor deleguje wywolanie do prawdziwego obiektu (`Target`).

Korzysci i koszty:

1. Plus: mocna redukcja boilerplate dla wielu interfejsow.
1. Plus: centralizacja logiki przekrojowej.
1. Minus: trudniejszy debugging i mniejsza czytelnosc stack trace.
1. Minus: narzut reflection i runtime dispatch.

## Role w przykladzie

1. `IOrderService` - kontrakt (`Subject`).
1. `RealOrderService` - implementacja docelowa (`RealSubject`).
1. `MonitoringProxy<T>` - interceptor dynamicznego proxy.
1. `ProxyFactory` - bezpieczne tworzenie proxy dla interfejsu.
1. Kod kliencki - wywoluje metode jak zwykla implementacje interfejsu.

## Diagramy

### Diagram interakcji

![Diagram interakcji](diagrams/dynamic_proxy_csharp_flow.png)

Zrodlo: [diagrams/01-dispatch-proxy-flow.puml](diagrams/01-dispatch-proxy-flow.puml)

### Diagram klas

Zrodlo: [diagrams/02-class.puml](diagrams/02-class.puml)

## Co pokazuje kod

1. IOrderService i RealOrderService.
2. DispatchProxy generujacy proxy runtime.
3. Interceptor: log start/stop, pomiar czasu i obsluga wyjatkow.
4. Rzucenie wyjatku z `RealOrderService` i ponowne rzucenie `InnerException` w interceptorze.

## Program ilustrujacy

Kod: [Examples/Program.cs](Examples/Program.cs)

```csharp
IOrderService real = new RealOrderService();
IOrderService proxy = ProxyFactory.Create(real, Console.WriteLine);

Console.WriteLine(proxy.PlaceOrder("ORD-100"));

try
{
	proxy.PlaceOrder(string.Empty);
}
catch (ArgumentException ex)
{
	Console.WriteLine($"Expected: {ex.Message}");
}
```

## Wyjasnienie programu krok po kroku

1. Tworzony jest obiekt docelowy `RealOrderService`.
1. `ProxyFactory.Create` buduje dynamiczne proxy implementujace `IOrderService`.
1. Dla poprawnego `orderId` metoda przechodzi przez interceptor: `START -> OK -> ELAPSED_US`.
1. Dla pustego `orderId` `RealOrderService` rzuca `ArgumentException`.
1. Interceptor loguje `ERROR ...` i rzuca ponownie wewnetrzny wyjatek, zachowujac semantyke bledu.

## Oczekiwany efekt uruchomienia

1. Linia z zaakceptowanym zamowieniem `ORDER_ACCEPTED:ORD-100`.
1. Logi `START`, `OK`, `ELAPSED_US` dla poprawnego wywolania.
1. Log `ERROR PlaceOrder: orderId is required` i komunikat `Expected: ...` dla blednego wywolania.

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
