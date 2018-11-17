namespace AbstractFactory.Tanks
{
    public class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractGerman createGermanTank()
        {
            return new Maus();
        }

        public override AbstractUSA createUSATank()
        {
            return new Abrams();
        }
    }
}
