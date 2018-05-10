using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite {
    //
    // see: https://airbrake.io/blog/design-patterns/composite
    //
    class Program {
        static void Main(string[] args) {
            // Parent 1
            Person john = new Person("John");
            // Parent 2
            Person jane = new Person("Jane");

            // Child 1
            Person alice = new Person("Alice");
            // Child 2
            Person billy = new Person("Billy");
            // Child 3
            Person christine = new Person("Christine");

            // Output children
            john.LogChildren();
            jane.LogChildren();

            // John and Jane are both parents of Alice
            john.AddChild(alice);
            jane.AddChild(alice);

            // John is also Billy's parent
            john.AddChild(billy);

            // Jane is also Christine's parent
            jane.AddChild(christine);

            // Output children
            john.LogChildren();
            jane.LogChildren();

            // Since David is John's brother he is also an uncle.
            Uncle david = new Uncle("David");

            // David and John are both the children of their father Edward.
            Person edward = new Person("Edward");
            edward.AddChild(john);
            // Even though 'david' is class of Uncle it can still be added
            // as a child.
            edward.AddChild(david);

            // Output edward's children.
            edward.LogChildren();
        }
    }
}
