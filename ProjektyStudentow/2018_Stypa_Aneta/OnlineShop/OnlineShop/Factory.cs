using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public interface IFactory {
        string sqlCommand(Product p);
     
    }


    public class ChangePriceFactory : IFactory
    {
        public string sqlCommand(Product p)
        {
            p.Price = p.Price * 1.15M;
            return @"INSERT INTO dbo.Product(Name,Price,ProductType) 
                   Values('" + p.Name + "'," + p.Price.ToString().Replace(',', '.') + ",'" + p.ProductType + "')";
        }
    }

    public class NoChangePriceFactory : IFactory
    {
        public string sqlCommand(Product p)
        {
            return @"INSERT INTO dbo.Product(Name,Price,ProductType) 
                   Values('" + p.Name + "'," + p.Price.ToString().Replace(',','.') + ",'" + p.ProductType + "')";
        }
    }
}
