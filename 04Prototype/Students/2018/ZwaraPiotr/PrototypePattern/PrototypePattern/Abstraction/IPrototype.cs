namespace PrototypePattern.Abstraction
{
    public interface IPrototype<T>
        where T : IPrototype<T>
    {
        T ShallowClone();
        T DeepClone();
    }
}
