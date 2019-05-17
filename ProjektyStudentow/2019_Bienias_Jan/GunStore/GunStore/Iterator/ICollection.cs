namespace GunStore.Iterator
{
    //Aggregate
    public interface ICollection<T>
    {
        IIterator<T> CreateIterator();
    }
}
