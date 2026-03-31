// =============================================================
//  Warianty implementacji wzorca Prototyp w C# (.NET 9)
//  Plik: Variants/CloneVariants.cs
// =============================================================

using System.Runtime.CompilerServices;

namespace TypyImplementacji;

// ─────────────────────────────────────────────────────────────
//  WARIANT 1 — Interfejs ICloneable (historyczny, niezalecany)
//  ICloneable pochodzi z .NET 1.0. Główna wada: Clone() zwraca
//  object, co wymusza rzutowanie u klienta i nie precyzuje,
//  czy kopia jest płytka czy głęboka.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Karta pojazdu implementująca przestarzały ICloneable.
/// </summary>
public class VehicleCardLegacy : ICloneable
{
    public string Brand   { get; set; } = "";
    public string Model   { get; set; } = "";
    public int    Year    { get; set; }
    public List<string> Features { get; set; } = [];

    /// <summary>
    /// Płytka kopia — Features wskazuje na tę samą instancję listy!
    /// Użytkownicy interfejsu ICloneable nie wiedzą, co dostaną.
    /// </summary>
    public object Clone()
    {
        // MemberwiseClone() kopiuje wartości pól bit-po-bicie:
        //   - typy wartościowe (int, double) → skopiowane
        //   - łańcuchy (string)              → skopiowane (immutable)
        //   - referencje (list, class...)    → WSPÓŁDZIELONE (!)
        return MemberwiseClone();   // <── płytka kopia
    }

    public override string ToString() =>
        $"{Year} {Brand} {Model}  Features@{RuntimeHelpers.GetHashCode(Features):X}";
}

// ─────────────────────────────────────────────────────────────
//  WARIANT 2 — Własny interfejs IPrototype<T>
//  Generyczny interfejs eliminuje problem braku bezpieczeństwa
//  typów: Clone() zwraca T, nie object.
// ─────────────────────────────────────────────────────────────

public interface IPrototype<T>
{
    T Clone();
}

/// <summary>
/// Karta pojazdu z własnym genericowym interfejsem klonowania.
/// </summary>
public class VehicleCard : IPrototype<VehicleCard>
{
    public string Brand   { get; set; } = "";
    public string Model   { get; set; } = "";
    public int    Year    { get; set; }
    public List<string> Features { get; set; } = [];

    /// <summary>
    /// Głęboka kopia — Features jest nową listą z tymi samymi wartościami.
    /// Typ zwracany to <c>VehicleCard</c>, nie <c>object</c>.
    /// </summary>
    public VehicleCard Clone() => new()
    {
        Brand    = Brand,
        Model    = Model,
        Year     = Year,
        Features = [.. Features]   // nowa lista, te same wartości
    };

    public override string ToString() =>
        $"{Year} {Brand} {Model}  Features@{RuntimeHelpers.GetHashCode(Features):X}";
}

// ─────────────────────────────────────────────────────────────
//  WARIANT 3 — Abstrakcyjna klasa bazowa PrototypeBase<T>
//  Pozwala umieścić wspólną logikę (np. rejestr) w klasie bazowej
//  i wymuszać implementację Clone() w podklasach.
// ─────────────────────────────────────────────────────────────

public abstract class PrototypeBase<T> where T : PrototypeBase<T>
{
    /// <summary>Tworzy głęboką kopię bieżącego obiektu.</summary>
    public abstract T Clone();
}

/// <summary>
/// Konfiguracja serwera używająca generycznej klasy bazowej.
/// </summary>
public sealed class ServerConfig : PrototypeBase<ServerConfig>
{
    public string Environment { get; init; } = "dev";
    public int    Port        { get; init; } = 8080;
    public List<string> AllowedHosts { get; init; } = [];

    internal ServerConfig() { }

    /// <summary>Symuluje drogi załadunek konfiguracji (100 ms).</summary>
    public static ServerConfig LoadFromServer(string environment)
    {
        Console.Write($"  Ładowanie konfiguracji '{environment}' z serwera...");
        Thread.Sleep(100);
        Console.WriteLine(" gotowe.");

        return new ServerConfig
        {
            Environment  = environment,
            Port         = environment == "prod" ? 443 : 8080,
            AllowedHosts = ["localhost", "10.0.0.1"]
        };
    }

    /// <summary>Szybka głęboka kopia (nie wymaga Thread.Sleep).</summary>
    public override ServerConfig Clone() => new()
    {
        Environment  = Environment,
        Port         = Port,
        AllowedHosts = [.. AllowedHosts]
    };

    public override string ToString() =>
        $"[{Environment}] :{Port}  Hosts@{RuntimeHelpers.GetHashCode(AllowedHosts):X}";
}

// ─────────────────────────────────────────────────────────────
//  WARIANT 4 — Konstruktor kopiujący (zalecany w nowoczesnym C#)
//  Konstruktor kopiujący to idiom z C++, świetnie sprawdza się
//  w C#: pełna kontrola nad głębią kopii, bez konieczności
//  dziedziczenia z jakiegokolwiek interfejsu.
// ─────────────────────────────────────────────────────────────

public class Address
{
    public string Street { get; set; } = "";
    public string City   { get; set; } = "";

    public Address() { }

    /// <summary>Konstruktor kopiujący dla Address.</summary>
    public Address(Address source)
    {
        Street = source.Street;
        City   = source.City;
    }

    public override string ToString() => $"{Street}, {City}";
}

public class Employee
{
    public string  Name    { get; set; } = "";
    public string  Role    { get; set; } = "";
    public Address Address { get; set; } = new();
    public List<string> Skills { get; set; } = [];

    public Employee() { }

    /// <summary>
    /// Konstruktor kopiujący — głęboka kopia wszystkich pól.
    /// Bardziej czytelny niż Clone() + cast, brak potrzeby
    /// implementacji żadnego interfejsu.
    /// </summary>
    public Employee(Employee source)
    {
        Name    = source.Name;
        Role    = source.Role;
        Address = new Address(source.Address);   // głęboka kopia Address
        Skills  = [.. source.Skills];            // głęboka kopia listy
    }

    /// <summary>Opcjonalny factory method dla wygody klienta.</summary>
    public Employee Clone() => new(this);

    public override string ToString() =>
        $"{Name} ({Role})  Address@{RuntimeHelpers.GetHashCode(Address):X}  " +
        $"Skills=[{string.Join(", ", Skills)}]";
}

// ─────────────────────────────────────────────────────────────
//  WARIANT 5 — Record z wyrażeniem „with" (C# 9+)
//  Records to niemutowalne typy wartościowe z wbudowaną
//  semantyką value-equality. with-expression tworzy płytką
//  kopię z wybranymi polami nadpisanymi.
//  Idealny dla obiektów-wartości (Value Objects), nie nadaje się
//  dla obiektów zawierających mutowalne kolekcje.
// ─────────────────────────────────────────────────────────────

/// <summary>
/// Konfiguracja połączenia jako niemutowalny record.
/// </summary>
public record ConnectionOptions(
    string Host,
    int    Port,
    bool   UseSsl,
    int    TimeoutMs = 5000
)
{
    // Records mają automatyczny, kompilowany z parametrów konstruktor.
    // with-expression: var b = a with { Port = 443, UseSsl = true };
}


