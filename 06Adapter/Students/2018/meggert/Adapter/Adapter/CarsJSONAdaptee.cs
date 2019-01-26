using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Adapter
{
    public class CarsJSONAdaptee
    {
        public string GetCarsJSON()
        {
            List<Car> ListOfCars = new List<Car>();
            ListOfCars.Add(new Car
            {
                Firma = "HPI",
                Model = "Bullet",
                Predkosc = 60
            });

            ListOfCars.Add(new Car
            {
                Firma = "Traxas",
                Model = "EVO",
                Predkosc = 80
            });

            dynamic collectionCars = new
            {
                cars = ListOfCars
            };

            return JsonConvert.SerializeObject(collectionCars);
        }
    }
}
