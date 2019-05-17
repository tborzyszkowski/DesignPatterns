namespace Factory.SimpleFactory
{
    public interface IComputer
    {
        string Manufacturer { get; set; }
        string Model { get; set; }
        string Country { get; set; }
        int ProdYear { get; set; }
        int Price { get; set; }

        void setUp();
        void build();
    }
}
