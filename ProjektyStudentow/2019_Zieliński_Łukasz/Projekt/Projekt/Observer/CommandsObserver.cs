using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Observer
{
    public class CommandsObserver : ProductObserver
    {
        
        protected List<InterfaceObserver> observers;
        ProductObserver productObserv;

        public CommandsObserver(ProductObserver productObserv)
        {
            this.productObserv = productObserv;
        }

        public override void ActivationObserver(InterfaceObserver observer)
        {
            observers.Add(observer);
        }

        public override void notificationObserver()
        {
            foreach (InterfaceObserver observer in observers)
            {
                observer.Obsevr(productObserv);
            }
        }

        public override void deactivationObserver(InterfaceObserver observer)
        {
            observers.Remove(observer);
        }
    }
}
