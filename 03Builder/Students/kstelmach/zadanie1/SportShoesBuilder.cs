using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class SportShoesBuilder : ShoesBuilder
    {
        public SportShoesBuilder()
        {
            shoes = new Shoes("Sport");
        }

        public override void BuildSole()
        {
            shoes["sole"] = "sport";
        }

        public override void BuildLaces()
        {
            shoes["laces"] = "red";
        }

        public override void BuildMaterial()
        {
            shoes["material"] = "plastic";
        }
    }
}
