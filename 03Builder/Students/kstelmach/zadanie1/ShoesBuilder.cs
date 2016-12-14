using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadanie1
{
    abstract class ShoesBuilder
    {
        protected Shoes shoes;

        public Shoes Shoes
        {
            get { return shoes; }
        }

        public abstract void BuildSole();
        public abstract void BuildLaces();
        public abstract void BuildMaterial();

    }
}
