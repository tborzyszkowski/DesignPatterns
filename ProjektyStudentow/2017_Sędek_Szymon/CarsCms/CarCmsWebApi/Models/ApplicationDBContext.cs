using System.Data.Entity;

namespace CarCmsWebApi.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(): base("DefaultConnection")
        {
        }

        public DbSet<Performance> Performances { get; set; }

    }
}