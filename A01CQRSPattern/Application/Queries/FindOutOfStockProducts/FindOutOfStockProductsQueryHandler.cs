using Application.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries
{
    public class FindOutOfStockProductsQueryHandler : IQueryHandler<FindOutOfStockProductsQuery>
    {
        private readonly IApplicationContext _context;

        public FindOutOfStockProductsQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        
        public IList<IResult> Handle(FindOutOfStockProductsQuery query)
        {
            var products = _context.Products.Where(p => p.IsOutOfStock == true).ToList();
            if (products == null)
                return null;

            var results = new List<IResult>();
            foreach (var p in products)
            {
                var productDisplay = new ProductInventory
                {
                    Id = p.Id,
                    Name = p.Name,
                    CurrentStock = p.CurrentStock
                };
                results.Add(productDisplay);

            }
            return results;
        }
    }
}
