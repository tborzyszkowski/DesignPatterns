using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceramics.Factories;
using Ceramics.Observable;

namespace Ceramics.Ceramics
{
    public class LuxuryPlate : Plate
    {
        ICeramicsFactory ceramicsFactory;
        Observerable observerable;

        public LuxuryPlate(ICeramicsFactory ceramicsFactory)
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
            Console.WriteLine("Potter : Talerz luksusowy wypalony");
            notifyObservers();
        }

        public override void notifyObservers()
        {
            observerable.notifyObservers();
        }

        public override void Prepare()
        {
            shape = ceramicsFactory.shapePlate();
            name = "LuxuryWithGoldPlate";
            size = 15;
            price = 120;
        }
        public override string ToString()
        {
            return (name + " kształt " + shape + " rozmiar " + size);
        }

        public override void RemoveObserver(IObserver observer)
        {
            observerable.RemoveObserver(observer);
        }
    }
}
