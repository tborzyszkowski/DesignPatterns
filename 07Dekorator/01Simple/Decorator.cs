using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    abstract class Decorator : Component {
        protected Component component;

        public void SetComponent(Component component) {
            this.component = component;
        }

        public override void Operation() {
            component?.Operation();
            //if (component != null) {
            //    component.Operation();
            //}
        }
    }
}
