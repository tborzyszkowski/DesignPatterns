using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Iterator
{
    public class MyDataIterator<T> : IIterator<T>
    {
        private IMyData<T> aggregate;

        private List<T> collection = new List<T>();  //the actual collection you are traversing
        private int pointer = 0;  //keeps track of the current position

        public MyDataIterator(IMyData<T> i)
        {
            aggregate = i;
        }

        public int getSize()
        {
            return collection.Count();
        }
        T IIterator<T>.First()
        {
            //move pointer to the first element in the aggregate and return it
            pointer = 0;
            return collection[pointer];
        }

        T IIterator<T>.Next()
        {
            //move pointer to the next element in the aggregate and return it
            pointer++;
            return collection[pointer];
        }

        T IIterator<T>.CurrentItem()
        {
            //return the element that the pointer is pointing to
            return collection[pointer];
        }

        bool IIterator<T>.IsDone()
        {
            //return true if pointer is pointing to the last element, else return false
            return pointer == collection.Count - 1;
        }

        void IIterator<T>.AddItem(T item)
        {
            collection.Add(item);
        }

        public void Remove(T item)
        {
            collection.Remove(item);
        }

        public int Find(T item)
        {
            return collection.IndexOf(item);
        }

    }
}
