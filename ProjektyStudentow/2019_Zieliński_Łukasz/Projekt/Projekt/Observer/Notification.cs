using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt.Observer
{
    public class Notification : InterfaceObserver
    {
        public void Obsevr(ProductObserver productObserv)
        {
            Console.WriteLine("Produkt :  " + productObserv + " gotowy. ");
        }
    }
}

