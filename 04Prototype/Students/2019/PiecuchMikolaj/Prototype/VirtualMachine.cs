using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class VirtualMachine : AbstractCloneable<VirtualMachine>
    {
        public string OS { get; set; }
        public string Name { get; set; }
        public ICollection<StorageController> Controllers { get; set; }

        public override void HandleDeepClone(VirtualMachine cloned)
        {
            cloned.Controllers = Controllers.Select(x => x.Clone() as StorageController).ToList();
        }
    }
}
