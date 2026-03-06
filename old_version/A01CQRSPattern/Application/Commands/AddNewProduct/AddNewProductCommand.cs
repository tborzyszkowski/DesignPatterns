using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class AddNewProductCommand : ICommand
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
