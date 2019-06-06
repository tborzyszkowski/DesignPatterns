using Ceramics.Ceramics;
using Ceramics.Decorator;
using Ceramics.Factories;
using Ceramics.Iterator;
using Ceramics.Observable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics
{
    class Program
    {
        static void Main(string[] args)
        {
            CerluxPoland cerluxPoland = CerluxPoland.Instance;
            TaociChina taociChina = TaociChina.Instance;
            string[] plates = new string[] { "SmallPlate", "MediumPlate", "BigPlate", "LuxuryPlate" };

            Order orderOfPlatesCerlux = new Order();

            //Plate plate = cerluxPoland.PurchasePlate("SmallPlate");
            foreach (string p in plates)
            {
                orderOfPlatesCerlux.addItem(cerluxPoland.PurchasePlate(p));
            }

            //Console.WriteLine("Do zrobienia");

            Order orderPlatesTaoci = new Order();
            foreach (string p in plates)
            {
                orderPlatesTaoci.addItem(taociChina.PurchasePlate(p));
            }

            orderPlatesTaoci.addItem(taociChina.PurchasePlate("Vase"));


            Seller potter = new Seller();

            Console.WriteLine("Garncarz skończył pracę nad zamówieniem");
            orderOfPlatesCerlux.AttachObserver(potter);

            firing(orderOfPlatesCerlux);

            Console.WriteLine("Zrobiona ilość tależy " + PlateDecorator.NumberOfPlate + " za cenę " + PlateDecorator.PriceOfPlates1);

            Console.WriteLine("Zrobiona ilość waz " + VaseDecorator.NumberOfPlate + " za cenę " + VaseDecorator.PriceOfPlates1);
            /////////////////////////////////////////////////////////////////
            orderPlatesTaoci.AttachObserver(potter);

            firing(orderPlatesTaoci);


            Console.WriteLine("Zrobiona ilość tależy " + PlateDecorator.NumberOfPlate + " za cenę " + PlateDecorator.PriceOfPlates1);

            Console.WriteLine("Zrobiona ilość waz " + VaseDecorator.NumberOfPlate + " za cenę " + VaseDecorator.PriceOfPlates1);

            orderOfPlatesCerlux.RemoveObserver(potter);
            //firing(orderOfPlatesCerlux);


            CerluxPoland cerluxPoland1 = CerluxPoland.Instance;

            var a = (PlateDecorator)cerluxPoland1.PurchasePlate("SmallPlate");
            var x = a.Plate;

            //Assert.IsInstanceOf(typeof(SmallPLate), x.GetType());

            Console.WriteLine(x.GetType()+" " + typeof(SmallPLate));
            // Assert.

            IMyData<int> array = new MyData<int>();
            array.AddItem(5);
            array.AddItem(6);
            array.AddItem(8);

            array.Find(6);
        }

        static void firing(Plate plate)
        {
            plate.Firing();
        }

    }
}
