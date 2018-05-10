using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace Composite {
    /// <summary>
    /// Enumerable list of Persons that belong to a family.
    /// </summary>
    public class Person : IFamilyMember, IEnumerable<IFamilyMember> {
        /// <summary>
        /// Private list of children belonging to this person.
        /// </summary>
        private List<IFamilyMember> _children = new List<IFamilyMember>();

        public string Name { get; set; }

        public Person(string name) {
            Name = name;
        }

        /// <summary>
        /// Add a child to the list of children.
        /// </summary>
        /// <param name="child">Child to add.</param>
        public void AddChild(IFamilyMember child) {
            _children.Add(child);
        }

        /// <summary>
        /// Remove a children from the list of children.
        /// </summary>
        /// <param name="child">Child to remove.</param>
        public void RemoveChild(IFamilyMember child) {
            _children.Remove(child);
        }

        /// <summary>
        /// Get a child instance by index.
        /// </summary>
        /// <param name="index">Index of child to retrieve.</param>
        /// <returns>Child record.</returns>
        public IFamilyMember GetChild(int index) {
            return _children[index];
        }

        /// <summary>
        /// Get a child instance by name.
        /// </summary>
        /// <param name="name">Name of child to retrieve.</param>
        /// <returns>Child record.</returns>
        public IFamilyMember GetChild(string name) {
            return _children.Where(c => c.Name == name).First();
        }

        /// <summary>
        /// Get collection of children.
        /// </summary>
        /// <returns>Collection of children.</returns>
        public IEnumerable<IFamilyMember> GetChildren() {
            return _children;
        }

        public IEnumerator<IFamilyMember> GetEnumerator() {
            return ((IEnumerable<IFamilyMember>)_children).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable<IFamilyMember>)_children).GetEnumerator();
        }

        /// <summary>
        /// Output current children list in human-readable form.
        /// </summary>
        public void LogChildren() {
            Logging.LineSeparator();
            // Check if person has any children.
            if (GetChildren().Any())
            {
                // Output person's name, number of children, and list of child names.
                Logging.Log($"{Name} has ({GetChildren().Count()}) children:\n{String.Join("\n", GetChildren().Select(c => c.Name))}");
            }
            else
            {
                // No children to output.
                Logging.Log($"{Name} has no children.");
            }
        }
    }

}
