using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite {
    /// <summary>
    /// Leaf class to act as Aunt.
    /// </summary>
    public class Aunt : IFamilyMember {
        public string Name { get; set; }

        public Aunt(string name) {
            Name = name;
        }
    }
}
