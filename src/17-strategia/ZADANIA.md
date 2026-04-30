# Zadania — Wzorzec Strategia

## Zadanie 1 — Strategia sortowania (podstawowe)

**Cel:** Zaimplementuj system sortowania z wymiennymi algorytmami.

Zdefiniuj interfejs `ISortStrategy<T>` z metodą `IList<T> Sort(IList<T> data)`.
Zaimplementuj trzy strategie:
- `BubbleSortStrategy<T>` — sortowanie bąbelkowe
- `SelectionSortStrategy<T>` — sortowanie przez wybór
- `LinqSortStrategy<T>` — sortowanie przez `OrderBy` z LINQ

Zaimplementuj klasę `Sorter<T>` (Context), która:
- Przyjmuje strategię przez konstruktor
- Umożliwia podmianę strategii metodą `SetStrategy(ISortStrategy<T>)`
- Udostępnia metodę `Sort(IList<T> data)`

**Weryfikacja:** Posortuj listę `[5, 2, 8, 1, 9, 3]` każdą strategią i wydrukuj wyniki.

### Wskazówka

```csharp
interface ISortStrategy<T> where T : IComparable<T>
{
    IList<T> Sort(IList<T> data);
}
```

---

## Zadanie 2 — Strategia walidacji (z haczykami)

**Cel:** System walidacji formularza z wymiennymi regułami.

Zdefiniuj interfejs `IValidationStrategy` z metodą `ValidationResult Validate(string input)`.
Zaimplementuj strategie:
- `RequiredFieldStrategy` — sprawdza czy pole nie jest puste
- `EmailValidationStrategy` — sprawdza format e-mail (regex)
- `LengthValidationStrategy(int min, int max)` — sprawdza długość
- `CompositeValidationStrategy` — łączy wiele strategii (AND)

Klasa `FormField` (Context) powinna:
- Przyjmować `IValidationStrategy` przez konstruktor
- Metodą `Validate(string input)` delegować do strategii
- Opcjonalnie: umożliwiać podmianę strategii

**Weryfikacja:** Waliduj pola rejestracji użytkownika (email, hasło, imię).

---

## Zadanie 3 — Refaktoryzacja if/switch → Strategia

**Cel:** Refaktoryzacja istniejącego kodu z `if/switch` na wzorzec Strategia.

Dany kod do refaktoryzacji:

```csharp
class ReportExporter
{
    public string Export(Report report, string format)
    {
        if (format == "json")
        {
            // 15 linii logiki JSON
            return System.Text.Json.JsonSerializer.Serialize(report);
        }
        else if (format == "csv")
        {
            // 15 linii logiki CSV
            var sb = new System.Text.StringBuilder();
            sb.AppendLine("Id,Title,Value");
            sb.AppendLine($"{report.Id},{report.Title},{report.Value}");
            return sb.ToString();
        }
        else if (format == "xml")
        {
            // 15 linii logiki XML
            return $"<report><id>{report.Id}</id><title>{report.Title}</title></report>";
        }
        throw new ArgumentException($"Unknown format: {format}");
    }
}

record Report(int Id, string Title, decimal Value);
```

Refaktoryzuj do:
1. Interfejsu `IReportExportStrategy`
2. Trzech klas strategii
3. Klasy `ReportExporter` (Context) z wstrzykiwaną strategią
4. Fabryki/słownika do wyboru strategii po nazwie

**Bonus:** Dodaj nową strategię `MarkdownStrategy` bez modyfikowania istniejących klas.

---

## Zadanie 4 — Strategia z ASP.NET Core DI (zaawansowane)

**Cel:** Rejestracja i wybór strategii przez kontener IoC.

Zaprojektuj system powiadomień z wymiennymi kanałami:

```csharp
interface INotificationStrategy
{
    string Channel { get; }
    Task SendAsync(string recipient, string message);
}
```

Zaimplementuj:
- `EmailNotificationStrategy`
- `SmsNotificationStrategy`
- `PushNotificationStrategy`

Zarejestruj wszystkie strategie w `IServiceCollection` i zaimplementuj `NotificationService`, który:
- Wstrzykuje `IEnumerable<INotificationStrategy>`
- Wybiera strategię po `Channel` (np. `"email"`, `"sms"`)
- Rzuca wyjątek gdy kanał nie istnieje

**Wzorzec rejestracji:**

```csharp
services.AddScoped<INotificationStrategy, EmailNotificationStrategy>();
services.AddScoped<INotificationStrategy, SmsNotificationStrategy>();
services.AddScoped<INotificationStrategy, PushNotificationStrategy>();
```

---

## Zadanie 5 — Pytania teoretyczne

1. **Porównaj** wzorzec Strategia z Metodą Szablonową. W jakiej sytuacji wybierzesz każdy z nich? Podaj konkretny przykład gdzie zmiana zdania (z jednego wzorca na drugi) byłaby uzasadniona.

1. **Delegat jako strategia:** Czy `Func<IList<int>, IList<int>>` przekazany do kontekstu jest wzorcem Strategia? Jakie ma zalety i wady w porównaniu z interfejsem `ISortStrategy`?

1. **Zasada OCP:** Jak wzorzec Strategia realizuje zasadę Open/Closed? Gdzie jest "otwarty na rozszerzenie" a gdzie "zamknięty na modyfikację"?

1. **Kiedy NIE używać:** Opisz sytuację gdzie zastosowanie wzorca Strategia byłoby nadmierną inżynierią (over-engineering). Jakie byłoby prostsze rozwiązanie?

1. **Strategia a Stan (State):** Jaka jest kluczowa różnica między wzorcem Strategia a wzorcem Stan? Podaj przykład każdego.

---

## Rozwiązania

### Zadanie 1 — rozwiązanie

```csharp
interface ISortStrategy<T> where T : IComparable<T>
{
    IList<T> Sort(IList<T> data);
}

class BubbleSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IList<T> data)
    {
        var arr = data.ToArray();
        for (int i = 0; i < arr.Length - 1; i++)
            for (int j = 0; j < arr.Length - i - 1; j++)
                if (arr[j].CompareTo(arr[j + 1]) > 0)
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
        return arr;
    }
}

class SelectionSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IList<T> data)
    {
        var arr = data.ToArray();
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIdx = i;
            for (int j = i + 1; j < arr.Length; j++)
                if (arr[j].CompareTo(arr[minIdx]) < 0) minIdx = j;
            (arr[i], arr[minIdx]) = (arr[minIdx], arr[i]);
        }
        return arr;
    }
}

class LinqSortStrategy<T> : ISortStrategy<T> where T : IComparable<T>
{
    public IList<T> Sort(IList<T> data) => data.OrderBy(x => x).ToList();
}

class Sorter<T>(ISortStrategy<T> strategy) where T : IComparable<T>
{
    private ISortStrategy<T> _strategy = strategy;
    public void SetStrategy(ISortStrategy<T> s) => _strategy = s;
    public IList<T> Sort(IList<T> data) => _strategy.Sort(data);
}

// Użycie:
var sorter = new Sorter<int>(new BubbleSortStrategy<int>());
var result1 = sorter.Sort([5, 2, 8, 1, 9, 3]);
Console.WriteLine(string.Join(", ", result1)); // 1, 2, 3, 5, 8, 9

sorter.SetStrategy(new LinqSortStrategy<int>());
var result2 = sorter.Sort([5, 2, 8, 1, 9, 3]);
Console.WriteLine(string.Join(", ", result2)); // 1, 2, 3, 5, 8, 9
```

### Zadanie 3 — rozwiązanie (fragment)

```csharp
interface IReportExportStrategy
{
    string Format { get; }
    string Export(Report report);
}

class JsonExportStrategy : IReportExportStrategy
{
    public string Format => "json";
    public string Export(Report report)
        => System.Text.Json.JsonSerializer.Serialize(report);
}

class CsvExportStrategy : IReportExportStrategy
{
    public string Format => "csv";
    public string Export(Report report)
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("Id,Title,Value");
        sb.AppendLine($"{report.Id},{report.Title},{report.Value}");
        return sb.ToString();
    }
}

class ReportExporter(IEnumerable<IReportExportStrategy> strategies)
{
    private readonly Dictionary<string, IReportExportStrategy> _map
        = strategies.ToDictionary(s => s.Format);

    public string Export(Report report, string format)
        => _map.TryGetValue(format, out var strategy)
            ? strategy.Export(report)
            : throw new ArgumentException($"Unknown format: {format}");
}
```

### Zadanie 5 — odpowiedzi

**1. Strategia vs Metoda Szablonowa:**  
Strategia = kompozycja (podmiana całego algorytmu przez interfejs), Metoda Szablonowa = dziedziczenie (podklasa wypełnia kroki szkieletu).  
Wybierz Strategię gdy algorytmy są kompletnie różne i chcesz podmienić w runtime.  
Wybierz Metodę Szablonową gdy algorytmy mają wspólny szkielet i tylko kilka kroków jest różnych.

**2. Delegat jako strategia:**  
Tak — `Func<>` to strategia bez nazwy. Zaletą jest zwięzłość, wadą — brak nazwanego kontraktu i trudniejsza dokumentacja/wykrywalność przez IDE.

**3. OCP:**  
"Otwarty na rozszerzenie" — dodajesz nową klasę implementującą `IStrategy`.  
"Zamknięty na modyfikację" — klasa `Context` i istniejące strategie nie muszą być modyfikowane.

**4. Kiedy NIE używać:**  
Gdy masz 2 warianty i nigdy nie dodasz nowego. Wtedy prosty `if/else` lub metoda wirtualna jest wystarczająca.

**5. Strategia vs Stan:**  
Strategia — klient świadomie wybiera algorytm; stan nie zmienia się samoistnie.  
Stan — obiekt sam zmienia swoje zachowanie gdy zmienia się jego stan wewnętrzny.
