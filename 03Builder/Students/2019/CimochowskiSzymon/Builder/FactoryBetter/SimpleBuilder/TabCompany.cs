using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FactoryBetter.SimpleBuilder
{
    class TabCompany
    {
        public void Make(TabletBuilder tabletBuilder)
        {
            tabletBuilder.SetCountry();
            tabletBuilder.SetProdYear();
            tabletBuilder.SetPrice();
            tabletBuilder.SetOperatingSystem();
        }
    }
}
