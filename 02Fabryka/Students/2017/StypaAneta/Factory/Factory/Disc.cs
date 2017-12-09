using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Disc
    {
        public virtual void process() { }
    }
    public class SSD : Disc
    {
        public override void process()
        {
            Console.WriteLine("Przygodowuję dysk SSD...");
        }
    }
    public class HDD : Disc
    {
        public override void process()
        {
            Console.WriteLine("Przygotowuję dysk HDD...");
        }
    }

}
