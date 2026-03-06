using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Drawing {
	class MainApp {
		static void Main(string[] args) {
			CompositeElement root =
			  new CompositeElement("Picture");
			root.Add(new PrimitiveElement("Red Line"));
			root.Add(new PrimitiveElement("Blue Circle"));
			root.Add(new PrimitiveElement("Green Box"));
            root.Display(1);

            // Create a branch
            CompositeElement comp =
			  new CompositeElement("Two Circles");
			comp.Add(new PrimitiveElement("Black Circle"));
			comp.Add(new PrimitiveElement("White Circle"));
			root.Add(comp);
            root.Display(1);

            // Add and remove a PrimitiveElement
            PrimitiveElement pe =
			  new PrimitiveElement("Yellow Line");
			root.Add(pe);
            root.Display(1);
            root.Remove(pe);

			root.Display(1);
		}
	}
}
