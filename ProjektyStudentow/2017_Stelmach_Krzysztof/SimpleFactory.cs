using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class SimpleFactory
    {
        CarManager carmanager = new CarManager();

        public void CreateTypes()
        {
            carmanager["miejski"] = new Car("audi", "A3", "red", "combi");
            carmanager["terenowy"] = new Car("toyota", "Rav4", "green", "hatchback");
            carmanager["sportowy"] = new Car("BMW", "Z1", "złoty", "hatchback");
        }


        public Car CreateCar(string type)
        {
            Car car = null; 
            if (type.Equals("miejski"))
            {
                car = carmanager["miejski"].Clone() as Car;
            }
            else if (type.Equals("terenowy"))
            {
                car = carmanager["terenowy"].Clone() as Car;
            }
            else if (type.Equals("sportowy"))
            {
                car = carmanager["sportowy"].Clone() as Car;
            }

            return car;
        }

    }
}
