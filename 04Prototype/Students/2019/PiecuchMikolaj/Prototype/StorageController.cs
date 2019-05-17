using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class StorageController : AbstractCloneable<StorageController>
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public ICollection<Disk> Disks { get; set; }

        public override void HandleDeepClone(StorageController cloned)
        {
            cloned.Disks = Disks.Select(x => x.Clone() as Disk).ToList();
        }
    }
}
