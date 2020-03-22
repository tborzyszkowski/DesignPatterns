using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
	class ConcretePrototype1 : Prototype {
		public ConcretePrototype1(string id)
		  : base(id) {
		}

		public override Prototype Clone() => (Prototype)this.MemberwiseClone();
	}
}
