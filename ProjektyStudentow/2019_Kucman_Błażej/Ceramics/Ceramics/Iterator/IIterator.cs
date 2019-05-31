using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Iterator
{
    public interface IIterator<T>
    {
        T First();
        T Next();
        T CurrentItem();
        void Remove(T item);
        int Find(T item);
        bool IsDone();
        int getSize();
        void AddItem(T item);
    }
}
