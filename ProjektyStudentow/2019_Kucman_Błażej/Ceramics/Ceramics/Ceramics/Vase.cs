using Ceramics.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Ceramics
{
    public class Vase
    {
        ICeramicsFactory ceramicsFactory;
        public double price = 160;
        public Vase(ICeramicsFactory ceramicsFactory)
        {
            this.ceramicsFactory = ceramicsFactory;
        }
        void Prepare()
        {
            price = 160;
        }
        public void HandMadeFormation()
        {
            Console.WriteLine("Waza uformowana i wypieczona pod obserwacją mistrza. ");
        }
        
        public override string ToString()
        {
            return "Waza ręcznie formowana i wypiekana pod obserwacją mistrza. ";
        }
    }
}
