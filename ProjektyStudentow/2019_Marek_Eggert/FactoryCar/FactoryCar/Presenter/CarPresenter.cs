using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar.Presenter
{
    public class CarPresenter
    {
        public CarDocument document = new CarDocument();
        
        public void OnInit()
        {
            document.CarList = new List<Car>();
            document.CarList = CarSingleton.Instance.GetCar();
        }

        public List<Car> AddNewProduct(Car product)
        {
            CarSingleton.Instance.AddProduct(product);
           
            return CarSingleton.Instance.GetCar();
        }

        public List<Car> Calulate(string c)
        {
            var tmp = new List<Car>();
            tmp = CarSingleton.Instance.GetCar();

            ContextStrategy context = null;
            switch (c) {
                case "Kmh":
                  context = new ContextStrategy(new Kmh());
                  break;
                case "Mph":
                    context = new ContextStrategy(new Mph());
                    break;
                default:
                   break;
            }
            return context.Calculate(tmp);
        }

        public void WriteToCSV()
        {
            CSVAdaptee csv = new CSVAdaptee();
            csv.ToCSV(document.CarList);
        }

        public void WriteToTxt()
        {
            TxtAdaptee txt = new TxtAdaptee();
            txt.ToTxt(document.CarList);
        }

    }

    public class CarDocument
    {
        public List<Car> CarList { get; set; }
    }
}
