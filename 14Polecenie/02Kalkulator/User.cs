﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Kalkulator {
	class User {
		private Calculator _calculator = new Calculator();
		private List<Command> _commands = new List<Command>();
		private int _current = 0;

		public void Redo(int levels) {
			Console.WriteLine($"\n---- Redo {levels} levels ");
			for (int i = 0; i < levels; i++)
			{
				if (_current < _commands.Count - 1)
				{
					Command command = _commands[_current++];
					command.Execute();
				}
			}
		}

		public void Undo(int levels) {
			Console.WriteLine($"\n---- Undo {levels} levels ");
			for (int i = 0; i < levels; i++)
			{
				if (_current > 0)
				{
					Command command = _commands[--_current] as Command;
					command.UnExecute();
				}
			}
		}

		public void Compute(char @operator, int operand) {
			Command command = new CalculatorCommand(
			  _calculator, @operator, operand);
			command.Execute();

			_commands.Add(command);
			_current++;
		}
	}
}
