using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder
{
    public class CarBuilder
    {
        string Name { get; set; }
        string Engine { get; set; }
        Type TypeCar { get; set; }
        string Battery { get; set; }

        public CarBuilder CreateCar(string name)
        {
            this.Name = name;
            return this;
        }

        public CarBuilder InsertEngine(string engine)
        {
            this.Engine = engine;
            return this;
        }

        public CarBuilder InsertTypeCar(Type typeCar)
        {
            this.TypeCar = typeCar;
            return this;
        }

        public CarBuilder InsertBattery (string battery)
        {
            this.Battery = battery;
            return this;
        }

        public Car Build()
        {
            return new Car(Name, Engine, TypeCar, Battery);
        }

        public static implicit operator Car(CarBuilder tb)
        {
            return new Car(
                tb.Name,
                tb.Engine,
                tb.TypeCar,
                tb.Battery);
        }

    }
}
