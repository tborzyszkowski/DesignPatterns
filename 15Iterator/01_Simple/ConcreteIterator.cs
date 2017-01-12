using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
    class ConcreteIterator : Iterator {
        private ConcreteAggregate _aggregate;
        private int _current = 0;

        // Constructor
        public ConcreteIterator(ConcreteAggregate aggregate) {
            this._aggregate = aggregate;
        }

        // Gets first iteration item
        public override object First() {
            return _aggregate[0];
        }

        // Gets next iteration item
        public override object Next() {
            object ret = null;
            if (_current < _aggregate.Count - 1) {
                ret = _aggregate[++_current];
            }

            return ret;
        }

        // Gets current iteration item
        public override object CurrentItem() {
            return _aggregate[_current];
        }

        // Gets whether iterations are complete
        public override bool IsDone() {
            return _current >= _aggregate.Count;
        }
    }
}
