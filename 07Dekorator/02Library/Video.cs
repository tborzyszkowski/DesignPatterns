﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02Library {
	class Video : LibraryItem {
		private string _director;
		private string _title;
		private int _playTime;

		public Video(string director, string title, int numCopies, int playTime) : base(numCopies) {
			this._director = director;
			this._title = title;
			this._playTime = playTime;
		}

		public override void Display() {
			Console.WriteLine("\nVideo ----- ");
			Console.WriteLine(" Director: {0}", _director);
			Console.WriteLine(" Title: {0}", _title);
			Console.WriteLine(" # Copies: {0}", NumCopies);
			Console.WriteLine(" Playtime: {0}\n", _playTime);
		}
	}
}
