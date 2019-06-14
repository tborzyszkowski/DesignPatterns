using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projekt.Factory;

namespace Projekt.Factory
{
    public class Factory1 : AFactory
    {
        public Factory1(InterfaceFactory factory) : base(factory)
        {
        }
    }
}
