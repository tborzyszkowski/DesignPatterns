using System;
using Factory.SimpleFactory;
using Factory.SimpleFactory.PCs;

namespace Factory.FactoryMethod
{
    public class PCFactory : Factory
    {
        private static readonly Lazy<PCFactory> PCInstance =
            new Lazy<PCFactory>(() =>
                Activator.CreateInstance(typeof(PCFactory),
                    true) as PCFactory);

        public static PCFactory Instance
        {
            get { return PCInstance.Value; }
        }

        private PCFactory() { }

        protected override IComputer Create(string name)
        {
            switch (name)
            {
                case "CoolerMaster":
                    return new CoolerMasterPC();
                case "HP":
                    return new HPPC();
                case "IBM":
                    return new IBMPC();
                case "Komputronik":
                    return new KomputronikPC();
                case "NZXT":
                    return new NZXTPC();
                default:
                    return null;
            }
        }
    }
}
