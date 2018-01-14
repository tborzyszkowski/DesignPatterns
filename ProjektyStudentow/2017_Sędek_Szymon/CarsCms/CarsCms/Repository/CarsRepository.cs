using CarsCms.Models;
using CarsCms.Repository.Interfaces;

namespace CarsCms.Repository
{
    public class CarsRepository : AbstractRepository<CarEntity>, ICarsRepository
    {
    }
}