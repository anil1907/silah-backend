using Application.Features.ProductTypes.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.ProductTypes.Rules;

public class ProductTypeBusinessRules : BaseBusinessRules
{
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly ILocalizationService _localizationService;

    public ProductTypeBusinessRules(IProductTypeRepository productTypeRepository, ILocalizationService localizationService)
    {
        _productTypeRepository = productTypeRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProductTypesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProductTypeShouldExistWhenSelected(ProductType? productType)
    {
        if (productType == null)
            await throwBusinessException(ProductTypesBusinessMessages.ProductTypeNotExists);
    }

    public async Task ProductTypeIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        ProductType? productType = await _productTypeRepository.GetAsync(
            predicate: pt => pt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductTypeShouldExistWhenSelected(productType);
    }
}