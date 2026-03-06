using Application.Common;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Queries
{
    public class GetProductsByNameQueryHandler : IQueryHandler<GetProductsByNameQuery>
    {
        private readonly IApplicationContext _context;

        public GetProductsByNameQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public IList<IResult> Handle(GetProductsByNameQuery query)
        {
            var products = _context.Products.Where(p => p.Name.Contains(query.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (products == null)
                return null;

            var results = new List<IResult>();
            foreach (var p in products)
            {
                var productDisplay = new ProductDisplay
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    UnitPrice = p.UnitPrice,
                    IsOutOfStock = p.IsOutOfStock
                };
                results.Add(productDisplay);

            }
            return results;
        }
    }
}
