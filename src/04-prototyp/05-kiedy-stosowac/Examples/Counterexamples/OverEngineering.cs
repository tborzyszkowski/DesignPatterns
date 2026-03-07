// =============================================================
//  Przykłady "kiedy NIE stosować" Prototypu
//  Plik: Counterexamples/OverEngineering.cs
// =============================================================

namespace KiedyStosowac;

// ─────────────────────────────────────────────────────────────
//  PRZYKŁAD 1: Prosty obiekt wartości — Prototyp to over-engineering
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Punkt na płaszczyźnie. To tylko 2 liczby — use a constructor!
/// Prototyp nie ma tu żadnej wartości.
/// </summary>
public record Point(double X, double Y);

// ŹLE — niepotrzebna abstrakcja:
// public class PointPrototype : IPrototype<PointPrototype> { ... }

// DOBRZE — zwykły konstruktor albo record-with jest wystarczający:
// var p2 = p1 with { X = 5.0 };


// ─────────────────────────────────────────────────────────────
//  PRZYKŁAD 2: Obiekt zawsze tworzony z nowych danych (Factory jest lepszy)
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Zamówienie e-commerce — każde jest inne: inny klient, inne produkty, inna data.
/// Klonowanie starego zamówienia nie ma sensu. Factory/Builder — tak.
/// </summary>
public class Order
{
    public Guid     OrderId    { get; } = Guid.NewGuid();
    public DateTime CreatedAt  { get; } = DateTime.UtcNow;
    public string   CustomerId { get; init; } = "";
    public List<(string Sku, int Qty, decimal Price)> Lines { get; init; } = [];

    // NIE dodawaj tu Clone() — każde zamówienie powinno mieć
    // świeże ID i datę; "klonowanie" zamówienia to błąd domenowy.
}

/// <summary>Fabrykuje zamówienia z odpowiednich danych — to właściwe rozwiązanie.</summary>
public static class OrderFactory
{
    public static Order Create(string customerId,
                               IEnumerable<(string Sku, int Qty, decimal Price)> lines)
        => new Order
        {
            CustomerId = customerId,
            Lines      = [.. lines]
        };
}


// ─────────────────────────────────────────────────────────────
//  PRZYKŁAD 3: Over-engineered klon prostego DTO
// ─────────────────────────────────────────────────────────────

// ŹLE — registry wrogów dla jednorazowego skryptu generującego raport:
// public class ReportRowRegistry { ... }   // to overkill

/// <summary>
/// Wiersz raportu: wystarczy `with` lub nowy konstruktor.
/// Wzorzec Prototyp nie jest potrzebny.
/// </summary>
public record ReportRow(string ProductName, int Quantity, decimal UnitPrice)
{
    public decimal Total => Quantity * UnitPrice;
}
// var adjusted = row with { Quantity = row.Quantity * 2 };  — wystarczy
