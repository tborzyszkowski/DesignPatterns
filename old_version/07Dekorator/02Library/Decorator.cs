using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
	abstract class Decorator : Item {
		protected LibraryItem libraryItem;

		protected Decorator(LibraryItem libraryItem) {
			this.libraryItem = libraryItem;
		}

		public override void Display() {
			libraryItem.Display();
		}
	}
}
