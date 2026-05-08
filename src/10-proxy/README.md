# Wzorzec Proxy

## Cel modułu

Ten moduł zawiera komplet materiałów do wykładu o wzorcu Proxy, w tym Dynamic Proxy.
Każdy temat ma osobny katalog z README oraz (tam gdzie ma sens) kodem uruchamialnym.

## Spis tematów

| # | Temat | Opis |
| --- | --- | --- |
| [01](01-idea-i-kontekst/README.md) | Idea i kontekst | Po co Proxy i jakie problemy rozwiązuje |
| [02](02-kiedy-stosowac-zalety-wady/README.md) | Kiedy stosować | Checklisty decyzyjne i porównanie z innymi wzorcami |
| [03](03-struktura-gof/README.md) | Struktura GoF | Klasy, rolę i przepływ wywołań |
| [04](04-static-proxy/README.md) | Static Proxy | Ochrona dostępu i logowanie na klasach proxy |
| [05](05-dynamic-proxy-csharp/README.md) | Dynamic Proxy C# | Interceptory z DispatchProxy |
| [06](06-dynamic-proxy-java/README.md) | Dynamic Proxy Java | InvocationHandler i Proxy.newProxyInstance |

## Jak uruchamiać przykłady C#

```bash
cd src/10-proxy/01-idea-i-kontekst/Examples && dotnet run
cd src/10-proxy/02-kiedy-stosować-zalety-wady/Examples && dotnet run
cd src/10-proxy/03-struktura-gof/Examples && dotnet run
cd src/10-proxy/04-static-proxy/Examples && dotnet run
cd src/10-proxy/05-dynamic-proxy-csharp/Examples && dotnet run
```

## Jak uruchamiać testy

```bash
dotnet test src/10-proxy/04-static-proxy/Tests/Examples.Tests.csproj
dotnet test src/10-proxy/05-dynamic-proxy-csharp/Tests/Examples.Tests.csproj
```

## Plan wykładu 90 minut

1. 0-10 min: motywacja i problem.
2. 10-25 min: definicja Proxy i struktura GoF.
3. 25-45 min: typy Proxy (Virtual, Protection, Remote, Caching).
4. 45-65 min: live coding Static Proxy.
5. 65-80 min: live coding Dynamic Proxy (C# + Java).
6. 80-90 min: Proxy vs Adapter vs Dekorator vs Strategia + Q&A.

## Materiały prowadzącego

Konspekt slajdów i scenariusz prowadzenia: [MATERIALY-WYKLAD.md](MATERIALY-WYKLAD.md)

## Zadania

Zadania i szablony pracy studentów: [ZADANIA.md](ZADANIA.md)
