using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Prototype;
using Projekt.Observer;

namespace Projekt.Factory.Products
{
    public class BigTable : Product
    {
        CommandsObserver observerable;
        public void ActivationObserver(InterfaceObserver observer)
        {
            observerable.ActivationObserver(observer);
        }
        public BigTable()
        {
            this.observerable = new CommandsObserver(observerable);

            Console.WriteLine("Tworzenie produktu.. \n");
            color1 = TopColor.Gray;
            color2 = LegsPillowColor.White;
            name = "Big Table";
            height = 76;
            width = 90;
            length = 300;
            cost = 449;
        }

        /*public override void Item(){
            Console.WriteLine("Stworzono produkt.. \n");
            notificationObserver();

        }*/
        public override string ToString()
        {
            return (name + ": Colors: " + color1 + "and " + color2 + ", Size: " + height + "x" + width + "x" + length + ", Cost: " + cost);
        }
        public void notificationObserver()
        {
            observerable.notificationObserver();
        }
        public void deactivationObserver(InterfaceObserver observer)
        {
            observerable.deactivationObserver(observer);
        }


    }
}
