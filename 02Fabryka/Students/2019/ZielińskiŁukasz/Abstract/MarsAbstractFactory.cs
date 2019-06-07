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
    public class MarsAbstractFactory : Interface
    {
        private static readonly Lazy<MarsAbstractFactory> MethodInstance =
            new Lazy<MarsAbstractFactory>(() => Activator.CreateInstance(typeof(MarsAbstractFactory), nonPublic: true) as MarsAbstractFactory);
        public static MarsAbstractFactory Instance
        {
            get { return MethodInstance.Value; }
        }

        public Frigate CreateFrigate()
        {
            return new Ravastra();
        }
        public Cruiser CreateCruiser()
        {
            return new Stilakus();
        }
        public CapitalShip CreateCapitalShip()
        {
            return new Vulkoras();
        }

    }
}
