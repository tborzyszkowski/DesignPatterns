using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public class AddNewProductCommandValidator : AbstractValidator<AddNewProductCommand>
    {
        public AddNewProductCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Product Name must be specifed")
                        .MaximumLength(100).WithMessage("Product Name exceeds the authorized size 100");
            RuleFor(p => p.Description).MaximumLength(400).WithMessage("Product Description exceeds the authorized size which is 400");
        }
    }

   
}
