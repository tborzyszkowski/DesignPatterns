using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Simple {
	class Proxy : Subject {
		private RealSubject _realSubject;

		public override void Request() {
			// Use 'lazy initialization'
			Console.WriteLine("Proxy: We need RealSubject instance in Proxy");
			if (_realSubject == null)
			{
				_realSubject = new RealSubject();
				Console.WriteLine("Proxy: New RealSubject created");
			}
			Console.WriteLine("Proxy: Call RealSubject.Request()");
			_realSubject.Request();
		}
	}
}
