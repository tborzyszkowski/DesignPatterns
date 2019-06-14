using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Observer
{
    public abstract class ProductObserver
    {
        public abstract void ActivationObserver(InterfaceObserver observer);
        public abstract void deactivationObserver(InterfaceObserver observer);
        public abstract void notificationObserver();
    }
}