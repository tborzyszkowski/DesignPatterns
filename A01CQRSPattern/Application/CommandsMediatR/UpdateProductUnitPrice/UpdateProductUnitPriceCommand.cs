using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandsMediatR
{
    public class UpdateProductUnitPriceCommand : IRequest
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }

    }
}
