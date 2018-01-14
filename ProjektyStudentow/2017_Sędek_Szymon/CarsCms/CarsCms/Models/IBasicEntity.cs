using System;

namespace CarsCms.Models
{
    public interface IBasicEntity
    {
        int Id { get; set; }
        DateTime DateCreate { get; set; }
        DateTime DateMod { get; set; }
        bool IsActive { get; set; }
    }
}
