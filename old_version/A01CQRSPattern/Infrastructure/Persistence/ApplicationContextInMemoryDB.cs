using Application.Interfaces;
using Domaine.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationContextInMemoryDB : DbContext, IApplicationContextInMemoryDB
    {

        public DbSet<Product> Products { get; set;}

        public ApplicationContextInMemoryDB(DbContextOptions options) : base(options)
        {
            LoadProducts();
        }

        

        public void LoadProducts()
        {


            var products = new List<Product>()
            {
                new Product
                {
                    Id = new Guid("b9eac4cd-016a-4fd2-9d37-40c0a5a9e300"),
                    Name = "iPhone 8",
                    Description = "iPhone 8",
                    CurrentStock = 15,
                    UnitPrice = 600
                },

                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "iPhone 4",
                    Description = "iPhone 4",
                    CurrentStock = 12,
                    UnitPrice = 100
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "iPhone X",
                    Description = "iPhone X",
                    CurrentStock = 15,
                    UnitPrice = 1000
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "iPhone 10",
                    Description = "iPhone 10",
                    CurrentStock = 0,
                    UnitPrice = 700
                },
            };

            Products.AddRange(products);
            base.SaveChangesAsync();

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);    
        }

       
    }
}
