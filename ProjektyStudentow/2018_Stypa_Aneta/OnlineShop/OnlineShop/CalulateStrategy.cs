using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Model;

namespace OnlineShop
{
    public class Zloty : CalulateStrategyInterface
    {
        public List<Product> Count(List<Product> p)
        {
            List<Product> tmp = new List<Product>();
            tmp = p;
            List<Product> tmp2 = new List<Product>();

            foreach (var item in tmp)
            {
                item.Price = item.Price / 1M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }
    public class Dolar : CalulateStrategyInterface
    {
        public List<Product> Count(List<Product> p)
        {
            List<Product> tmp = new List<Product>();
            tmp = p;
            List<Product> tmp2 = new List<Product>();

            foreach (var item in tmp)
            {
                item.Price = item.Price / 3.46M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }

    public class Euro : CalulateStrategyInterface
    {
        public List<Product> Count(List<Product> p)
        {
            List<Product> tmp = new List<Product>();
            tmp = p;
            List<Product> tmp2 = new List<Product>();
            foreach (var item in tmp)            {
                item.Price = item.Price / 4.16M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }

    public class Funt : CalulateStrategyInterface
    {
        public List<Product> Count(List<Product> p)
        {
            List<Product> tmp = new List<Product>();
            tmp = p;
            List<Product> tmp2 = new List<Product>();

            foreach (var item in tmp)
            {
                item.Price = item.Price / 4.70M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }
}
