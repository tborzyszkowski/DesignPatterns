﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Inwestors {
	abstract class Stock {
		private string _symbol;
		private double _price;
		private List<IInvestor> _investors = new List<IInvestor>();
		public double Price {
			get { return _price; }
			set {
				if (_price != value)
				{
					_price = value;
					Notify();
				}
			}
		}

		public string Symbol {
			get { return _symbol; }
		}

		public Stock(string symbol, double price) {
			this._symbol = symbol;
			this._price = price;
		}

		public void Attach(IInvestor investor) {
			_investors.Add(investor);
		}

		public void Detach(IInvestor investor) {
			_investors.Remove(investor);
		}

		public void Notify() {
			foreach (IInvestor investor in _investors)
			{
				investor.Update(this);
			}

			Console.WriteLine("Notify");
		}
	}
}
