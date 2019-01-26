using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public abstract class Component : ISubject
    {
        private List<Observer> observers = new List<Observer>();

        abstract public void AddChild(Component gr);
        abstract public void Traverse();
        abstract public String getName();

        public void Attach(Observer observer)
        {       
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }
}
