namespace CarsCms.Interfaces
{
    public interface IBuilderAbstract<T> where T : class
    {
        T GetProduct();

    }
}
