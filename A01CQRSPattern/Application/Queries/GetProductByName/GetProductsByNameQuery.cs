using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries
{
    public class GetProductsByNameQuery : IQuery
    {
        public string Name { get; set; }
    }
}
