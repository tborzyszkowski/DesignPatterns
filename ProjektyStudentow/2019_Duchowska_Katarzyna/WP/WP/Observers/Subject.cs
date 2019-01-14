using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Observers
{
    public abstract class Subject
    {
        protected List<Observer> observers;

        public Subject()
        {
            observers = new List<Observer>();
        }

        public void Add(Observer observer)
        {
            observers.Add(observer);
        }

        public void Remove(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify(double price)
        {
            observers.ForEach(o => o.Update(price));
        }
    }
}
