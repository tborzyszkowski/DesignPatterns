using FactoryExamples.Enums;
using FactoryExamples.Interfaces;
using System.Collections.Generic;

namespace FactoryExamples.Models.Furnitures
{
    public class LargeDesk : Furniture
    {
        public LargeDesk()
        {
            this.Name = "Large desk";
            this.Category = CategoryEnum.Desk;
            this.Depth = 0.8;
            this.Width = 1.5;
            this.Height = 1.3;
            this.Parts = new List<IPart>
            {
                new Board(),
                new Board(),
                new Board(),
                new Skrew(),
                new Skrew(),
                new Skrew()
            };
        }
    }
}
