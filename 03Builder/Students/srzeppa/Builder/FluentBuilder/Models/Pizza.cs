namespace FluentBuilder.Models
{
    public class Pizza
    {
        public string Name { get; set; }
        public bool Cheese { get; set; }
        public bool Ham { get; set; }
        public bool Baked { get; set; }

        public string GetPizza()
        {
            return $"{Name} Cheese: {Cheese} Ham: {Ham} Baked: {Baked}";
        }
    }
}
