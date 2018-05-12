using System;

namespace ComputerProjects.Models
{
    [Serializable]
    public class Motherboard
    {
        public Processor Processor { get; set; }
        public string Name { get; set; }
    }
}