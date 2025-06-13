using Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR
{
    public class NewProductCreatedHandler : INotificationHandler<ProductCreated>
    {

        private readonly ILogger<NewProductCreatedHandler> _logger;

        public NewProductCreatedHandler(ILogger<NewProductCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCreated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Product {notification.NewProduct.Id} was added to data base.");
            return Task.CompletedTask;
        }

   
    }
}
