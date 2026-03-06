using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    class ObjectStructure {
        private List<Element> _elements = new List<Element>();

        public void Attach(Element element) {
            _elements.Add(element);
        }

        public void Detach(Element element) {
            _elements.Remove(element);
        }

        public void Accept(Visitor visitor) {
            foreach (Element element in _elements) {
                element.Accept(visitor);
            }
        }
    }
}
