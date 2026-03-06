using Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR.UpdateProductCurrentStock
{
    class ProductCurrentStockUpdatedHandler : INotificationHandler<ProductCurrentStockUpdated>
    {
        private readonly ILogger<ProductCurrentStockUpdatedHandler> _logger;

        public ProductCurrentStockUpdatedHandler(ILogger<ProductCurrentStockUpdatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductCurrentStockUpdated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"The CurrentStock of Product {notification.NewProduct.Id} was updated, new Value = {notification.NewProduct.CurrentStock} and last Value={notification.OldStock}.");
            return Task.CompletedTask;
        }
    }
}