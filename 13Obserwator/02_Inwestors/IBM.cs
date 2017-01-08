using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Inwestors {
    class IBM : Stock {
        // Constructor
        public IBM(string symbol, double price)
          : base(symbol, price) {
        }
    }
}
