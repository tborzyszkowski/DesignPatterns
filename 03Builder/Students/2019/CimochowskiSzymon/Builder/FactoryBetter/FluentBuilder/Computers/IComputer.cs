using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder.FactoryBetter.FluentBuilder.Computers
{
    public interface IComputer
    {
        string Manufacturer { get; set; }
        string Model { get; set; }
        string Country { get; set; }
        int ProdYear { get; set; }
        int Price { get; set; }

        void setUp();
        void build();
    }
}
