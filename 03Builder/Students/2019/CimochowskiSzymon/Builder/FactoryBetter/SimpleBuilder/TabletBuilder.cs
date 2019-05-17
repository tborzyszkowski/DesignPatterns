using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.SimpleBuilder.Computers;

namespace Builder.FactoryBetter.SimpleBuilder
{
    public abstract class TabletBuilder
    {
        protected Tablet _tablet;
        public Tablet Tablet => _tablet;
        public abstract void SetCountry();
        public abstract void SetProdYear();
        public abstract void SetPrice();
        public abstract void SetOperatingSystem();
    }
}
