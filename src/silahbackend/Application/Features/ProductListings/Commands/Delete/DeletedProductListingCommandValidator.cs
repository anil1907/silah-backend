using FluentValidation;

namespace Application.Features.ProductListings.Commands.Delete;

public class DeleteProductListingCommandValidator : AbstractValidator<DeleteProductListingCommand>
{
    public DeleteProductListingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}