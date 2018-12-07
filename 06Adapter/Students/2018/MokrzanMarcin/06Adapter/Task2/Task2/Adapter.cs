using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Adapter : Adaptee
    {
        public Func<string, string> Request;

        public Adapter(Target target)
        {
            Request = target.PrepareDevice;
        }

        public Adapter(Adaptee adaptee)
        {
            Request = delegate (string model)
            {
                return "The " + Match(model) + " is ready to use.";
            };
        }
    }
}
