using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ConcurrentBagImplementation {
    // A toy class that requires some resources to create.
    // You can experiment here to measure the performance of the
    // object pool vs. ordinary instantiation.
    class MyClass {
        public double[] Nums { get; set; }
        public double GetValue(long i) {
            return Math.Sqrt(Math.Abs(Nums[i]));
        }
        public MyClass() {
            Console.WriteLine("new MyClass()");
            Nums = new double[100];
            //Random rand = new Random();
            for (int i = 0; i < Nums.Length; i++)
                Nums[i] = Math.Sqrt(i);
        }
    }
}
