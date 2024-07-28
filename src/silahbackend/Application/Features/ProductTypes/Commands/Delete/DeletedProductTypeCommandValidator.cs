using FluentValidation;

namespace Application.Features.ProductTypes.Commands.Delete;

public class DeleteProductTypeCommandValidator : AbstractValidator<DeleteProductTypeCommand>
{
    public DeleteProductTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}