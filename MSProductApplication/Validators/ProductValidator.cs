using FluentValidation;
using MSProductDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSProductApplication.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(50).WithMessage("Product name must not exceed 50 characters.");
            RuleFor(p => p.Description)
                .MaximumLength(150).WithMessage("Product description must not exceed 150 characters.");
            RuleFor(p => p.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than 0.");
            RuleFor(p => p.Stock)
                .GreaterThanOrEqualTo(0).WithMessage("Product stock cannot be negative.");
        }
    }
}