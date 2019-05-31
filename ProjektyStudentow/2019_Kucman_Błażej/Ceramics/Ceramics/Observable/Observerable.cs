using Ceramics.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Observable
{
    public class Observerable : PlateObservable
    {
        private IMyData<IObserver> observers = new MyData<IObserver>();
        
        PlateObservable plateObservable;

        public Observerable(PlateObservable plateObservable)
        {
            this.plateObservable = plateObservable;
        }

        public override void AttachObserver(IObserver observer)
        {
            observers.AddItem(observer);
        }

        public override void notifyObservers()
        {
            foreach(IObserver observer in observers.GetAll())
            {
                observer.update(plateObservable);
            }
        }

        public override void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public IMyData<IObserver> getObservers()
        {
            return observers;
        }


    }
}
