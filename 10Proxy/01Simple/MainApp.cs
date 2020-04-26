using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
	class MainApp {
		static void Main(string[] args) {
			Proxy proxy = new Proxy();
			proxy.Request();
			Console.WriteLine("=================");
			proxy.Request();
			Console.WriteLine("=================");
		}
	}
}

