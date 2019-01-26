using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public interface IFactory {
        string sqlCommand(Car p);
     
    }


    public class ChangePriceFactory : IFactory
    {
        public string sqlCommand(Car p)
        {
            p.Speed = p.Speed * 1.8M;
            return @"INSERT INTO dbo.Car(Name,Speed,Battery) 
                   Values('" + p.Name + "'," + p.Speed.ToString().Replace(',', '.') + ",'" + p.Battery + "')";
        }
    }

    public class NoChangePriceFactory : IFactory
    {
        public string sqlCommand(Car p)
        {
            return @"INSERT INTO dbo.Car(Name,Speed,Battery) 
                   Values('" + p.Name + "'," + p.Speed.ToString().Replace(',','.') + ",'" + p.Battery + "')";
        }
    }
}
