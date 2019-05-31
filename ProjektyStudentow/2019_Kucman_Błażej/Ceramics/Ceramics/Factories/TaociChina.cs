using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceramics.Adapter;
using Ceramics.Ceramics;
using Ceramics.Decorator;

namespace Ceramics.Factories
{
    public class TaociChina : CeramicsFactory
    {
        // Singleton ////////////
        private static Lazy<TaociChina> instanceWehicle = new Lazy<TaociChina>(CreateInstance);

        private static TaociChina CreateInstance()
        {
            return Activator.CreateInstance(typeof(TaociChina), true) as TaociChina;
        }
        public static TaociChina Instance
        {
            get { return instanceWehicle.Value; }
        }

        //protected override Plate preparePlate(string plate)
        //{
        //    Plate plateIn = null;
        //    ICeramicsFactory ceramicsFactory = new FactoryTaociChina();

        //    return plateIn;
        //}

        protected override Plate preparePlate(string plate)
        {
            Plate plateIn = null;
            ICeramicsFactory ceramicsFactory = new FactoryTaociChina();

            if (plate == "SmallPlate")
            {
                plateIn = new PlateDecorator(new SmallPLate(ceramicsFactory));
                Console.WriteLine(plateIn + "Zakład:" + this.GetType().Name);

            }
            else if (plate == "MediumPlate")
            {
                plateIn = new PlateDecorator(new MediumPlate(ceramicsFactory));
                Console.WriteLine(plateIn + "Zakład:" + this.GetType().Name);
            }
            else if (plate == "BigPlate")
            {
                plateIn = new PlateDecorator(new BigPlate(ceramicsFactory));
                Console.WriteLine(plateIn + "Zakład:" + this.GetType().Name);
            }
            else if (plate == "LuxuryPlate")
            {
                plateIn = new PlateDecorator(new LuxuryPlate(ceramicsFactory));
                Console.WriteLine(plateIn + "Zakład:" + this.GetType().Name);
            }
            else if (plate == "Vase")
            {
                plateIn = new VaseDecorator(new VaseAdapter(new Vase(ceramicsFactory)));
                Console.WriteLine(plateIn + "Zakład:" + this.GetType().Name);
            }

            return plateIn;
        }

    }
}
