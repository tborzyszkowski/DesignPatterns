using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepClone3
{
    public class Pracownik
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public Hobby hobby;

        public Pracownik()
        {
            hobby = new Hobby();
        }

        public Pracownik DeepClone()
        {
            Pracownik klon = new Pracownik();
            klon.hobby = new Hobby();
            klon.hobby.Nazwa = this.hobby.Nazwa;

            klon.Nazwisko = this.Nazwisko;
            klon.Imie = this.Imie;

            return klon;

        }
    }
}
