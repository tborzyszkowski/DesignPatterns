using Application.Interfaces;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationContext : IApplicationContext
    {
        private List<Product> _products;

        public ApplicationContext()
        {
            _products = new List<Product>()
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
        }

        public IList<Product> Products 
        { 
            get => _products; 
            set => _products= (List<Product>)value; 
        }
    }
}
