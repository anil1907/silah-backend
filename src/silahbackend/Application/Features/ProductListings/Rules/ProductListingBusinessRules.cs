using Application.Features.ProductListings.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ProductListings.Rules;

public class ProductListingBusinessRules : BaseBusinessRules
{
    private readonly IProductListingRepository _productListingRepository;
    private readonly ILocalizationService _localizationService;

    public ProductListingBusinessRules(IProductListingRepository productListingRepository, ILocalizationService localizationService)
    {
        _productListingRepository = productListingRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductListingsBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductListingShouldExistWhenSelected(ProductListing? productListing)
    {
        if (productListing == null)
            await throwBusinessException(ProductListingsBusinessMessages.ProductListingNotExists);
    }

    public async Task ProductListingIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductListing? productListing = await _productListingRepository.GetAsync(
            predicate: pl => pl.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductListingShouldExistWhenSelected(productListing);
    }
}