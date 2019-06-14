using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt;
using Projekt.Observer;

namespace Projekt.Factory.Products
{
    public class SmallTable : Product
    {
        CommandsObserver observerable;
        public SmallTable()
        {
            this.observerable = new CommandsObserver(observerable);
            Console.WriteLine("Tworzenie produktu.. \n");
            color1 = TopColor.Gray;
            color2 = LegsPillowColor.White;
            name = "Small Table";
            height = 76;
            width = 80;
            length = 160;
            cost = 319;
        }
        public override string ToString()
        {
            return (name+": Colors: "+color1+" and "+color2+", Size: "+height+"x"+width+"x"+length+", Cost: "+cost);
        }
    }
}
