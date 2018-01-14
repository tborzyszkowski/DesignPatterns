using OnlineShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop
{
    public interface CalulateStrategyInterface
    {
       List<Product> Count(List<Product> p);
    }
}
