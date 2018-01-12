using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Model
{
    public enum Type
    {
        Warzywa,
        Owoce,
        Ryby,
        Mieso,
        Napoje,
        Slodycze,
        Inne
    }

    public enum Currency
    {
        Zloty,
        Euro,
        Dolar,
        Funt
    }
    
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ProductType { get; set; }
    }
}
