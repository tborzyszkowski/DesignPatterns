using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public enum Type
    {
        Buggy,
        Onroad,
        Ofroad
    }

    public class Car
    {
        string Name { get; set; }
        string Engine { get; set; }
        Type TypeCar { get; set; }
        string Battery { get; set; }

        public Car(string name, string engine, Type typeCar, string battery)
        {
            this.Name = name;
            this.Engine = engine;
            this.TypeCar = typeCar;
            this.Battery = battery;
        }

        public void Show()
        {
            Console.WriteLine("Firma: " + Name);
            Console.WriteLine("Silnik: " + Engine);
            Console.WriteLine("Typ: " + TypeCar); 
            Console.WriteLine("Bateria: " + Battery);
            Console.WriteLine("\n");
        }
    }
}
