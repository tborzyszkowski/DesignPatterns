namespace FactoryPattern.Domain.Abstraction
{
    public interface IGamingPC : IComputer
    {
        string DedicatedGraphicsCard { get; set; }
    }
}
