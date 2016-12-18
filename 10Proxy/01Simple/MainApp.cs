using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class MainApp {
        static void Main(string[] args) {
            // Create proxy and request a service
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }
}

