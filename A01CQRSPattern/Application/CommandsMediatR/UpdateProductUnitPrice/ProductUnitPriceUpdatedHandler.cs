using Application.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CommandsMediatR.UpdateProductUnitPrice
{
    public class ProductUnitPriceUpdatedHandler : INotificationHandler<ProductUnitPriceUpdated>
    {
        private readonly ILogger<ProductUnitPriceUpdatedHandler> _logger;

        public ProductUnitPriceUpdatedHandler(ILogger<ProductUnitPriceUpdatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(ProductUnitPriceUpdated notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"The UnitPrice of Product {notification.NewProduct.Id} was updated, new Value = {notification.NewProduct.UnitPrice} and last Value={notification.OldUnitPrice}.");
            return Task.CompletedTask;
        }
    }
}