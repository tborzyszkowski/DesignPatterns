using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePool {
    class MainApp {
        static void Main(string[] args) {
            var pool = new Pool<PooledObject>();

            var obj1 = pool.Get();
            obj1.Name = "First";
            Show(obj1);

            var obj2 = pool.Get();
            obj2.Name = "Second";
            Show(obj2);

            pool.Release(obj1);

            var obj3 = pool.Get();
            obj3.Name = "Third";
            Show(obj3);
        }
        private static void Show(PooledObject obj) {
            Console.WriteLine("{0} - {1}", obj.PermanentId, obj.Name);
        }
    }
}
