namespace GunStore.Prototype
{
    public interface IPrototype<T> where T : class
    {
        T Clone();
    }
}
