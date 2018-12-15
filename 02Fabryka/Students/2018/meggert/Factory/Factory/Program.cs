using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {

        private SimpleFactory fabryka = new SimpleFactory();

        public Program() { }
        public Program(SimpleFactory fabryka)
        {
            this.fabryka = fabryka;
        }

        public void Piecz(string pizza)
        {
            if (pizza != string.Empty)
            {
                var produkt = fabryka.createProduct(pizza);
                produkt.Print();
            }
           
        }


        static void Main(string[] args)
        {
       
            Console.WriteLine("PROSTA FABRYKA");
            Program p = new Program();
            p.Piecz("Pizza 1");
            p.Piecz("Pizza 2");

            Console.WriteLine("\n\nFABRYKA ABSTRAKCYJNA");
            AbstractFactory fabryka;
            fabryka = new AbstractFactory("HPI", new HpiFactory());
            fabryka = new AbstractFactory("Traxas", new TraxasFactory());

            Console.ReadKey();
        }
    }
}
