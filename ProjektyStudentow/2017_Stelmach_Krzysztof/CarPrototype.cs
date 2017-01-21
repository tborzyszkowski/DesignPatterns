using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{

    public abstract class CarPrototype
    {
        public abstract CarPrototype Clone();
    }

    public class Car : CarPrototype
    {
        private string _brand;
        private string _model;
        private string _color;
        private string _type;

        public Car(string brand, string model, string color, string type)
        {
            this._brand = brand;
            this._model = model;
            this._color = color;
            this._type = type;
        }

        public override CarPrototype Clone()
        {
            Console.WriteLine("Klonuje samochód marki:"
                + _brand + " model " + _model + " kolor: "
                + _color + " typ: " + _type);


            return this.MemberwiseClone() as CarPrototype;
        }

        public void CarDisplay()
        {
            Console.WriteLine("Samochód marki:"
                    + _brand + " model " + _model + " kolor: "
                    + _color + " typ: " + _type);
        }

        public void CarCreate()
        {
            Console.WriteLine("Zbudowano Samochod: "
                    + _brand + " model " + _model + " kolor: "
                    + _color + " typ: " + _type);
        }

        //Getters and setters
        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
    
}
