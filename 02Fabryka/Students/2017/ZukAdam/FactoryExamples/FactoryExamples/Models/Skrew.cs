using FactoryExamples.Interfaces;

namespace FactoryExamples.Models
{
    public class Skrew : IPart
    {
        public string GetMaterial()
        {
            return "Metal";
        }
    }
}
