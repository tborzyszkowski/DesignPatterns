using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03DeepPrototype {
    class MainApp {
        static void Main(string[] args) {
            PrototypeManager manager = new PrototypeManager();
            Prototype c2, c3;

            // Make a copy of Australia's data
            c2 = manager.prototypes["Australia"].Clone();
            PrototypeClient.Report("Shallow cloning Australia\n===============",
                manager.prototypes["Australia"], c2);

            // Change the capital of Australia to Sydney
            c2.Capital = "Sydney";
            PrototypeClient.Report("Altered Clone's shallow state, prototype unaffected",
                manager.prototypes["Australia"], c2);

            // Change the language of Australia (deep data)
            c2.Language.Data = "Chinese";
            PrototypeClient.Report("Altering Clone deep state: prototype affected *****",
                    manager.prototypes["Australia"], c2);

            // Make a copy of Germany's data
            c3 = manager.prototypes["Germany"].DeepCopy();
            PrototypeClient.Report("Deep cloning Germany\n============",
                    manager.prototypes["Germany"], c3);

            // Change the capital of Germany
            c3.Capital = "Munich";
            PrototypeClient.Report("Altering Clone shallow state, prototype unaffected",
                    manager.prototypes["Germany"], c3);

            // Change the language of Germany (deep data)
            c3.Language.Data = "Turkish";
            PrototypeClient.Report("Altering Clone deep state, prototype unaffected",
                manager.prototypes["Germany"], c3);
        }
    }
}
