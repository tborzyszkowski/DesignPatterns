namespace Prototype.ShallowPrototype
{
    public class Restaurant : Prototype<Restaurant>
    {
        public Kitchen Kitchen { get; set; }

        public Restaurant(Kitchen kitchen)
        {
            Kitchen = kitchen;
        }
    }
}
