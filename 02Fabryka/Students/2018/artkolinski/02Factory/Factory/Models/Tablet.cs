namespace Factory.Models
{
    public class Tablet : Device
    {
        public override string Model => "Air 2";
        public override string Manufacturer => "Apple";
        public override int Memory => 64;
    }
}
