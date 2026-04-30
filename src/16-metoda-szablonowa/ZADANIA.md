# Zadania — Wzorzec Metoda Szablonowa

## Zadanie 1 — Przygotowywanie potraw

**Cel:** Zaprojektować hierarchię klas dla przepisów kulinarnych używając Template Method.

**Treść:**  
Zaimplementuj klasę abstrakcyjną `Recipe` (przepis) z metodą szablonową `Prepare()` zawierającą kroki:
1. `GatherIngredients()` — zbierz składniki (abstrakcyjna)
2. `PrepareIngredients()` — przygotuj składniki (wirtualna z domyślną implementacją: "Myjemy i kroimy składniki")
3. `Cook()` — gotuj (abstrakcyjna)
4. `Plate()` — podaj na talerzu (wirtualna z domyślną implementacją)
5. `AddGarnish()` — haczyk (hook) — opcjonalne ozdoby (domyślnie nic nie robi)

Zaimplementuj co najmniej dwie konkretne klasy: `PastaRecipe` i `SoupRecipe`.  
`PastaRecipe` powinna przesłonić `AddGarnish()` by dodać "Parmesan i bazylia".

**Wymagania:**
- Metoda `Prepare()` powinna być `sealed`
- Użyj `virtual` dla metod z domyślną implementacją, `abstract` dla obowiązkowych

**Rozwiązanie:**

```csharp
abstract class Recipe
{
    public sealed void Prepare()
    {
        Console.WriteLine($"=== Przygotowuję: {Name} ===");
        GatherIngredients();
        PrepareIngredients();
        Cook();
        Plate();
        AddGarnish();
        Console.WriteLine("Gotowe!\n");
    }

    public abstract string Name { get; }
    protected abstract void GatherIngredients();
    
    protected virtual void PrepareIngredients()
        => Console.WriteLine("Myjemy i kroimy składniki");
    
    protected abstract void Cook();
    
    protected virtual void Plate()
        => Console.WriteLine($"Podaję {Name} na talerzu");
    
    protected virtual void AddGarnish() { } // hook — domyślnie nic
}

class PastaRecipe : Recipe
{
    public override string Name => "Spaghetti Carbonara";

    protected override void GatherIngredients()
        => Console.WriteLine("Makaron, jajka, boczek, parmezan, czosnek");
    
    protected override void Cook()
    {
        Console.WriteLine("Gotuję makaron al dente");
        Console.WriteLine("Smażę boczek, mieszam z jajkami i parmezanem");
    }

    protected override void AddGarnish()
        => Console.WriteLine("Dodaję starty parmezan i świeżą bazylię");
}

class SoupRecipe : Recipe
{
    public override string Name => "Zupa pomidorowa";

    protected override void GatherIngredients()
        => Console.WriteLine("Pomidory, cebula, czosnek, bulion, śmietana");

    protected override void Cook()
    {
        Console.WriteLine("Duszę warzywa, blenduję, dodaję bulion");
        Console.WriteLine("Gotuję 20 minut, doprawiam");
    }
}

// Użycie:
Recipe pasta = new PastaRecipe();
pasta.Prepare();

Recipe soup = new SoupRecipe();
soup.Prepare();
```

---

## Zadanie 2 — Parser plików danych

**Cel:** Zastosowanie Template Method do przetwarzania różnych formatów wejściowych.

**Treść:**  
Zaimplementuj abstrakcyjną klasę `DataParser` z metodą szablonową `Parse(string filePath)`:
1. `ReadFile(string path)` — zwraca zawartość pliku jako string (wirtualna, może być mockowana)
2. `ValidateFormat(string content)` — walidacja formatu (abstrakcyjna, zwraca bool)
3. `ParseData(string content)` — parsowanie (abstrakcyjna, zwraca `IEnumerable<string>`)
4. `TransformItem(string item)` — transformacja każdego elementu (hook, domyślnie: item.Trim())
5. `OutputResult(IEnumerable<string> items)` — wypisanie wyniku (wirtualna)

Zaimplementuj `CsvParser` (wiersze oddzielone przecinkami) i `TsvParser` (tabulatorem).

**Ograniczenie:** Nie używaj LINQ — użyj pętli i `yield return`.

**Rozwiązanie:**

```csharp
abstract class DataParser
{
    public IEnumerable<string> Parse(string content)
    {
        Console.WriteLine($"[{GetType().Name}] Walidacja...");
        if (!ValidateFormat(content))
            throw new FormatException($"Nieprawidłowy format dla {GetType().Name}");
        
        Console.WriteLine($"[{GetType().Name}] Parsowanie...");
        var items = ParseData(content);
        var result = new List<string>();
        foreach (var item in items)
            result.Add(TransformItem(item));
        
        OutputResult(result);
        return result;
    }

    protected abstract bool ValidateFormat(string content);
    protected abstract IEnumerable<string> ParseData(string content);
    protected virtual string TransformItem(string item) => item.Trim();
    protected virtual void OutputResult(IEnumerable<string> items)
    {
        foreach (var item in items)
            Console.WriteLine($"  > {item}");
    }
}

class CsvParser : DataParser
{
    protected override bool ValidateFormat(string content)
        => content.Contains(',');

    protected override IEnumerable<string> ParseData(string content)
    {
        foreach (var line in content.Split('\n'))
            foreach (var cell in line.Split(','))
                if (!string.IsNullOrWhiteSpace(cell))
                    yield return cell;
    }

    protected override string TransformItem(string item)
        => base.TransformItem(item).ToUpperInvariant();
}

class TsvParser : DataParser
{
    protected override bool ValidateFormat(string content)
        => content.Contains('\t');

    protected override IEnumerable<string> ParseData(string content)
    {
        foreach (var line in content.Split('\n'))
            foreach (var cell in line.Split('\t'))
                if (!string.IsNullOrWhiteSpace(cell))
                    yield return cell;
    }
}

// Użycie:
var csv = new CsvParser();
csv.Parse("Jan,Kowalski,Warszawa\nAnna,Nowak,Kraków");

var tsv = new TsvParser();
tsv.Parse("Jan\tKowalski\tWarszawa\nAnna\tNowak\tKraków");
```

---

## Zadanie 3 — Refaktoryzacja: zamiana Template Method na Strategię

**Cel:** Zrozumienie alternatyw dla Template Method przez refaktoryzację.

**Treść:**  
Masz poniższy kod z Template Method:

```csharp
abstract class Sorter
{
    public void Sort(int[] data)
    {
        Console.WriteLine($"Sortuję {data.Length} elementów metodą {AlgorithmName}");
        DoSort(data);
        Verify(data);
    }
    
    public abstract string AlgorithmName { get; }
    protected abstract void DoSort(int[] data);
    
    protected virtual void Verify(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            if (data[i] > data[i + 1])
                throw new Exception("Błąd sortowania!");
        Console.WriteLine("Weryfikacja: OK");
    }
}

class BubbleSorter : Sorter
{
    public override string AlgorithmName => "Bąbelkowe";
    protected override void DoSort(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            for (int j = 0; j < data.Length - i - 1; j++)
                if (data[j] > data[j + 1])
                    (data[j], data[j + 1]) = (data[j + 1], data[j]);
    }
}
```

**Zadanie:** Przepisz ten kod używając wzorca **Strategia** (interfejs `ISortStrategy`).  
Następnie opisz zalety i wady każdego podejścia w tym konkretnym przypadku.

**Rozwiązanie:**

```csharp
// Strategia: wyodrębnij zmienny algorytm do interfejsu
interface ISortStrategy
{
    string Name { get; }
    void Sort(int[] data);
}

class BubbleSortStrategy : ISortStrategy
{
    public string Name => "Bąbelkowe";
    public void Sort(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            for (int j = 0; j < data.Length - i - 1; j++)
                if (data[j] > data[j + 1])
                    (data[j], data[j + 1]) = (data[j + 1], data[j]);
    }
}

class InsertionSortStrategy : ISortStrategy
{
    public string Name => "Przez wstawianie";
    public void Sort(int[] data)
    {
        for (int i = 1; i < data.Length; i++)
        {
            int key = data[i];
            int j = i - 1;
            while (j >= 0 && data[j] > key)
                data[j + 1] = data[--j + 1];
            data[j + 1] = key;
        }
    }
}

// Kontekst (nie wymaga dziedziczenia!)
class SortContext(ISortStrategy strategy)
{
    public void Sort(int[] data)
    {
        Console.WriteLine($"Sortuję {data.Length} elementów metodą {strategy.Name}");
        strategy.Sort(data);
        Verify(data);
    }
    
    private void Verify(int[] data)
    {
        for (int i = 0; i < data.Length - 1; i++)
            if (data[i] > data[i + 1])
                throw new Exception("Błąd sortowania!");
        Console.WriteLine("Weryfikacja: OK");
    }
}

// Template Method: nowy algorytm = nowa podklasa (bez modyfikacji istniejących)
// Strategia: nowy algorytm = nowa klasa implementująca interfejs,
//            zmiana strategii w runtime (nie możliwe z Template Method!)
```

**Omówienie:**
- **Template Method**: sprawdza się gdy kroki algorytmu są ze sobą ściśle powiązane, lub gdy chcemy wymusić framework (hook'i w konkretnych miejscach). Nie da się zmienić algorytmu w runtime.
- **Strategia**: sprawdza się gdy chcemy wybierać algorytm dynamicznie lub wstrzykiwać go przez DI. Luźniejsze powiązania (kompozycja > dziedziczenie).

---

## Zadanie 4 — Hook: opcjonalne powiadomienia

**Cel:** Praktyczne zastosowanie hooków (*punktów rozszerzenia*) w Template Method.

**Treść:**  
Zaimplementuj klasę `OrderProcessor` z metodą szablonową `ProcessOrder(Order order)`:
1. `ValidateOrder(order)` — walidacja (abstrakcyjna)
2. `CalculateTotal(order)` — obliczenie sumy (abstrakcyjna, zwraca decimal)
3. `ApplyDiscount(total)` — haczyk (domyślnie: brak rabatu, zwraca total bez zmian)
4. `ChargePayment(total)` — płatność (abstrakcyjna)
5. `SendConfirmation(order)` — haczyk (domyślnie: log do konsoli)

Zaimplementuj `PremiumOrderProcessor` który:
- w `ApplyDiscount` stosuje 10% zniżkę
- w `SendConfirmation` wysyła "email VIP"

**Rozwiązanie:**

```csharp
record Order(string Id, string Customer, decimal Amount, bool IsPremium);

abstract class OrderProcessor
{
    // Sealed — nikt nie może zmienić kolejności kroków!
    public sealed void ProcessOrder(Order order)
    {
        Console.WriteLine($"\n[Order {order.Id}] Rozpoczynam przetwarzanie...");
        ValidateOrder(order);
        decimal total = CalculateTotal(order);
        decimal finalTotal = ApplyDiscount(total);
        ChargePayment(finalTotal);
        SendConfirmation(order);
        Console.WriteLine($"[Order {order.Id}] Zakończono. Do zapłaty: {finalTotal:C}");
    }
    
    protected abstract void ValidateOrder(Order order);
    protected abstract decimal CalculateTotal(Order order);
    
    // Hook — domyślnie brak rabatu
    protected virtual decimal ApplyDiscount(decimal total) => total;
    
    protected abstract void ChargePayment(decimal total);
    
    // Hook — domyślna implementacja
    protected virtual void SendConfirmation(Order order)
        => Console.WriteLine($"  Potwierdzenie: zamówienie {order.Id} dla {order.Customer}");
}

class StandardOrderProcessor : OrderProcessor
{
    protected override void ValidateOrder(Order order)
    {
        if (order.Amount <= 0) throw new ArgumentException("Kwota musi być > 0");
        Console.WriteLine($"  Walidacja: OK (kwota: {order.Amount:C})");
    }

    protected override decimal CalculateTotal(Order order)
    {
        decimal vat = order.Amount * 0.23m;
        Console.WriteLine($"  Suma + VAT 23%: {order.Amount + vat:C}");
        return order.Amount + vat;
    }

    protected override void ChargePayment(decimal total)
        => Console.WriteLine($"  Płatność kartą: {total:C} — zatwierdzona");
}

class PremiumOrderProcessor : StandardOrderProcessor
{
    // Hook — 10% rabat dla VIP
    protected override decimal ApplyDiscount(decimal total)
    {
        decimal discount = total * 0.10m;
        Console.WriteLine($"  Rabat VIP 10%: -{discount:C}");
        return total - discount;
    }

    // Hook — email VIP zamiast standardowego potwierdzenia
    protected override void SendConfirmation(Order order)
    {
        base.SendConfirmation(order);
        Console.WriteLine($"  Email VIP wysłany do {order.Customer} z podziękowaniem");
    }
}

// Użycie:
var standard = new StandardOrderProcessor();
standard.ProcessOrder(new Order("ORD-001", "Jan Kowalski", 100m, false));

var premium = new PremiumOrderProcessor();
premium.ProcessOrder(new Order("ORD-002", "Anna Nowak VIP", 200m, true));
```

---

## Zadanie 5 — Pytania teoretyczne

**Pytanie 1:** Dlaczego metoda szablonowa powinna być oznaczona `sealed` (lub `final` w Javie)? Co się stanie, gdy podklasa ją przesłoni?

**Odpowiedź:** Jeśli podklasa przesłoni metodę szablonową, może dowolnie zmienić kolejność kroków algorytmu lub całkowicie zignorować kroki abstrakcyjne. Narusza to zasadę Hollywood Principle ("nie dzwoń do nas, my zadzwonimy do ciebie") — klasa bazowa traci kontrolę nad algorytmem. `sealed` zapobiega temu i gwarantuje niezmienną strukturę procesu.

---

**Pytanie 2:** Opisz zasadę Hollywood Principle i wyjaśnij jej związek z Template Method.

**Odpowiedź:** Zasada Hollywood: "Nie dzwoń do nas, my zadzwonimy do ciebie" — niskopoziomowe komponenty (podklasy) nie wywołują bezpośrednio wysoko-poziomowych komponentów (klasy bazowej). Zamiast tego klasa bazowa wywołuje metody podklas w odpowiednim momencie (odwrócenie sterowania). Template Method idealnie implementuje tę zasadę: podklasa definiuje *co* robić, klasa bazowa decyduje *kiedy* to wywołać.

---

**Pytanie 3:** Kiedy wybrać Template Method zamiast Strategii, a kiedy odwrotnie?

**Odpowiedź:**

| Kryterium | Template Method | Strategia |
|-----------|-----------------|-----------|
| Zmiana algorytmu w runtime | ✗ Niemożliwe | ✓ Możliwe |
| Typ rozszerzenia | Dziedziczenie | Kompozycja |
| Zależność kroków | Kroki współdzielą stan przez `this` | Strategia jest izolowana |
| Dodawanie wariantów | Nowa podklasa | Nowa klasa implementująca interfejs |
| Zasada OCP | Wymaga nowej podklasy | Wymaga nowej implementacji interfejsu |
| Ilość punktów zmienności | Wiele kroków (N > 2) | Jeden algorytm |

Reguła: jeśli masz **jeden** punkt zmienności → Strategia; jeśli masz **wiele kroków** które razem tworzą algorytm → Template Method.
