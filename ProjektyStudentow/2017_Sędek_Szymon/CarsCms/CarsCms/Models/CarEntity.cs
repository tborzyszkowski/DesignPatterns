using System;

namespace CarsCms.Models
{
    public class CarEntity : IBasicEntity
    {
        public int Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateMod { get; set; }
        public bool IsActive { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string ModPerson { get; set; }
        public string RegistrationNumber { get; set; }
    }
}