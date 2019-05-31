using Ceramics.Enum;
using Ceramics.Observable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceramics.Ceramics
{
    public abstract class Plate : PlateObservable
    {
        public Shape shape;
        public string name;
        public int size;
        public double price;
        public abstract void Prepare();
        // wypalanie
        public abstract void Firing();
    }
}
