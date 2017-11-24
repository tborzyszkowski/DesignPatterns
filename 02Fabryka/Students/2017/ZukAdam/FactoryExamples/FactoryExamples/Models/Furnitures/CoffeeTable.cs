using FactoryExamples.Enums;
using FactoryExamples.Interfaces;
using System.Collections.Generic;

namespace FactoryExamples.Models.Furnitures
{
    public class CoffeeTable : Furniture
    {
        public CoffeeTable()
        {
            this.Name = "Coffee table";
            this.Category = CategoryEnum.Table;
            this.Depth = 0.5;
            this.Width = 2;
            this.Height = 1.5;
            this.Parts = new List<IPart>
            {
                new Board(),
                new Board(),
                new Board(),
                new Glass()
            };
        }
    }
}
