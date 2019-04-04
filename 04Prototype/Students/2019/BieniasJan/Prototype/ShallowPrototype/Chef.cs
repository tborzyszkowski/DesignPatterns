namespace Prototype.ShallowPrototype
{
    public class Chef
    {
        public Assistant Assistant { get; set; }

        public Chef(Assistant assistant)
        {
            Assistant = assistant;
        }
    }
}
