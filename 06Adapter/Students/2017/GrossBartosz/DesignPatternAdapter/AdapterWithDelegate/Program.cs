using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterWithDelegate
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Target target0 = new Target();
            target0.Request();

            Target target = new Adapter();
            target.Request();

            Target target2 = new Adapter(() =>
            {
                Console.WriteLine("New method");
            } );
            target2.Request();
        }
    }

    class Target
    {
        public virtual void Request()
        {
            Console.WriteLine("Called Target Request()");
        }
    }

    internal class Adapter : Target
    {
        private Adaptee _adaptee = new Adaptee();

        public Action newMethod;

        public Adapter(Action newAdapterMethod)
        {
            newMethod = newAdapterMethod;
        }

        public Adapter()
        {
        }

        public override void Request()
        {
            try
            {
                if (newMethod.GetInvocationList().Length > 0)
                {
                    newMethod();
                    return;
                }
            }
            catch
            {
                // ignored
            }

            _adaptee.SpecificRequest();
        }
    }

    internal class Adaptee
    {
        public void SpecificRequest()
        {
            Console.WriteLine("Called SpecificRequest()");
        }
    }

}
