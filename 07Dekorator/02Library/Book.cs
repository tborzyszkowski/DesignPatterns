﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
	class Book : LibraryItem {
		private string _author;
		private string _title;

		public Book(string author, string title, int numCopies): base(numCopies)
		{
			this._author = author;
			this._title = title;
		}

		public override void Display() {
			Console.WriteLine("\nBook ------ ");
			Console.WriteLine(" Author: {0}", _author);
			Console.WriteLine(" Title: {0}", _title);
			Console.WriteLine(" # Copies: {0}", NumCopies);
		}
	}
}
