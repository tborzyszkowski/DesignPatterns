namespace AbstractFactory.Tanks
{
    public abstract class AbstractFactory
    {
        public abstract AbstractGerman createGermanTank();
        public abstract AbstractUSA createUSATank();
    }
}
