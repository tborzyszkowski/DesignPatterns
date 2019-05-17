using GunStore.Decorator;
using GunStore.Enums;
using GunStore.Iterator;
using System.Collections.Generic;

namespace GunStore.Facade
{
    //Facade Class (for potential User)
    //communication with GunMagazine + GunIterator + weapon Decorating
    public class GunShop
    {
        private Store _store;
        private StoreIterator _storeIterator;

        public GunShop(Store gunMagazine)
        {
            _store = gunMagazine;
            _storeIterator = _store.CreateIterator() as StoreIterator;
        }

        public List<Gun> ShowAll()
        {
            int saveIndex = _storeIterator.CurrentIndex;
            _storeIterator.At(0);
            List<Gun> result = new List<Gun>();
            do
            {
                result.Add(_storeIterator.Current);
            } while (_storeIterator.Next() != null);
            _storeIterator.At(saveIndex);
            return result;
        }

        public List<Gun> Find(string name)
        {
            return _store.Find(name);
        }

        public List<Gun> Find(GunType type)
        {
            return _store.Find(type);
        }

        public int CurrentIndex
        {
            get => _storeIterator.CurrentIndex;
        }

        public string ShowNext()
        {
            return _storeIterator.Next() + StoredGunCount(_storeIterator.Current);
        }

        public string ShowPrev()
        {
            return _storeIterator.Prev() + StoredGunCount(_storeIterator.Current);
        }

        public string At(int index)
        {
            return _storeIterator.At(index) + StoredGunCount(_storeIterator.Current);
        }

        public Gun Buy(int id)
        {
            //... money logic ...
            return _store.Remove(id);
        }

        public Silencer AttachSilencer(Gun gun)
        {
            //... money logic ...
            return new Silencer(gun);
        }

        public LaserSight AttachLaserSight(Gun gun)
        {
            //... money logic ...
            return new LaserSight(gun);
        }

        public HoloSight AttachHoloSight(Gun gun)
        {
            //... money logic ...
            return new HoloSight(gun);
        }

        private string StoredGunCount(Gun gun)
        {
            return " [COUNT: " + gun.Count + "]";
        }
    }
}
