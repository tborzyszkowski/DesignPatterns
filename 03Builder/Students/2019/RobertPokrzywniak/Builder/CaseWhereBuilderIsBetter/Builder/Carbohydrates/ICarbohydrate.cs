using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates
{
    public interface ICarbohydrate
    {
        string Producer { get; set; }
        string Name { get; set; }
        string Type { get; set; }

        void Boil();
        void Eat();
    }
}
