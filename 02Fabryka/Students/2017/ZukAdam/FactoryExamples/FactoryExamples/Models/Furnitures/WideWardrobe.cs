using FactoryExamples.Enums;
using FactoryExamples.Interfaces;
using System.Collections.Generic;

namespace FactoryExamples.Models.Furnitures
{
    public class WideWardrobe : Furniture
    {
        public WideWardrobe()
        {
            this.Name = "Wide wardrobe";
            this.Category = CategoryEnum.Wardrobe;
            this.Depth = 1.8;
            this.Width = 8;
            this.Height = 2.6;
            this.Parts = new List<IPart>
            {
                new Board(),
                new Board(),
                new Board(),
                new Skrew(),
                new Skrew(),
                new Skrew(),
                new Glass(),
                new Glass()
            };
        }
    }
}
