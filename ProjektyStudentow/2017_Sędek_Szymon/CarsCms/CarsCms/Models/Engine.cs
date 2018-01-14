using System;

namespace CarsCms.Models
{
    public class Engine: IBasicEntity
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateMod { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public int EngineCapacity { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
    }
}