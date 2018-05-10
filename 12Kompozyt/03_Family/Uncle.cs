using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite {
    /// <summary>
    /// Leaf class to act as Uncle.
    /// </summary>
    public class Uncle : IFamilyMember {
        public string Name { get; set; }

        public Uncle(string name) {
            Name = name;
        }
    }
}
