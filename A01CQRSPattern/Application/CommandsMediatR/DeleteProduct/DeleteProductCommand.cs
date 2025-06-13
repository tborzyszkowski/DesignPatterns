using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandsMediatR
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
