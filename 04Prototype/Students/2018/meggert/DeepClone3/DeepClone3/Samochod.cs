using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Protype2
{
    public class Samochod
    {
        public string Model { get; set; }
        public string Bateria { get; set; }
        public Silnik silnik;

        public Samochod()
        {
            silnik = new Silnik();
        }

        public Samochod DeepClone()
        {
            Samochod k = new Samochod();
            k.silnik = new Silnik();
            k.silnik.Typ = this.silnik.Typ;

            k.Bateria = this.Bateria;
            k.Model = this.Model;

            return k;

        }
    }
}
