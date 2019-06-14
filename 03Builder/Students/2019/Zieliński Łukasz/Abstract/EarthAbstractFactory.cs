using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Builder.Frigates;
using Builder.Abstract;


namespace Builder.Abstract
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

    }
}
