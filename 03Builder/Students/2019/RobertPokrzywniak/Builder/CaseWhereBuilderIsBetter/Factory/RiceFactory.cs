using System;

namespace Builder.CaseWhereBuilderIsBetter.Factory
{
    class RiceFactory : IRiceFactory
    {
        private static readonly Lazy<RiceFactory> _riceInstance = 
            new Lazy<RiceFactory>(() => Activator
                .CreateInstance(typeof(RiceFactory), true)
                as RiceFactory);
        private RiceFactory() { }

        public static RiceFactory Instance
        {
            get { return _riceInstance.Value; }
        }

        public Rice CreateRice(string type)
        {
            if (type == "halina")
                return new HalinaRice();

            return null;
        }
    }
}
