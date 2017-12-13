using FactoryExamples.Interfaces;

namespace FactoryExamples.Models
{
    public class Glass : IPart
    {
        public string GetMaterial()
        {
            return "Glass";
        }
    }
}
