namespace AbstractFactory.Cars
{
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractFord createFord()
        {
            return new Fiesta();
        }

        public override AbstractToyota createToyota()
        {
            return new Auris();
        }
    }
}
