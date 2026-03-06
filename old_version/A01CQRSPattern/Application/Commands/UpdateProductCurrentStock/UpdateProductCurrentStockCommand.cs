using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class UpdateProductCurrentStockCommand : ICommand
    {
        public Guid Id { get; set; }
        public int CurrentStock { get; set; }


    }
}
