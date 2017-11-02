using FactoryExamples.Enums;
using FactoryExamples.Interfaces;
using System.Collections.Generic;

namespace FactoryExamples.Models
{
    public abstract class Furniture
    {
        public string Name { get; set; }

        public CategoryEnum Category { get; set; }

        public List<IPart> Parts { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Depth { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
