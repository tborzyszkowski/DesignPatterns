using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    class Shop
    {
        public void Construct(ShoesBuilder shoesBuilder)
        {
            shoesBuilder.BuildLaces();
            shoesBuilder.BuildMaterial();
            shoesBuilder.BuildSole();
        }
    }
}
