using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Observable
{
    public abstract class PlateObservable
    {
        public abstract void AttachObserver(IObserver observer);
        public abstract void RemoveObserver(IObserver observer);
        public abstract void notifyObservers();
    }
}
