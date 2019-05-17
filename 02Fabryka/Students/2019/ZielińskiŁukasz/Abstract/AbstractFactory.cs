using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace Factory.Abstract
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
        public Cruiser CreateCruiser()
        {
            return MakeShips.CreateCruiser();
        }
        public CapitalShip CreateCapitalShip()
        {
            return MakeShips.CreateCapitalShip();
        }
    }
}
