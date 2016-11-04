using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePool {
    public class Pool<T> where T : new() {
        List<T> _available = new List<T>();
        List<T> _inUse = new List<T>();

        public T Get() {
            lock (_available) {
                if (_available.Count != 0) {
                    T obj = _available[0];
                    _inUse.Add(obj);
                    _available.RemoveAt(0);
                    return obj;
                }
                else {
                    T obj = new T();
                    _inUse.Add(obj);
                    return obj;
                }
            }
        }

        public void Release(T obj) {
            CleanUp(obj);

            lock (_available) {
                _available.Add(obj);
                _inUse.Remove(obj);
            }
        }

        private void CleanUp(T obj) {
        }
    }
}
