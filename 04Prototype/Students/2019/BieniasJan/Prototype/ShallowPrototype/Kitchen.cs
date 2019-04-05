namespace Prototype.ShallowPrototype
{
    public class Kitchen
    {
        public Chef Chef { get; set; }

        public Kitchen(Chef chef)
        {
            Chef = chef;
        }
    }
}
