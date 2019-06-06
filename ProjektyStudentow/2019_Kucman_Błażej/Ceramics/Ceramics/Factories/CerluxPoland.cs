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
    public class CerluxPoland : CeramicsFactory
    {
        // Singleton ////////////
        private static Lazy<CerluxPoland> instanceWehicle = new Lazy<CerluxPoland>(CreateInstance);

        private static CerluxPoland CreateInstance()
        {
            return Activator.CreateInstance(typeof(CerluxPoland), true) as CerluxPoland;
        }
        public static CerluxPoland Instance
        {
            get { return instanceWehicle.Value; }
        }
        
        protected override Plate preparePlate(string plate)
        {
            Plate plateIn = null;
            ICeramicsFactory ceramicsFactory = new FactoryCerluxPoland();

            if(plate == "SmallPlate")
            {
                plateIn = new PlateDecorator(new SmallPLate(ceramicsFactory));
                Console.WriteLine(plateIn + "Zakład: " + this.GetType().Name);

            }
            else if( plate == "MediumPlate")
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
            else if(plate == "Vase")
            {
                plateIn = new VaseDecorator(new VaseAdapter(new Vase(ceramicsFactory)));
            }

            return plateIn;
        }
        
    }
}
