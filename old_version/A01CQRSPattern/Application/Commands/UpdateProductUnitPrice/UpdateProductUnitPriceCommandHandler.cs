using Application.Interfaces;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Exceptions;
using Domaine.Entities;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateProductUnitPriceCommandHandler : ICommandHandler<UpdateProductUnitPriceCommand>
    {
        private readonly IApplicationContext _context;

        public UpdateProductUnitPriceCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductUnitPriceCommand command)
        {
            var product = _context.Products.Where(p => p.Id == command.Id).SingleOrDefault();
            if (product == null)
                throw new NotFoundException(nameof(Product), command.Id);
            else
                product.UnitPrice = command.UnitPrice;
            await Task.Run(() => { });
        }
    }
}
