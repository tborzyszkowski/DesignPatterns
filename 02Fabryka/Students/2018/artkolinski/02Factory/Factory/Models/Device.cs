namespace Factory.Models
{
    public abstract class Device
    {
        public abstract string Model { get; }
        public abstract string Manufacturer { get; }
        public abstract int Memory { get; }
    }
}
