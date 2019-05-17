using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class VirtualMachineManager
    {
        private Dictionary<string, VirtualMachine> virtualMachinesPrototypes = new Dictionary<string, VirtualMachine>();

        public VirtualMachine this[string key]
        {
            get => virtualMachinesPrototypes[key].Clone() as VirtualMachine;
            set => virtualMachinesPrototypes.Add(key, value);
        }

        public VirtualMachineManager()
        {
            var testWin10 = new VirtualMachine
            {
                OS = "Win10",
                Name = "Device 1"
            };
            testWin10.Controllers = new List<StorageController>
            {
                new StorageController
                {
                    Name = "NVMe 2.0 controller",
                    Type = "NVMe",
                    Disks = new List<Disk>
                    {
                        new Disk
                        {
                            Rotational = false,
                            Size = 10000
                        }
                    }
                }
            };

            var testWin7 = new VirtualMachine
            {
                OS = "Win7",
                Name = "Device 2"
            };
            testWin10.Controllers = new List<StorageController>
            {
                new StorageController
                {
                    Name = "SATA controller",
                    Type = "SATA",
                    Disks = new List<Disk>
                    {
                        new Disk
                        {
                            Rotational = true,
                            Size = 10000
                        }
                    }
                }
            };

            virtualMachinesPrototypes.Add("Test-Win10", testWin10);
            virtualMachinesPrototypes.Add("Test-Win7", testWin7);
        }
    }
}
