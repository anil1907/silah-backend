using Application.Features.Provinces.Constants;
using Application.Services.Repositories;
using NArchitecture.Core.Application.Rules;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Localization.Abstraction;
using Domain.Entities;

namespace Application.Features.Provinces.Rules;

public class ProvinceBusinessRules : BaseBusinessRules
{
    private readonly IProvinceRepository _provinceRepository;
    private readonly ILocalizationService _localizationService;

    public ProvinceBusinessRules(IProvinceRepository provinceRepository, ILocalizationService localizationService)
    {
        _provinceRepository = provinceRepository;
        _localizationService = localizationService;
    }

    private async Task throwBusinessException(string messageKey)
    {
        string message = await _localizationService.GetLocalizedAsync(messageKey, ProvincesBusinessMessages.SectionName);
        throw new BusinessException(message);
    }

    public async Task ProvinceShouldExistWhenSelected(Province? province)
    {
        if (province == null)
            await throwBusinessException(ProvincesBusinessMessages.ProvinceNotExists);
    }

    public async Task ProvinceIdShouldExistWhenSelected(Guid id, CancellationToken cancellationToken)
    {
        Province? province = await _provinceRepository.GetAsync(
            predicate: p => p.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProvinceShouldExistWhenSelected(province);
    }
}