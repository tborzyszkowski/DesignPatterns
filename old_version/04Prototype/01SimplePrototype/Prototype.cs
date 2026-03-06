using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01SimplePrototype {
	abstract class Prototype {
		public Prototype(string id) {
			this.Id = id;
		}
		public string Id { get; set; }

		public abstract Prototype Clone();
	}
}
