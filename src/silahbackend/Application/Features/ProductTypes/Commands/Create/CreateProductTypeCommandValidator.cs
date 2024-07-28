using FluentValidation;

namespace Application.Features.ProductTypes.Commands.Create;

public class CreateProductTypeCommandValidator : AbstractValidator<CreateProductTypeCommand>
{
    public CreateProductTypeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}