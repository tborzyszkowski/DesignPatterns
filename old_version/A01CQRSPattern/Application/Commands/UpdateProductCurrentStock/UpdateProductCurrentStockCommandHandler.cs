using Application.Exceptions;
using Application.Interfaces;
using Domaine.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class UpdateProductCurrentStockCommandHandler : ICommandHandler<UpdateProductCurrentStockCommand>
    {

        private readonly IApplicationContext _context;

        public UpdateProductCurrentStockCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductCurrentStockCommand command)
        {
            var product = _context.Products.Where(p => p.Id == command.Id).SingleOrDefault();
            if (product == null)
                throw new NotFoundException(nameof(Product), command.Id);
            else
                product.CurrentStock = command.CurrentStock;

            await Task.Run(() => { });
        }
    }
}
