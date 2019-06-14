using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt;
using Projekt.Observer;
using Projekt.Factory.Products;

namespace Projekt.Factory.Products
{
    public class Chair : Product
    {
        CommandsObserver observerable;
        public void ActivationObserver(InterfaceObserver observer)
        {
            observerable.ActivationObserver(observer);
        }
        public Chair()
        {
            this.observerable = new CommandsObserver(observerable);

            Console.WriteLine("Tworzenie produktu.. \n");
            color1 = TopColor.Gray;
            color2 = LegsPillowColor.White;
            name = "Chair";
            height = 45;
            width = 44;
            length = 45;
            cost = 49;
        }
        public override string ToString()
        {
            return (name + ": Colors: " + color1 + " and " + color2 + ", Size: " + height + "x" + width + "x" + length + ", Cost: " + cost);
        }

        
    }
}
