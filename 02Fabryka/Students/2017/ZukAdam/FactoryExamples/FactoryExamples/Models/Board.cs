using FactoryExamples.Interfaces;

namespace FactoryExamples.Models
{
    public class Board : IPart
    {
        public string GetMaterial()
        {
            return "Wood";
        }
    }
}
