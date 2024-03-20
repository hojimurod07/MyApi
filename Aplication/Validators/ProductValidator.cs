

using Domain.Entities;
using FluentValidation;

namespace Aplication.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty()
                .Length(3, 50)
                .WithMessage("Product nomi 3 va 50 orasida bolishi kerak");
            RuleFor(p => p.Description).NotEmpty()
                .Length(3, 500)
                .WithMessage("Product Descriptioni 3 va 500 orasida bolishi kerak");
            RuleFor(p => p.Price)
                  .NotEmpty()
                   .NotEqual(0)
                  .WithMessage("Price cannot be empty.");
            RuleFor(p => p.CategoryId)
                .NotEmpty()
                 .NotEqual(0)
                .WithMessage("Tesgishli id yanlanmagan ");




        }
    }
}
