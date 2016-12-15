using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
    class Composite : Component {
        private List<Component> _children = new List<Component>();

        // Constructor
        public Composite(string name)
          : base(name) {
        }

        public override void Add(Component component) {
            _children.Add(component);
        }

        public override void Remove(Component component) {
            _children.Remove(component);
        }

        public override void Display(int depth) {
            Console.WriteLine(new String('-', depth) + name);

            // Recursively display child nodes
            foreach (Component component in _children) {
                component.Display(depth + 2);
            }
        }
    }
}
