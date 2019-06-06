using Ceramics.Ceramics;
using Ceramics.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Observable
{
    // Garncarz ( ktoś kto mógł by robić ceramike :D )
    public class Seller : IObserver
    {
       

        public void update(PlateObservable plateObservable)
        {
            Console.WriteLine("Sprzedawca :  " + plateObservable + " gotowy/wa. ");
        }

        public override string ToString()
        {
            return "Witam jestem Sprzedawcą :D";
        }
    }
}
