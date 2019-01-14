using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public class CSVAdaptee
    {       

        public string ToCSV(List<Car> p, bool toTxt = false)
        {
            var file = @"C:\Users\uzytkownik\Documents\pliczki\car.csv";

            var csv = new StringBuilder();

            foreach (var item in p)
            {
                var name = item.Name.ToString();
                var speed = item.Speed.ToString().Replace(',','.');
                var battery = item.Battery.ToString();
                var newLine = string.Format("name: {0}\n speed: {1}\n battery: {2}", name, speed, battery);
                csv.AppendLine(newLine);
            }

            if(!toTxt)
                File.AppendAllText(file, csv.ToString());

            return csv.ToString();
        }
    }
}
