using Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR.DeleteProduct
{
    public class ProductDeletedHandler : INotificationHandler<ProductDeleted>
    {
        private readonly ILogger<ProductDeletedHandler> _logger;

        public ProductDeletedHandler(ILogger<ProductDeletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductDeleted notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Product {notification.DeletedProduct.Id} was deleted.");
            return Task.CompletedTask;
        }
    }
}
