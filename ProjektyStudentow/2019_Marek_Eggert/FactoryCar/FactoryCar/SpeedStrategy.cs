using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FactoryCar.Model;

namespace FactoryCar
{
    public class Kmh : SpeedStrategyInterface
    {
        public List<Car> Count(List<Car> c)
        {
            List<Car> tmp = new List<Car>();
            tmp = c;
            List<Car> tmp2 = new List<Car>();

            foreach (var item in tmp)
            {
                item.Speed = item.Speed / 1M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }
    public class Mph : SpeedStrategyInterface
    {
        public List<Car> Count(List<Car> c)
        {
            List<Car> tmp = new List<Car>();
            tmp = c;
            List<Car> tmp2 = new List<Car>();

            foreach (var item in tmp)
            {
                item.Speed = item.Speed * 0.62M;
                tmp2.Add(item);
            }
            return tmp2;
        }
    }

    
}
