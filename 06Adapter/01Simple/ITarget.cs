using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    // Required standard for requests
    interface ITarget {
        // Rough estimate required
        string Request(int i);
    }
}
