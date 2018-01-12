using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class TxtAdaptee
    {
        string path = @"C:\myOutput.txt";

        public void ToTxt(List<Product> p)
        {
            CSVAdaptee csv = new CSVAdaptee();
            var txt = csv.ToCSV(p,true);

            File.AppendAllText(path, txt);
        }
    }
}
