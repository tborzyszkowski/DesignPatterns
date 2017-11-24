using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatternsBuilder.Product;

namespace DesignPatternsBuilder.Builder
{
    internal interface IZooBuilder
    {
        Animal BuildHead();
        Animal BuildBody();
        Animal BuildHands();
        void BuildLegs();
    }
}