namespace AbstractFactory.Tanks
{
    public class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractGerman createGermanTank()
        {
            return new Tiger();
        }

        public override AbstractUSA createUSATank()
        {
            return new Pershing();
        }
    }
}
