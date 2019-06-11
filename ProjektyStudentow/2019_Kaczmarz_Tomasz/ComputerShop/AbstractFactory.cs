using FactoryPattern.Model.CPU;
using FactoryPattern.Model.GPU;
using FactoryPattern.Model.Monitors;

namespace FactoryPattern.Factories
{
    public interface IAbstractFactory
    {
        CPU CreateCPU();
        GPU CreateGPU();
        Monitor CreateMonitor();
    }

    public class GamingPCFactory : IAbstractFactory
    {
        private static GamingPCFactory instance = null;
        private static readonly object padlock = new object();

        public static GamingPCFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GamingPCFactory();
                        }
                    }
                }

                return instance;
            }
        }

        private GamingPCFactory() { }

        public CPU CreateCPU()
        {
            return new Core_i7();
        }

        public GPU CreateGPU()
        {
            return new RTX2080();
        }

        public Monitor CreateMonitor()
        {
            return new Asus();
        }
    }

    public class OfficePCFactory : IAbstractFactory
    {
        private static OfficePCFactory instance = null;
        private static readonly object padlock = new object();

        public static OfficePCFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new OfficePCFactory();
                        }
                    }
                }

                return instance;
            }
        }

        private OfficePCFactory() { }

        public CPU CreateCPU()
        {
            return new Ryzen3();
        }

        public GPU CreateGPU()
        {
            return new RX580();
        }

        public Monitor CreateMonitor()
        {
            return new Acer();
        }
    }

    public class HomePCFactory : IAbstractFactory
    {
        private static HomePCFactory instance = null;
        private static readonly object padlock = new object();

        public static HomePCFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new HomePCFactory();
                        }
                    }
                }

                return instance;
            }
        }

        private HomePCFactory() { }

        public CPU CreateCPU()
        {
            return new Core_i5();
        }

        public GPU CreateGPU()
        {
            return new GTX1060();
        }

        public Monitor CreateMonitor()
        {
            return new AOC();
        }
    }
}
