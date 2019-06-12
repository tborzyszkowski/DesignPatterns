using ComputerShop.Model;
using System;

namespace ComputerShop.Adapter
{
    public class ComputerFactory : PCPartsFactory, IPCFactory
    {
        private static ComputerFactory instance = null;
        private static readonly object padlock = new object();

        public static new ComputerFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ComputerFactory();
                        }
                    }
                }

                return instance;
            }
        }

        public Computer CreateComputer(ComputerType type)
        {
            switch (type)
            {
                case ComputerType.Gaming:
                    return new Computer(
                            CreateCPU(CPUType.Core_i7),
                            CreateGPU(GPUType.RTX2080),
                            CreateMonitor(MonitorType.Asus)
                        );
                case ComputerType.Home:
                    return new Computer(
                            CreateCPU(CPUType.Core_i5),
                            CreateGPU(GPUType.GTX1060),
                            CreateMonitor(MonitorType.Dell)
                        );
                case ComputerType.Office:
                    return new Computer(
                            CreateCPU(CPUType.Ryzen3),
                            CreateGPU(GPUType.RX580),
                            CreateMonitor(MonitorType.Acer)
                        );
                default:
                    Console.WriteLine("Nieznany typ komputera!");
                    return null;
            }
        }
    }
}
