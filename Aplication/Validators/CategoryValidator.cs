using Domain.Entities;
using FluentValidation;

namespace Aplication.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty()
                                 .WithMessage("Category nomi bosh bolmasligi lozim")
                                 .Length(3, 50)
                                .WithMessage("Category name 3 va 50 ta belgi orasida bolishi kerakv"); ;
        }
    }
}
