using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public class CSVAdaptee
    {       

        public string ToCSV(List<Product> p, bool toTxt = false)
        {
            var file = @"C:\myOutput.csv";

            var csv = new StringBuilder();

            foreach (var item in p)
            {
                var name = item.Name.ToString();
                var price = item.Price.ToString().Replace(',','.');
                var type = item.ProductType.ToString();
                var newLine = string.Format("{0},{1},{2}", name, price, type);
                csv.AppendLine(newLine);
            }

            if(!toTxt)
                File.AppendAllText(file, csv.ToString());

            return csv.ToString();
        }
    }
}
