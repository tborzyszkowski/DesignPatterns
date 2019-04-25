namespace ShallowCopy
{
    public abstract class Prototype<T> where T : class
    {
        public T ShallowCopy()
        {
            return MemberwiseClone() as T;
        }
    }
}
