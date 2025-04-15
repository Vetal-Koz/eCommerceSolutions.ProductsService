using eCommerce.Core.DTO;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class ProductUpdateRequestValidator : AbstractValidator<ProductUpdateRequest>
{
    public ProductUpdateRequestValidator()
    {
        RuleFor(x => x.ProductName)
            .NotEmpty().WithMessage("Product name cannot be empty");
        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category cannot be empty");
    }

}