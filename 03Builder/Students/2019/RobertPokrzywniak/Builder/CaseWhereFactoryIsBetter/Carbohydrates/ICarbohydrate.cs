using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereFactoryIsBetter.Carbohydrates
{
    public interface ICarbohydrate
    {
        string Producer { get; set; }
        string Name { get; set; }
        string Type { get; set; }
        int Weight { get; set; }
        double Price { get; set; }

        void Boil();
        void Eat();
    }
}
