using Application.Events;
using Application.Exceptions;
using Application.Interfaces;
using Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR
{
    public class UpdateProductUnitPriceCommandHandler : IRequestHandler<UpdateProductUnitPriceCommand>
    {
        private readonly IApplicationContextInMemoryDB _context;
        private readonly IMediator _mediator;

        public UpdateProductUnitPriceCommandHandler(IApplicationContextInMemoryDB context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }
        public async Task<Unit> Handle(UpdateProductUnitPriceCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            var oldUnitPrice = product.UnitPrice;


            product.UnitPrice = request.UnitPrice;
            await _context.SaveChangesAsync(cancellationToken);

            //notification
            await _mediator.Publish(new ProductUnitPriceUpdated(product, oldUnitPrice));

            return Unit.Value;
        }
    }
}
