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
    public class MoonAbstractFactory : Interface
    {
        private static readonly Lazy<MoonAbstractFactory> MethodInstance =
            new Lazy<MoonAbstractFactory>(() => Activator.CreateInstance(typeof(MoonAbstractFactory), nonPublic: true) as MoonAbstractFactory);
        public static MoonAbstractFactory Instance
        {
            get { return MethodInstance.Value; }
        }
        public Frigate CreateFrigate()
        {
            return new Illuminator();
        }
        public Cruiser CreateCruiser()
        {
            return new Destra();
        }
        public CapitalShip CreateCapitalShip()
        {
            return new Rapture();
        }
    }
}
