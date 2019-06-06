using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceramics.Factories;
using Ceramics.Observable;

namespace Ceramics.Ceramics
{
    public class MediumPlate : Plate
    {
        ICeramicsFactory ceramicsFactory;
        Observerable observerable;

        public MediumPlate(ICeramicsFactory ceramicsFactory)
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
            Console.WriteLine("Potter : Talerz średni wypalony");
            notifyObservers();
        }

        public override void notifyObservers()
        {
            observerable.notifyObservers();
        }

        public override void Prepare()
        {
            shape = ceramicsFactory.shapePlate();
            name = "MediumPlate";
            size = 15;
            price = 8.50;
        }
        public override string ToString()
        {
            return (name + " kształt " + shape);
        }

        public override void RemoveObserver(IObserver observer)
        {
            observerable.RemoveObserver(observer);
        }
    }
}
