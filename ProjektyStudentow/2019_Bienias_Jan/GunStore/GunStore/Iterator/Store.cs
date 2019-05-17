using GunStore.Enums;
using GunStore.Visitor;
using System.Collections.Generic;

namespace GunStore.Iterator
{
    //Concrete Aggregate
    public class Store : ICollection<Gun>
    {
        private List<Gun> _guns = new List<Gun>();

        public IIterator<Gun> CreateIterator()
        {
            return new StoreIterator(this);
        }

        public int Count
        {
            get { return _guns.Count; }
        }

        public Gun this[int index]
        {
            get { return _guns[index]; }
        }

        public List<Gun> Find(string name)
        {
            return _guns.FindAll(p => p.Name.ToLower().Contains(name.ToLower()));
        }

        public List<Gun> Find(GunType type)
        {
            return _guns.FindAll(p => p.Type == type);
        }

        public void Add(Gun gun)
        {
            int index = _guns.FindIndex(p => p.Equals(gun));
            if (index == -1)
            {
                _guns.Add(gun);
                gun.Count++;
            }
            else
                _guns[index].Count++;
        }

        public Gun Remove(int i)
        {
            if (i >= _guns.Count || i < 0)
                return null;
            else
            {
                var result = _guns[i].Clone();
                result.Count = 0;
                if (_guns[i].Count > 1)
                    _guns[i].Count--;
                else
                    _guns.RemoveAt(i);
                return result;
            }
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var g in _guns)
                g.Accept(visitor);
        }
    }
}
