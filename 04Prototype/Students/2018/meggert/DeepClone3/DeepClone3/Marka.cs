using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protype2
{
    public class Marka
    {
        public string Nazwa { get; set; }
        public Samochod samochod { get; set; } 

        public Marka()
        {
            samochod = new Samochod();
        }
       
        public Marka DeepCopy()
        {
            Marka k = new Marka();
            k.samochod = new Samochod();
            k.samochod.Model = this.samochod.Model;
            k.samochod.Bateria = this.samochod.Bateria;
            k.samochod.silnik = new Silnik();
            k.samochod.silnik.Typ = this.samochod.silnik.Typ;

            k.Nazwa = this.Nazwa;

            return k;
        }


    }
}
