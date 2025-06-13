using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Commands
{
    public class UpdateProductUnitPriceCommand : ICommand
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        
        
    }
}
