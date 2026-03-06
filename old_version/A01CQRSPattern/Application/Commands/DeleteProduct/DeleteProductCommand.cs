using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class DeleteProductCommand : ICommand 
    {
        public Guid Id { get; set; }

    }
}
