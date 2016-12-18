using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Drawing {
    class CompositeElement : DrawingElement {
        private List<DrawingElement> elements =
          new List<DrawingElement>();

        // Constructor
        public CompositeElement(string name)
          : base(name) {
        }

        public override void Add(DrawingElement d) {
            elements.Add(d);
        }

        public override void Remove(DrawingElement d) {
            elements.Remove(d);
        }

        public override void Display(int indent) {
            Console.WriteLine(new String('-', indent) +
              "+ " + _name);

            // Display each child element on this node
            foreach (DrawingElement d in elements) {
                d.Display(indent + 2);
            }
        }
    }
}
