using Ceramics.Ceramics;
using Ceramics.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Decorator
{
    public class VaseDecorator : Plate
    {
        Plate plate;
        static int numberOfPlate;
        static double PriceOfPlates;

        public VaseDecorator(Plate plate)
        {
            this.plate = plate;
        }

        public static int NumberOfPlate { get => numberOfPlate; set => numberOfPlate = value; }
        public static double PriceOfPlates1 { get => PriceOfPlates; set => PriceOfPlates = value; }

        public override void AttachObserver(IObserver observer)
        {
            plate.AttachObserver(observer);
        }
        public override void Firing()
        {
            plate.Firing();
            numberOfPlate += 1;
            PriceOfPlates += plate.price;

        }

        public override void notifyObservers()
        {
            plate.notifyObservers();
        }

        public override void Prepare()
        {
            plate.Prepare();
        }

        public override void RemoveObserver(IObserver observer)
        {
            plate.RemoveObserver(observer);
        }

        public override string ToString()
        {
            return plate.ToString();
        }
    }
}
