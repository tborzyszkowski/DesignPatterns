using Application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.QueriesMediatR
{
    public class GetProductsByNameQuery : IRequest<List<ProductDisplay>> 
    {
        public string Name { get; set; }
    }
}
