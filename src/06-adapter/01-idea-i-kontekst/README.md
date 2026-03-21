# 01. Idea i kontekst wzorca Adapter

## Cel rozdziału

Po tym rozdziale student powinien:

- rozumieć problem niezgodnych interfejsów,
- znać kontekst historyczny powstania wzorca,
- umieć wskazać miejsce adaptera w architekturze integracyjnej.

## Dlaczego Adapter powstał

W systemach rozwijanych latami często pojawiają się komponenty o różnych kontraktach API:

- legacy biblioteki,
- zewnętrzne SDK,
- stare moduły monolitu,
- nowe mikroserwisy.

Adapter pozwala nie przepisywać całego klienta, tylko dodać warstwę tłumaczącą dane i wywołania.

## Diagramy

![Kontekst adaptera](diagrams/adapter_context.png)

Źródło: [diagrams/01-context.puml](diagrams/01-context.puml)

![Problem i rozwiązanie](diagrams/adapter_solution.png)

Źródło: [diagrams/02-problem-solution.puml](diagrams/02-problem-solution.puml)

## Przykład C Sharp

Kod: [Examples/Program.cs](Examples/Program.cs)

Fragment:

```csharp
IPaymentGateway gateway = new LegacyGatewayAdapter(new LegacyPaymentSystem());
var result = gateway.Charge(120.50m, "PLN");
Console.WriteLine(result);
```

Uruchom:

```bash
cd src/06-adapter/01-idea-i-kontekst/Examples
dotnet run
```
