using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.SimpleBuilder.Computers;

namespace Builder.FactoryBetter.SimpleBuilder
{
    class AppleTabBuilder : TabletBuilder
    {
        public AppleTabBuilder()
        {
            _tablet = new Tablet {Manufacturer = "Apple", Model = "iPad Pro 4"};
        }

        public override void SetCountry()
        {
            _tablet.Country = "USA";
        }

        public override void SetProdYear()
        {
            _tablet.ProdYear = 2019;
        }

        public override void SetPrice()
        {
            _tablet.Price = 1899;
        }

        public override void SetOperatingSystem()
        {
            _tablet.OperatingSystem = "iOS 12";
        }
    }
}
