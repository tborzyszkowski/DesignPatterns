using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class Context {
        public Strategy strategy { get; set; }

        // Constructor
        public Context(Strategy strategy) {
            this.strategy = strategy;
        }

        public void ContextInterface() {
            strategy.AlgorithmInterface();
        }
    }
}
