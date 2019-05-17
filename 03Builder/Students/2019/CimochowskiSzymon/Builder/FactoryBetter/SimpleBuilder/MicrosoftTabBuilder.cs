using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.SimpleBuilder.Computers;

namespace Builder.FactoryBetter.SimpleBuilder
{
    class MicrosoftTabBuilder : TabletBuilder
    {
        public MicrosoftTabBuilder()
        {
            _tablet = new Tablet {Manufacturer = "Microsoft", Model = "Surface Pro 4"};
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
            _tablet.Price = 3099;
        }

        public override void SetOperatingSystem()
        {
            _tablet.OperatingSystem = "Windows 10";
        }
    }
}
