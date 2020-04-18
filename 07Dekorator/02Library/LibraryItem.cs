using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
	abstract class LibraryItem {
		public int NumCopies { get; set; }

		public abstract void Display();
	}
}
