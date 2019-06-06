using Ceramics.Ceramics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Factories
{
    public abstract class CeramicsFactory
    {
        protected abstract Plate preparePlate(String plate);
        public Plate PurchasePlate(String plate)
        {
            Plate plateP = preparePlate(plate);

            plateP.Prepare();
            plateP.Firing();
            

            return plateP;
        }
    }
}
