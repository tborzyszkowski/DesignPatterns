using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public class Battery
    {
        public virtual void battery() { }
    }
    public class S3 : Battery
    {
        public override void battery()
        {
            Console.WriteLine("Bateria S3");
        }
    }
    public class S2 : Battery
    {
        public override void battery()
        {
            Console.WriteLine("Bateria S2");
        }
    }

}
