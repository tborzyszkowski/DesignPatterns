using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandsMediatR
{
    public class UpdateProductCurrentStockCommand : IRequest
    {
        public Guid Id { get; set; }
        public int CurrentStock { get; set; }

    }
}
