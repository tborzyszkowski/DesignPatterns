using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ColorPrototype {
	abstract class ColorPrototype {
		public abstract ColorPrototype Clone();
	}

	class Color : ColorPrototype {
		private int _red;
		private int _green;
		private int _blue;

		public Color(int red, int green, int blue) {
			this._red = red;
			this._green = green;
			this._blue = blue;
		}
		public override ColorPrototype Clone() => this.MemberwiseClone() as ColorPrototype;
		public override string ToString() =>
			$"Cloning color RGB: {_red,3},{_green,3},{_blue,3}";
	}
}

