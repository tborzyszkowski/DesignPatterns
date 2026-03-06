using Application.Events;
using Application.Exceptions;
using Application.Interfaces;
using Domaine.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IApplicationContextInMemoryDB _context;
        private readonly IMediator _mediator;

        public DeleteProductCommandHandler(IApplicationContextInMemoryDB context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(request.Id);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.Id);

            _context.Products.Remove(product);
            
            await _context.SaveChangesAsync(cancellationToken);

            //notification
            await _mediator.Publish(new ProductDeleted(product));

            return Unit.Value;
        }

    }
}
