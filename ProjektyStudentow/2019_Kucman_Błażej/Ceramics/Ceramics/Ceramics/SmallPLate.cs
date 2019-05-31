using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceramics.Factories;
using Ceramics.Observable;

namespace Ceramics.Ceramics
{

    public class SmallPLate : Plate
    {
        ICeramicsFactory ceramicsFactory;
        Observerable observerable;

        public SmallPLate(ICeramicsFactory ceramicsFactory)
        {
            this.ceramicsFactory = ceramicsFactory;
            this.observerable = new Observerable(this);
        }

        public override void AttachObserver(IObserver observer)
        {
            observerable.AttachObserver(observer);
        }

        public override void Firing()
        {
            Console.WriteLine("Potter : Talerz mały wypalony");
            notifyObservers();
        }

        public override void notifyObservers()
        {
            observerable.notifyObservers();
        }

        public override void RemoveObserver(IObserver observer)
        {
            observerable.RemoveObserver(observer);
        }

        public override void Prepare()
        {
            shape = ceramicsFactory.shapePlate();
            name = "SmallPlate";
            size = 10;
            price = 4.50;
        }
        public override string ToString()
        {
            return (name + " kształt " + shape); 
        }
    }
}
