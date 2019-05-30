using Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.AbstractFactory
{
    public class Store
    {
        private readonly IFactory _factory;

        public Store(IFactory factory)
        {
            _factory = factory;
        }

        public Rice BuildRice()
        {
            return _factory.CreateRice();
        }

        public Groat BuildGroat()
        {
            return _factory.CreateGroat();
        }

        public Pasta BuildPasta()
        {
            return _factory.CreatePasta();
        }
    }
}
