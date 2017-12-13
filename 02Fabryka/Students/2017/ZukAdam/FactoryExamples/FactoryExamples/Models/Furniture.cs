using FactoryExamples.Enums;
using FactoryExamples.Interfaces;
using System;
using System.Collections.Generic;

namespace FactoryExamples.Models
{
    public abstract class Furniture
    {
        public string Name { get; set; }

        public CategoryEnum Category { get; set; }

        public List<IPart> Parts { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Depth { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public void CreateParts()
        {
            Console.WriteLine("Creating parts...");
        }

        public void Pack()
        {
            Console.WriteLine("Packing furniture...");
        }
    }
}
