using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03DeepPrototype {
    [Serializable()]
    // Helper class used to create a second level data structure
    class DeeperData {
        public string Data { get; set; }

        public DeeperData(string s) {
            Data = s;
        }
        public override string ToString() {
            return Data;
        }
    }
}
