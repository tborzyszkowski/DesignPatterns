using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGZAMIN
{
    class Zamowienie
    {
        string nazwa, data, miasto;
        public int cena;

        public int GetCena()
        {
            return cena;
        }

        public override void Akceptuj(Wizytator wizytator)
        {
            Wizytator.Konkretnywizytator(this);
        }
        public void OperationA()
        {
        }
    }
}
