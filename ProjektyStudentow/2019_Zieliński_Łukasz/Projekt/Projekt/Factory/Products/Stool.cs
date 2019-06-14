using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt;
using Projekt.Observer;

namespace Projekt.Factory.Products
{
    public class Stool : Product
    {
        CommandsObserver observerable;
        public Stool()
        {
            this.observerable = new CommandsObserver(observerable);
            color1 = TopColor.Gray;
            color2 = LegsPillowColor.White;
            name = "Stool";
            height = 40;
            width = 35;
            length = 35;
            cost = 29;
        }
        public override string ToString()
        {
            return (name + ": Colors: " + color1 + " and " + color2 + ", Size: " + height + "x" + width + "x" + length + ", Cost: " + cost);
        }
    }
}
