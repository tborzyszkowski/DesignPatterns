using Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public interface IFactory
    {
        Rice CreateRice();
        Groat CreateGroat();
        Pasta CreatePasta();
    }
}
