using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02ColorPrototype {
	class MainApp {
		static void Main(string[] args) {
			ColorManager colormanager = new ColorManager();

			colormanager["red"] = new Color(255, 0, 0);
			colormanager["green"] = new Color(0, 255, 0);
			colormanager["blue"] = new Color(0, 0, 255);

			colormanager["angry"] = new Color(255, 54, 0);
			colormanager["peace"] = new Color(128, 211, 128);
			colormanager["flame"] = new Color(211, 34, 20);

			Color color1 = colormanager["red"].Clone() as Color;
			Color color2 = colormanager["peace"].Clone() as Color;
			Color color3 = colormanager["flame"].Clone() as Color;

			Console.WriteLine($"color1: {color1}");
			Console.WriteLine($"color2: {color2}");
			Console.WriteLine($"color3: {color3}");
		}
	}
}
