using Application.Common;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.QueriesMediatR
{
    public class FindOutOfStockProductsQueryHandler : IRequestHandler<FindOutOfStockProductsQuery, List<ProductInventory>>
    {
        private readonly IApplicationContextInMemoryDB _context;

        public FindOutOfStockProductsQueryHandler(IApplicationContextInMemoryDB context)
        {
            _context = context;
        }
        public async Task<List<ProductInventory>> Handle(FindOutOfStockProductsQuery request, CancellationToken cancellationToken)
        {

            var products = await Task.Run(() => _context.Products.AsEnumerable().Where(p => p.IsOutOfStock == true).ToList());
            if (products == null)
                return null;

            var results = new List<ProductInventory>();
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
