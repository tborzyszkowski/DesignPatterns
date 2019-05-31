using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Iterator
{
    public class MyData<T> : IMyData<T>
    {
        private IIterator<T> iterator;

        public MyData()
        {
            (this as IMyData<T>).CreateIterator();  //create the iterator
        }

        IIterator<T> IMyData<T>.CreateIterator()
        {
            //create iterator if not already done
            if (iterator == null)
                iterator = new MyDataIterator<T>(this);
            return iterator;
        }

        List<T> IMyData<T>.GetAll()
        {

            List<T> list = new List<T>();
            if (iterator.getSize() != 0)
            {
                list.Add(iterator.First());
                
                while (!iterator.IsDone())
                {
                    list.Add(iterator.Next());
                }
            }
            return list;
        }

        void IMyData<T>.AddItem(T item)
        {
            iterator.AddItem(item);
        }

        public void Remove(T item)
        {
            int i = iterator.Find(item);
            if( i != -1 ) iterator.Remove(item);
        }

        T IMyData<T>.Find(T item)
        {
            var x = iterator.First();
            if (x.Equals(item))
                return x;
            while (!iterator.IsDone())
            {
                x = iterator.Next();
                if (x.Equals(item))
                    return x;
            }
            
            return x ;
        }
    }
}
