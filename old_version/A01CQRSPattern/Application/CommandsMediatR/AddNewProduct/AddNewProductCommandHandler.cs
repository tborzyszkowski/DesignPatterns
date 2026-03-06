using Application.Events;
using Application.Exceptions;
using Application.Interfaces;
using Domaine.Entities;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR
{
    public class AddNewProductCommandHandler : IRequestHandler<AddNewProductCommand, int>
    {
        private readonly IApplicationContextInMemoryDB _context;
        private readonly IMediator _mediator;

        public AddNewProductCommandHandler(IApplicationContextInMemoryDB context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<int> Handle(AddNewProductCommand request, CancellationToken cancellationToken)
        {
            //validation
            var validator = new AddNewProductCommandValidator();
            ValidationResult results = validator.Validate(request);
            bool validationSucceeded = results.IsValid;
            if (!validationSucceeded)
            {
                var failures = results.Errors.ToList();
                var message = new StringBuilder();
                failures.ForEach(f => { message.Append(f.ErrorMessage + Environment.NewLine); });
                throw new ValidationException(message.ToString());
            }
            //add new product
            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                UnitPrice = 0,
                CurrentStock = 0
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            //notification
            await _mediator.Publish(new ProductCreated(product));

            return 1;
        }
    }
}
