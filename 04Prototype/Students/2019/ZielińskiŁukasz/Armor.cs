using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    [Serializable()]
    public class Armor
    {
        public Armor(string crest, Kingdom nation)
        {
            this.Crest = crest;
            this.Nation = nation;
        }

        public string Crest { get; set; }
        public Kingdom Nation { get; set; }
    }
}
