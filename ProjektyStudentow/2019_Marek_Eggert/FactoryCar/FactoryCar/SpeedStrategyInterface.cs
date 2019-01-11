using FactoryCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryCar
{
    public interface SpeedStrategyInterface
    {
       List<Car> Count(List<Car> p);
    }
}
