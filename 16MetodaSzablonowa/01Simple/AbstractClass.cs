using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
    abstract class AbstractClass {
        public abstract void PrimitiveOperation1();
        public abstract void PrimitiveOperation2();
        public virtual void OptionalOperation() {
            Console.WriteLine("AbstractClass.OptionalOperation()");
        }

        // The "Template method"
        public void TemplateMethod() {
            PrimitiveOperation1();
            PrimitiveOperation2();
            OptionalOperation();
        }
    }
}
