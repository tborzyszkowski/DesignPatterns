using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepClone3
{
    public class Przedsiebiorstwo
    {
        public string Nazwa { get; set; }
        public string Miejscowosc { get; set; }
        public Pracownik pracownik { get; set; } 

        public Przedsiebiorstwo()
        {
            pracownik = new Pracownik();
        }
       
        public Przedsiebiorstwo DeepCopy()
        {
            Przedsiebiorstwo klon = new Przedsiebiorstwo();
            klon.pracownik = new Pracownik();
            klon.pracownik.Imie = this.pracownik.Imie;
            klon.pracownik.Nazwisko = this.pracownik.Nazwisko;
            klon.pracownik.hobby = new Hobby();
            klon.pracownik.hobby.Nazwa = this.pracownik.hobby.Nazwa;

            klon.Nazwa = this.Nazwa;
            klon.Miejscowosc = this.Miejscowosc;

            return klon;
        }


    }
}
