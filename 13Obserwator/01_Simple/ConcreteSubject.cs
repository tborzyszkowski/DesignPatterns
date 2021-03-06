using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Simple {
	class ConcreteSubject : Subject {
		private string _subjectState;

		public string SubjectState {
			get { return _subjectState; }
			set {
				_subjectState = value;
				Notify();
			}
		}
	}
}
