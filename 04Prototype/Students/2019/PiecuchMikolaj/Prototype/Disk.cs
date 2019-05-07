using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Disk : AbstractCloneable<Disk>
    {
        public long Size { get; set; }
        public bool Rotational { get; set; }

        public override void HandleDeepClone(Disk cloned)
        {
            //nothing to deep copy
        }


    }
}
