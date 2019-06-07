using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory.Frigates;
using Factory.CapitalShips;
using Factory.Cruisers;

namespace Factory.Abstract
{
    public interface Interface
    {
        Frigate CreateFrigate();
        Cruiser CreateCruiser();
        CapitalShip CreateCapitalShip();
    }
}
