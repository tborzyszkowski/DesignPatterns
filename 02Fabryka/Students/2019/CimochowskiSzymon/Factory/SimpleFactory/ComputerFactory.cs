using System;
using Factory.SimpleFactory.Notebooks;
using Factory.SimpleFactory.PCs;
using Factory.SimpleFactory.Tablets;

namespace Factory.SimpleFactory
{
    public class ComputerFactory
    {
        private static readonly Lazy<ComputerFactory> ComputerInstance =
            new Lazy<ComputerFactory>(() =>
                Activator.CreateInstance(typeof(ComputerFactory),
                    true) as ComputerFactory);


        public static ComputerFactory Instance
        {
            get { return ComputerInstance.Value; }
        }

        private ComputerFactory() { }

        public Notebook CreateNotebook(string notebook)
        {
            switch (notebook)
            {
                case "ASUS":
                    return new AsusNotebook();
                case "Dell":
                    return new DellNotebook();
                case "Lenovo":
                    return new LenovoNotebook();
                case "MSI":
                    return new MSINotebook();
                case "Acer":
                    return new AcerNotebook();
                default:
                    return null;
            }
        }

        public PC CreatePC(string pc)
        {
            switch (pc)
            {
                case "IBM":
                    return new IBMPC();
                case "Komputronik":
                    return new KomputronikPC();
                case "CoolerMaster":
                    return new CoolerMasterPC();
                case "HP":
                    return new HPPC();
                case "NZXT":
                    return new NZXTPC();
                default:
                    return null;
            }
        }

        public Tablet CreateTablet(string tablet)
        {
            switch (tablet)
            {
                case "Apple":
                    return new AppleTablet();
                case "Huawei":
                    return new HuaweiTablet();
                case "Lenovo":
                    return new LenovoTablet();
                case "Microsoft":
                    return new MicrosoftTablet();
                case "Samsung":
                    return new SamsungTablet();
                default:
                    return null;
            }
        }

    }
}