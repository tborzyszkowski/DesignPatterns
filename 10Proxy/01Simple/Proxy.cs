using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class Proxy : Subject {
        private RealSubject _realSubject;

        public override void Request() {
            // Use 'lazy initialization'
            if (_realSubject == null) {
                _realSubject = new RealSubject();
            }

            _realSubject.Request();
        }
    }
}
