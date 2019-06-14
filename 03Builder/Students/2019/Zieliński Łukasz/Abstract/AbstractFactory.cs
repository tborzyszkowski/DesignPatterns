using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Abstract;
using Builder.Frigates;


namespace Builder.Abstract
{
    public abstract class AbstractFactory
    {
        private readonly Interface MakeShips;

        protected AbstractFactory(Interface ShipFactories)
        {
            this.MakeShips = ShipFactories;
        }
        public Frigate CreateFrigate()
        {
            return MakeShips.CreateFrigate();
        }
    }
}
