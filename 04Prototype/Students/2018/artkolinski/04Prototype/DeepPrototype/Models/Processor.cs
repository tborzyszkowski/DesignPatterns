using System;

namespace DeepPrototype.Models
{
    [Serializable]
    public class Processor
    {
        public string Model { get; set; }
        public Cooling Cooling { get; set; }
    }
}
