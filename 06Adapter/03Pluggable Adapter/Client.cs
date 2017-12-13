using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03Pluggable_Adapter {
    // Adapter Pattern - Pluggable             Judith Bishop  Oct 2007
    // Adapter can accept any number of pluggable adaptees and targets
    // and route the requests via a delegate, in some cases using the
    // anonymous delegate construct
    class Client {
        static void Main(string[] args) {
            Adapter adapter1 = new Adapter(new Adaptee());
            Console.WriteLine(adapter1.Request(5));

            Adapter adapter2 = new Adapter(new Target());
            Console.WriteLine(adapter2.Request(5));

            adapter2.ChangeRequest(i => $"{2*i} -- nowy wynik");
            Console.WriteLine(adapter2.Request(5));
        }
    }
}
