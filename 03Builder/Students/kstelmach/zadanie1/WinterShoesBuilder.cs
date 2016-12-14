using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class WinterShoesBuilder : ShoesBuilder
    {
        public WinterShoesBuilder()
        {
            shoes = new Shoes("Winter");
        }

        public override void BuildSole()
        {
            shoes["sole"] = "winter";
        }

        public override void BuildLaces()
        {
            shoes["laces"] = "black";
        }

        public override void BuildMaterial()
        {
            shoes["material"] = "water proof";
        }
    }
}
