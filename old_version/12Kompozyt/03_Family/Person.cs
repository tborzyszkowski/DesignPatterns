using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Composite {
	public class Person : IFamilyMember, IEnumerable<IFamilyMember> {
		private List<IFamilyMember> _children = new List<IFamilyMember>();

		public string Name { get; set; }

		public Person(string name) {
			Name = name;
		}

		public void AddChild(IFamilyMember child) {
			_children.Add(child);
		}

		public void RemoveChild(IFamilyMember child) {
			_children.Remove(child);
		}

		public IFamilyMember GetChild(int index) {
			return _children[index];
		}
		public IFamilyMember GetChild(string name) {
			return _children.Where(c => c.Name == name).FirstOrDefault();
		}

		public IEnumerable<IFamilyMember> GetChildren() {
			return _children;
		}

		public IEnumerator<IFamilyMember> GetEnumerator() {
			return ((IEnumerable<IFamilyMember>)_children).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() {
			return ((IEnumerable<IFamilyMember>)_children).GetEnumerator();
		}

		public void LogChildren() {
			Logging.LineSeparator();
			if (GetChildren().Any())
				Logging.Log($"{Name} has ({GetChildren().Count()}) children:\n{String.Join("\n", GetChildren().Select(c => c.Name))}");
			else
				Logging.Log($"{Name} has no children.");
		}
	}

}
