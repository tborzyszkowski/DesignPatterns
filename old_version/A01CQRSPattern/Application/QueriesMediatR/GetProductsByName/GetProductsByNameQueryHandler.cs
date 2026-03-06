using Application.Common;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueriesMediatR
{
    public class GetProductsByNameQueryHandler : IRequestHandler<GetProductsByNameQuery, List<ProductDisplay>>
    {
        private readonly IApplicationContextInMemoryDB _context;

        public GetProductsByNameQueryHandler(IApplicationContextInMemoryDB context)
        {
            _context = context;
        }

        public async Task<List<ProductDisplay>> Handle(GetProductsByNameQuery request, CancellationToken cancellationToken)
        {

            var products =  await _context.Products.Where(p => p.Name.Contains(request.Name, StringComparison.OrdinalIgnoreCase)).ToListAsync();

            if (products == null)
                return null;

            var results = new List<ProductDisplay>();
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
