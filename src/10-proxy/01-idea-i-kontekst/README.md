# 01. Idea i kontekst wzorca Proxy

## Cel tematu

Zrozumiec, kiedy chcemy podstawic obiekt posredniczacy przed obiekt docelowy.

Po tym temacie powinienes umiec odpowiedziec na pytania:

1. Dlaczego klient nie powinien czasem rozmawiac bezposrednio z RealSubject?
2. Co daje dodatkowa warstwa kontrolna (Proxy)?
3. Jakie sa 4 glowne typy Proxy i kiedy kazdy z nich stosowac?
4. Jak odroznic Proxy od Adaptera i Dekoratora?

## Problem: brak kontroli nad dostepem do obiektu

Wyobraz sobie serwis bazodanowy generujacy raporty. Klient wywoluje go bezposrednio. Pojawia sie problem: kazdy uzytkownik moze skasowac wszystko, inicjalizacja polaczenia trwa 2 sekundy nawet jesli raport nie jest potrzebny, a kazda operacja jest niewidoczna w logach.

Potrzebujemy warstwy, ktora — nie zmieniajac kontraktu klienta — moze:

1. Pilnowac polityk dostepu (kto i kiedy moze wywolac metode).
2. Odlozyc koszt inicjalizacji (lazy initialization).
3. Zwrocic wynik z cache zamiast kosztownego wywolania.
4. Dodac logowanie i metryki bez ingerencji w logike domenowa.
5. Ukryc fakt, ze RealSubject jest zdalne (siec, RPC, REST).

## Idea Proxy

Proxy ma **ten sam kontrakt** co RealSubject, ale dodaje kontrolowany punkt wejscia:

```
Client --> ISubject <|.. Proxy --> RealSubject : ISubject
```

Klient nie wie, czy pracuje z Proxy, czy z RealSubject. Obie klasy implementuja ten sam interfejs.

![Proxy motivation](diagrams/proxy_motivation.png)

Zrodlo: [diagrams/01-proxy-motivation.puml](diagrams/01-proxy-motivation.puml)

## Przeplyw wywolania krok po kroku

1. Klient wywoluje metode na interfejsie `ISubject`.
1. Wywolanie trafia do `Proxy`, nie do `RealSubject`.
1. Proxy wykonuje logike **pre-check**: autoryzacja, sprawdzenie cache, start pomiaru czasu.
1. Proxy deleguje (lub nie) wywolanie do `RealSubject`.
1. Proxy wykonuje logike **post-check**: zapis do cache, stop pomiaru czasu, log wyniku.
1. Wynik wraca do klienta.

## Cztery typy Proxy — kiedy ktory

| Typ | Cel | Przyklad z zycia | Przyklad C# |
|---|---|---|---|
| **Protection Proxy** | Kontrola uprawnien | Bramka w biurze — wchodzisz tylko ze zenietką | Proxy sprawdza role przed `Delete()` |
| **Virtual Proxy** | Lazy initialization | Miniatura zdjecia zamiast oryginalnego pliku | `ImageProxy` tworzy `RealImage` dopiero przy `Display()` |
| **Remote Proxy** | Ukrycie lokalizacji | Recepcja przyjmuje zamowienie, kuchnia je realizuje | Stub gRPC ukrywa fakt komunikacji sieciowej |
| **Caching Proxy** | Zapamietanie wynikow | Kelner pamięta zamowienie stolika — nie pyta szefa drugi raz | `_cache[key]` zamiast ponownego zapytania do bazy |

![Proxy types](diagrams/proxy_types.png)

Zrodlo: [diagrams/02-proxy-types.puml](diagrams/02-proxy-types.puml)

## Co odroznia Proxy od innych wzorcow

| Wzorzec | Zachowuje kontrakt? | Glowny cel |
|---|---|---|
| **Proxy** | Tak | Kontrola dostepu, lazy, cache, remote |
| **Adapter** | Nie — zmienia interfejs | Dostosowanie obcego API do swojego kontraktu |
| **Dekorator** | Tak | Nakladanie nowych zachowan warstwowo |
| **Strategia** | Tak | Podmiana algorytmu w jednej osi |

Krotka regula: jesli zachowujesz interfejs i chcesz **kontrolowac**, nie **rozszerzac** — to Proxy. Jesli chcesz warstwowo **doklejac** zachowania — to Dekorator.

## Przykladowy program C# (Protection Proxy)

Ponizej minimalny, samodzielny przyklad pokazujacy cztery etapy wzorca:

```csharp
// Subject
interface IReportService
{
    string GetMonthlyReport(int month);
    void DeleteAllReports();
}

// RealSubject — logika domenowa, bez znajomosci ról
sealed class RealReportService : IReportService
{
    public string GetMonthlyReport(int month) => $"REPORT-{month:00}";
    public void DeleteAllReports() => Console.WriteLine("RealReportService: deleted");
}

// Protection Proxy — warunek dostepu, pre-check
sealed class ReportServiceProxy(IReportService inner, UserContext ctx) : IReportService
{
    public string GetMonthlyReport(int month)
    {
        Console.WriteLine($"Proxy: GET report/{month} [role={ctx.Role}]");
        return inner.GetMonthlyReport(month);
    }

    public void DeleteAllReports()
    {
        Console.WriteLine("Proxy: DELETE requested");
        if (ctx.Role != UserRole.Admin)
            throw new UnauthorizedAccessException("Only Admin can delete reports.");
        inner.DeleteAllReports();
    }
}

// Client — pracuje wylacznie na IReportService, nie zna Proxy ani RealSubject
IReportService userProxy  = new ReportServiceProxy(new RealReportService(), new UserContext(UserRole.User));
IReportService adminProxy = new ReportServiceProxy(new RealReportService(), new UserContext(UserRole.Admin));

Console.WriteLine(userProxy.GetMonthlyReport(3));
// => Proxy: GET report/3 [role=User]
// => REPORT-03

try { userProxy.DeleteAllReports(); }
catch (UnauthorizedAccessException ex) { Console.WriteLine($"Expected: {ex.Message}"); }
// => Proxy: DELETE requested
// => Expected: Only Admin can delete reports.

adminProxy.DeleteAllReports();
// => Proxy: DELETE requested
// => RealReportService: deleted
```

### Co sie tu dzieje?

1. Klient widzi tylko `IReportService` — nie wie, czy ma Proxy, czy RealSubject.
1. `ReportServiceProxy` implementuje ten sam interfejs co `RealReportService`.
1. Proxy sprawdza role przed operacja krytyczna (pre-check).
1. `RealReportService` nie zna zasad autoryzacji — SRP zachowane.
1. Zasady dostepu sa w jednym miejscu i latwo je testowac.

## Kod przykladu

Kod: [Examples/Program.cs](Examples/Program.cs)

Program pokazuje Protection Proxy z kontrola roli. Klient pracuje wylacznie na interfejsie `IReportService`.
Dla roli `User` operacja `DeleteAllReports()` rzuca `UnauthorizedAccessException`. Dla roli `Admin` przechodzi.

```bash
cd src/10-proxy/01-idea-i-kontekst/Examples
dotnet run
```

## Dalsze kroki

1. Pelna implementacja Static Proxy z loggerem: [../04-static-proxy/README.md](../04-static-proxy/README.md)
1. Wersja dynamiczna w C#: [../05-dynamic-proxy-csharp/README.md](../05-dynamic-proxy-csharp/README.md)
1. Procedura decyzyjna — kiedy ktory wzorzec: [../02-kiedy-stosowac-zalety-wady/README.md](../02-kiedy-stosowac-zalety-wady/README.md)
