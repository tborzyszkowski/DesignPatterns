using Application.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Application.Common
{
    public class ProductDisplay : IResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsOutOfStock { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Description={Description}, UnitPrice={UnitPrice}, IsOutOfStock={IsOutOfStock}";
        }
    }
}
