namespace Builder.BuilderOverFactory.AbstractFactory
{
    public class DodgeViper : Dodge
    {
        public DodgeViper()
        {
            Name = "1996 Dodge Viper GTS";
            Price = 250_000;
            YearOfProduction = 1996;
            TopSpeed = 280;
            Engine = "Viper Engine";
        }
    }
}
