using Factory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory.SimpleFactory
{
    public class CarbohydrateStore
    {
        private readonly SimpleCarbohydrateFactory _factory;
        public CarbohydrateStore()
        {
            _factory = SimpleCarbohydrateFactory.Instance;
        }
        public Rice OrderRice(string model)
        {
            Rice rice = _factory.CreateRice(model);
            if (rice == null)
                return null;

            return rice;
        }
        public Pasta OrderPasta(string model)
        {
            Pasta pasta = _factory.CreatePasta(model);
            if (pasta == null)
                return null;

            return pasta;
        }
        public Groat OrderGroat(string model)
        {
            Groat groat = _factory.CreateGroat(model);
            if (groat == null)
                return null;

            return groat;
        }
    }
}
