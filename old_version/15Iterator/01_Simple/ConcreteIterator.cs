using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	class ConcreteIterator : Iterator {
		private ConcreteAggregate _aggregate;
		private int _current = 0;

		public ConcreteIterator(ConcreteAggregate aggregate) {
			this._aggregate = aggregate;
		}

		public override object First() {
			return _aggregate[0];
		}

		public override object Next() {
			object ret = null;
			if (_current < _aggregate.Count - 1)
			{
				ret = _aggregate[++_current];
			}

			return ret;
		}

		public override object CurrentItem() {
			return _aggregate[_current];
		}

		public override bool IsDone() {
			return _current >= _aggregate.Count;
		}
	}
}
