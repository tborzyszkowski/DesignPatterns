using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ConcreteHandler3 : Handler {
        public override void HandleRequest(int request) {
            if (request >= 20 && request < 30) {
                Console.WriteLine($"{this.GetType().Name} handled request {request}");
            }
            else
                successor?.HandleRequest(request);
        }
    }
}
