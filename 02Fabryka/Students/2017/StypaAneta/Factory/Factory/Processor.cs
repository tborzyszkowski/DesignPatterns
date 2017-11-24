using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Processor
    {
        public virtual void process() { }
    }
    public class AMDProcessor : Processor
    {
        public override void process()
        {
            Console.WriteLine("Przygotowuję procesor AMD...");
        }

    }

    public class IntelProcessor : Processor
    {
        public override void process()
        {
            Console.WriteLine("Przygotowuję procesor Intel...");
        }
    }
}
