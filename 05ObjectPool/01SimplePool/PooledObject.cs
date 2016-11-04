using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePool {
    public class PooledObject {
        static object _idLock = new object();
        static int _nextId = 1;

        public PooledObject() {
            lock (_idLock) {
                PermanentId = _nextId++;
            }
        }

        public string Name { get; set; }

        public int PermanentId { get; private set; }
    }
}
