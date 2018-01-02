using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budowniczy
{
    abstract class BudowniczyStatku
    {
        protected Statek statek;

        Statek Statek
        {
            get { return statek; }
        }

        public abstract BudowniczyStatku BudujKadlub();
        public abstract BudowniczyStatku BudujSilnik();
        public abstract BudowniczyStatku BudujSter();
        public abstract BudowniczyStatku BudujWyposazenie();

        // implicit - operator konwersji jawnej (niejawnej też)
        public static implicit operator Statek(BudowniczyStatku bs)
        {
            return bs.BudujKadlub()
                .BudujSilnik()
                .BudujSter()
                .BudujWyposazenie()
                .Statek;
        }
    }
}
