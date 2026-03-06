using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CommandsMediatR
{
    public class AddNewProductCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
