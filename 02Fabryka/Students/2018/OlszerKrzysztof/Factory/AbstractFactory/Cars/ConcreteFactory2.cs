namespace AbstractFactory.Cars
{
    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractFord createFord()
        {
            return new Focus();
        }

        public override AbstractToyota createToyota()
        {
            return new Yaris();
        }
    }
}
