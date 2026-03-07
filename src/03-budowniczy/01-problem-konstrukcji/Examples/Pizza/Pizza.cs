namespace ProblemKonstrukcji;

// ============================================================
// ANTYPATTERN: Telescoping Constructor
// ============================================================

/// <summary>
/// Pizza zbudowana przez "teleskopowy konstruktor".
/// Każdy wariant kombinacji wymaga osobnego konstruktora.
/// Kod klienta jest nieczytelny: co oznacza trzecie `true`?
/// </summary>
public class PizzaTelescoping
{
    public string Size       { get; }
    public bool   Cheese     { get; }
    public bool   Pepperoni  { get; }
    public bool   Bacon      { get; }
    public bool   Mushrooms  { get; }
    public bool   Onions     { get; }

    // Wymagane pole
    public PizzaTelescoping(string size)
        : this(size, false) { }

    public PizzaTelescoping(string size, bool cheese)
        : this(size, cheese, false) { }

    public PizzaTelescoping(string size, bool cheese, bool pepperoni)
        : this(size, cheese, pepperoni, false) { }

    public PizzaTelescoping(string size, bool cheese, bool pepperoni, bool bacon)
        : this(size, cheese, pepperoni, bacon, false) { }

    public PizzaTelescoping(string size, bool cheese, bool pepperoni, bool bacon, bool mushrooms)
        : this(size, cheese, pepperoni, bacon, mushrooms, false) { }

    public PizzaTelescoping(string size, bool cheese, bool pepperoni, bool bacon, bool mushrooms, bool onions)
    {
        Size      = size;
        Cheese    = cheese;
        Pepperoni = pepperoni;
        Bacon     = bacon;
        Mushrooms = mushrooms;
        Onions    = onions;
    }

    public override string ToString() =>
        $"Pizza [{Size}] cheese={Cheese} pepperoni={Pepperoni} bacon={Bacon} mushrooms={Mushrooms} onions={Onions}";
}

// ============================================================
// PRÓBA NAPRAWY 1: Object Initializer
// — lepiej, ale obiekt musi być mutowalny i nie ma walidacji
// ============================================================

public class PizzaMutable
{
    public string Size      { get; set; } = "medium";
    public bool   Cheese    { get; set; }
    public bool   Pepperoni { get; set; }
    public bool   Bacon     { get; set; }
    public bool   Mushrooms { get; set; }
    public bool   Onions    { get; set; }

    public override string ToString() =>
        $"Pizza [{Size}] cheese={Cheese} pepperoni={Pepperoni} bacon={Bacon}";
}

// ============================================================
// ROZWIĄZANIE: Builder — czytalne, bezpieczne, rozszerzalne
// ============================================================

/// <summary>
/// Pizza niemutowalna — wszystkie właściwości ustawiane tylko przez Builder.
/// </summary>
public sealed class Pizza
{
    public string Size       { get; }
    public bool   Cheese     { get; }
    public bool   Pepperoni  { get; }
    public bool   Bacon      { get; }
    public bool   Mushrooms  { get; }
    public bool   Onions     { get; }

    // Konstruktor prywatny — tylko Builder może tworzyć
    private Pizza(Builder b)
    {
        Size      = b.Size;
        Cheese    = b.Cheese;
        Pepperoni = b.Pepperoni;
        Bacon     = b.Bacon;
        Mushrooms = b.Mushrooms;
        Onions    = b.Onions;
    }

    public override string ToString() =>
        $"Pizza [{Size}]{(Cheese ? " +cheese" : "")}{(Pepperoni ? " +pepperoni" : "")}" +
        $"{(Bacon ? " +bacon" : "")}{(Mushrooms ? " +mushrooms" : "")}{(Onions ? " +onions" : "")}";

    // ----- Zagnieżdżony Builder ----------------------------------------

    public class Builder
    {
        // Jeden parametr obowiązkowy
        public string Size       { get; }
        public bool   Cheese     { get; private set; }
        public bool   Pepperoni  { get; private set; }
        public bool   Bacon      { get; private set; }
        public bool   Mushrooms  { get; private set; }
        public bool   Onions     { get; private set; }

        public Builder(string size)
        {
            if (string.IsNullOrWhiteSpace(size))
                throw new ArgumentException("Size jest wymagany");
            Size = size;
        }

        public Builder WithCheese()    { Cheese    = true; return this; }
        public Builder WithPepperoni() { Pepperoni = true; return this; }
        public Builder WithBacon()     { Bacon     = true; return this; }
        public Builder WithMushrooms() { Mushrooms = true; return this; }
        public Builder WithOnions()    { Onions    = true; return this; }

        public Pizza Build() => new Pizza(this);
    }
}
