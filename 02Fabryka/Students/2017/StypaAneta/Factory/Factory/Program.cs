using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    class Program
    {

        private SimpleFactory factory = new SimpleFactory();

        public Program() { }
        public Program(SimpleFactory factory)
        {
            this.factory = factory;
        }

        public void doAction(String type)
        {
            if (type != String.Empty)
            {
                var product = factory.createProduct(type);
                product.Print();
            }
           
        }


        static void Main(string[] args)
        {
            //Simple factory
            Console.WriteLine("==========SIMPLE FACTORY=========");
            Program p = new Program();
            p.doAction("A");
            p.doAction("B");

            //Abstract factory
            Console.WriteLine("========ABSTRACT FACTORY=========");
            AbstractFactory af;
            af = new AbstractFactory("Intel", new IntelFactory());
            af = new AbstractFactory("AMD", new AMDFactory());

            Console.ReadKey();
        }
    }
}
