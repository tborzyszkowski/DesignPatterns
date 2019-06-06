using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Iterator
{
    public interface IMyData<T>
    {
        IIterator<T> CreateIterator();
        List<T> GetAll();
        void AddItem(T item);
        T Find(T item);
        void Remove(T item);
    }
}
