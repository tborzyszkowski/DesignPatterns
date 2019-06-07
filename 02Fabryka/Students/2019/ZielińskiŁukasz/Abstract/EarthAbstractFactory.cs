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
    public class EarthAbstractFactory : Interface
    {
        private static readonly Lazy<EarthAbstractFactory> MethodInstance =
            new Lazy<EarthAbstractFactory>(() => Activator.CreateInstance(typeof(EarthAbstractFactory), nonPublic: true) as EarthAbstractFactory);
        public static EarthAbstractFactory Instance
        {
            get { return MethodInstance.Value; }
        }
        public Frigate CreateFrigate()
        {
            return new Cobalt();
        }
        public Cruiser CreateCruiser()
        {
            return new Kodiak();
        }
        public CapitalShip CreateCapitalShip()
        {
            return new Kol();
        }
    }
}
