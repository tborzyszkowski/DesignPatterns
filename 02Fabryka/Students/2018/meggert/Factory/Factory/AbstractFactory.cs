using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Factory
{
    public interface AbstractFactoryInterface
    {
        Engine inputEngine();
        Battery inputBattery();
    }

    public class AbstractFactory
    {
        private Engine engine = new Engine();
        private Battery battery = new Battery();
        private string firma;

        public AbstractFactory(string firma, AbstractFactoryInterface factory)
        {
            this.firma = firma;
            engine = factory.inputEngine();
            battery = factory.inputBattery();
            budowa();
        }
        private void budowa()
        {
            Console.WriteLine("Buduję samochod firmy: "+ firma);
            engine.eng();
            battery.battery();
            Console.WriteLine("Samochod firmy " + firma + " gotowy");
        }
    }
}
