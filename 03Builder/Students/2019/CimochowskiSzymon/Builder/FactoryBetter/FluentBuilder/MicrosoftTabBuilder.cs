using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.FactoryBetter.FluentBuilder.Computers;

namespace Builder.FactoryBetter.FluentBuilder
{
    class MicrosoftTabBuilder : TabletBuilder
    {
        public MicrosoftTabBuilder()
        {
            _tablet = CreateTablet();
        }

        public Tablet GetTablet()
        {
            return _tablet;
        }

        public override Tablet CreateTablet()
        {
            return new Tablet {Manufacturer = "Microsoft", Model = "Surface Pro 4"};
        }

        public override TabletBuilder SetCountry()
        {
            _tablet.Country = "USA";
            return this;
        }

        public override TabletBuilder SetProdYear()
        {
            _tablet.ProdYear = 2019;
            return this;
        }

        public override TabletBuilder SetPrice()
        {
            _tablet.Price = 3099;
            return this;
        }

        public override TabletBuilder SetOperatingSystem()
        {
            _tablet.OperatingSystem = "Windows 10";
            return this;
        }
    }
}
