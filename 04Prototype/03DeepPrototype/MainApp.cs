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

			c2 = manager.prototypes["Australia"].Clone();
			PrototypeClient.Report("Shallow cloning Australia\n===============",
				manager.prototypes["Australia"], c2);

			c2.Capital = "Sydney";
			PrototypeClient.Report("Altered Clone's shallow state, prototype unaffected",
				manager.prototypes["Australia"], c2);

			c2.Language.Data = "Chinese";
			PrototypeClient.Report("Altering Clone deep state: prototype affected *****",
					manager.prototypes["Australia"], c2);

			c3 = manager.prototypes["Germany"].DeepCopy();
			PrototypeClient.Report("Deep cloning Germany\n============",
					manager.prototypes["Germany"], c3);

			c3.Capital = "Munich";
			PrototypeClient.Report("Altering Clone shallow state, prototype unaffected",
					manager.prototypes["Germany"], c3);

			c3.Language.Data = "Turkish";
			PrototypeClient.Report("Altering Clone deep state, prototype unaffected",
				manager.prototypes["Germany"], c3);
		}
	}
}
