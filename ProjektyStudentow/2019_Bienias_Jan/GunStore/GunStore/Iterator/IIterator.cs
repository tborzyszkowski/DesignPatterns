namespace GunStore.Iterator
{
    //Iterator
    public interface IIterator<T>
    {
        int CurrentIndex { get; }
        T First();
        T Last();
        T Next();
        T Prev();
        T At(int i);
        T Current { get; }
    }
}
