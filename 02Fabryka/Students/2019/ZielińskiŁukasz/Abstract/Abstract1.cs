using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Abstract;

namespace Factory.Abstract
{
    public class Abstract1 : AbstractFactory
    {
        public Abstract1(Interface factory) : base(factory)
        {
        }
    }
}
