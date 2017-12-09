using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mewa
{
    public class Statek : IStatek
    {
        int prędkość = 0;

        public int Prędkość
        {
            get { return prędkość; }
        }

        public virtual void ZwiększObroty()
        {
            prędkość += 10;
            Console.WriteLine("Silniki statku zwiększają obroty do: " + prędkość + " węzłów");
        }
    }
}
