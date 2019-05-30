using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.CaseWhereBuilderIsBetter.Builder.Carbohydrates
{
    public class Pasta : ICarbohydrate
    {
        public string Producer { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public void Boil()
        {
            Console.WriteLine($"Boiling {Producer} Product.");
        }
        public void Eat()
        {
            Console.WriteLine($"Eating {Type}, tasty.");
        }
    }
}
