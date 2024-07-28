using FluentValidation;

namespace Application.Features.ProductListings.Commands.Update;

public class UpdateProductListingCommandValidator : AbstractValidator<UpdateProductListingCommand>
{
    public UpdateProductListingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.PriceCurrency).NotEmpty();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
        RuleFor(c => c.NewOrUsed).NotEmpty();
        RuleFor(c => c.LicenseStatus).NotEmpty();
        RuleFor(c => c.ModelId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.TypeId).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}