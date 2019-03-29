using System;

namespace Builder.BuilderOverFactory.AbstractFactory
{
    public class DodgeFactory : IDodgeFactory
    {
        //Singleton
        private DodgeFactory() { }

        private static readonly Lazy<DodgeFactory> _instance =
            new Lazy<DodgeFactory>(() => Activator.CreateInstance(typeof(DodgeFactory), nonPublic: true) as DodgeFactory);

        public static DodgeFactory Instance
        {
            get { return _instance.Value; }
        }
        //

        public Dodge CreateDodge(int id = 0)
        {
            if (id == 0)
                return new DodgeChallenger();
            else if (id == 1)
                return new DodgeViper();
            else if (id == 2)
                return new DodgeCharger();
            return null;
        }
    }
}
