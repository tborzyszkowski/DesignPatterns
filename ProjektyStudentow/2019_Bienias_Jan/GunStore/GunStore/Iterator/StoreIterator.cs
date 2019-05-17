namespace GunStore.Iterator
{
    //Concrete Iterator
    public class StoreIterator : IIterator<Gun>
    {
        private Store _store;
        public int CurrentIndex { get; private set; }

        public StoreIterator(Store store)
        {
            _store = store;
        }

        public Gun First()
        {
            CurrentIndex = 0;
            return _store[CurrentIndex];
        }

        public Gun Last()
        {
            CurrentIndex = _store.Count - 1;
            return _store[CurrentIndex];
        }

        public Gun Next()
        {
            if (CurrentIndex < _store.Count - 1)
            {
                CurrentIndex += 1;
                return _store[CurrentIndex];
            }
            else
                return null;
        }

        public Gun At(int i)
        {
            if (i < _store.Count && i >= 0)
            {
                CurrentIndex = i;
                return _store[i];
            }
            else
                return null;
        }

        public Gun Prev()
        {
            if (CurrentIndex > 0)
            {
                CurrentIndex -= 1;
                return _store[CurrentIndex];
            }
            else
                return null;
        }

        public Gun Current
        {
            get { return _store[CurrentIndex]; }
        }
    }
}
