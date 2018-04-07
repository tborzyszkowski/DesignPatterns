using System;

namespace DeepPrototype.Models
{
    [Serializable]
    public class Motherboard
    {
        public Processor Processor { get; set; }
        public string Memory { get; set; }
        public string GraphicCard { get; set; }
    }
}