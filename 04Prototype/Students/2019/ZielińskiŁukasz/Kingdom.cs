using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable()]
    public class Kingdom
    {
        public Kingdom(string size, Capital town)
        {
            this.Size = size;
            this.Town = town;
        }

        public string Size { get; set; }
        public Capital Town { get; set; }
    }
}//242 495
