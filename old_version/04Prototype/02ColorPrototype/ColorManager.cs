using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ColorPrototype {
	class ColorManager {
		private Dictionary<string, ColorPrototype> _colors =
		  new Dictionary<string, ColorPrototype>();

		public ColorPrototype this[string key] {
			get => _colors[key];
			set => _colors.Add(key, value);
		}
	}
}
