# 06. Most w bibliotekach standardowych

## Cel tematu

Pokazać mostopodobne rozwiązania w praktyce i granice klasyfikacji.

## Przykłady

1. ILogger (abstrakcja logowania) + provider.
2. Stream abstractions + konkretne backendy.
3. ADO.NET abstractions + provider bazodanowy.

![Bridge in libraries](diagrams/bridge_libs_class.png)

Źródło: [diagrams/01-libs-class.puml](diagrams/01-libs-class.puml)

![Logger sequence](diagrams/bridge_libs_sequence.png)

Źródło: [diagrams/02-libs-sequence.puml](diagrams/02-libs-sequence.puml)

## Cykl wywolania

![Lib lifecycle](diagrams/bridge_lifecycle_topic06.png)

Źródło: [diagrams/03-lifecycle.puml](diagrams/03-lifecycle.puml)

## Kod C#

Kod: [Examples/Program.cs](Examples/Program.cs)

Program tworzy mini logger bridge: AppLogger + ILogSink.

## Uruchom

```bash
cd src/09-most/06-most-w-bibliotekach-standardowych/Examples
dotnet run
```

## Zadania z rozwiązaniami

1. Dodaj FileSink obok ConsoleSink.
Rozwiązanie: nowy implementor sink.

2. Dodaj AuditLogger (RefinedAbstraction).
Rozwiązanie: nowa abstrakcja po stronie domeny.

## Literatura

1. Microsoft Docs ILogger: https://learn.microsoft.com/dotnet/api/microsoft.extensions.logging.ilogger
2. Refactoring.Guru Bridge: https://refactoring.guru/design-patterns/bridge
