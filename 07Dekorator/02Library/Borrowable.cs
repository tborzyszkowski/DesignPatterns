using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
    class Borrowable : Decorator {
        protected List<string> borrowers = new List<string>();

        // Constructor
        public Borrowable(LibraryItem libraryItem)
          : base(libraryItem) {
        }

        public void BorrowItem(string name) {
            borrowers.Add(name);
            libraryItem.NumCopies--;
        }

        public void ReturnItem(string name) {
            borrowers.Remove(name);
            libraryItem.NumCopies++;
        }

        public override void Display() {
            base.Display();

            foreach (string borrower in borrowers) {
                Console.WriteLine(" borrower: " + borrower);
            }
        }
    }
}
