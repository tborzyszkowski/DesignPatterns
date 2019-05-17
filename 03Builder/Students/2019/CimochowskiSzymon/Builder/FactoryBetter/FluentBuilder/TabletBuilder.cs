using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    public abstract class TabletBuilder
    {
        protected Tablet _tablet;
        public Tablet Tablet => _tablet;
        public abstract Tablet CreateTablet();
        public abstract TabletBuilder SetCountry();
        public abstract TabletBuilder SetProdYear();
        public abstract TabletBuilder SetPrice();
        public abstract TabletBuilder SetOperatingSystem();

        public static implicit operator Tablet(TabletBuilder epicBuild)
        {
            return epicBuild.SetCountry()
                .SetProdYear()
                .SetPrice()
                .SetOperatingSystem()
                .Tablet;
        }
    }
}
