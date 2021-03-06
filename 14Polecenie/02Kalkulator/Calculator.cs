using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kalkulator {
	class Calculator {
		private int _current = 0;

		public void Operation(char @operator, int operand) {
			switch (@operator)
			{
				case '+': _current += operand; break;
				case '-': _current -= operand; break;
				case '*': _current *= operand; break;
				case '/': _current /= operand; break;
			}
			Console.WriteLine(
			  $"Current value = {_current,3} (following {@operator} {operand})");
		}
	}
}
