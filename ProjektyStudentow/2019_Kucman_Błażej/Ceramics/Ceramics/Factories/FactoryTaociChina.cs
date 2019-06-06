using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceramics.Enum;

namespace Ceramics.Factories
{
    public class FactoryTaociChina : ICeramicsFactory
    {

        public Shape shapePlate()
        {
            return Shape.Square;
        }
    }
}
