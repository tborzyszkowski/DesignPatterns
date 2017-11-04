using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    public interface AbstractFactoryInterface
    {
        Processor createProcessor();
        Disc createDisc();
    }

    //complete computer
    public class AbstractFactory
    {
        private Processor processor = new Processor();
        private Disc disc = new Disc();
        private String type;

        public AbstractFactory(String type,AbstractFactoryInterface factory)
        {
            this.type = type;
            processor = factory.createProcessor();
            disc = factory.createDisc();
            process();
        }
        private void process()
        {
            Console.WriteLine("Rozpoczynam składanie komputera z procesorem: "+type);
            processor.process();
            disc.process();
            Console.WriteLine("Zakończono składanie komputera z procesorem: " + type);
        }
    }
}
