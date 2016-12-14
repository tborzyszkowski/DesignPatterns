using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    public class SimpleCarFactory
    {
        public Car CreateCar(string brand)
        {

            Car car = null;

            if (brand.Equals("bmw"))
            {
                car = new BmwCar();
            }
            else if (brand.Equals("audi"))
            {
                car = new AudiCar();
            }
            else if (brand.Equals("mazda"))
            {
                car = new MazdaCar();
            }

            return car;
        }
    }
}
