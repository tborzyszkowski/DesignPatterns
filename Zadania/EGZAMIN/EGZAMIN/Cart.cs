using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGZAMIN
{
    public class Cart
    {
        public int Cena { get; set; }
        public virtual void Wplyw(int wplyw)
        {

            foreach (Klienci kienci in klienci)
            {
                wplyw = wplyw + wplyw.;
            }
            Console.WriteLine("Wplywy: ");
            Console.WriteLine(wplyw);
        }
        public void Display()
        {
            Console.WriteLine("Wplyw srodkow");

            foreach (Wplyw wplyw in wplywy)
            {
                wplyw.Print();
            }
        }
        public String ToS()
        {
            String napis = "";
            foreach (Wplyw wplyw in wplywy)
            {
                napis = napis + wplyw.Str() + "\n";
            }
            return napis + "Suma wplywow" + Wplyw;
        }
    }
}