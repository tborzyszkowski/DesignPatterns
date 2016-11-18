using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
    abstract class Decorator : LibraryItem {
        protected LibraryItem libraryItem;

        // Constructor
        public Decorator(LibraryItem libraryItem) {
            this.libraryItem = libraryItem;
        }

        public override void Display() {
            libraryItem.Display();
        }
    }
}
