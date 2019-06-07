namespace Builder.BuilderBetter.Factory
{
    public interface IComputerFactory
    {
        Computer CreateComputer(string type);
    }
}
