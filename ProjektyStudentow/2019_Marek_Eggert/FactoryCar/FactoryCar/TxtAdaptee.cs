using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public class TxtAdaptee
    {
        string path = @"C:\Users\uzytkownik\Documents\pliczki\car.txt";

        public void ToTxt(List<Car> c)
        {
            CSVAdaptee csv = new CSVAdaptee();
            var txt = csv.ToCSV(c,true);

            File.AppendAllText(path, txt);
        }
    }
}
