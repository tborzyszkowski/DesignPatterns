namespace Prototype.ShallowPrototype
{
    public abstract class Prototype<T> where T : class
    {
        public T Clone()
        {
            return MemberwiseClone() as T;
        }
    }
}
