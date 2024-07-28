using Application.Features.Provinces.Constants;
using Application.Features.Provinces.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.Provinces.Constants.ProvincesOperationClaims;

namespace Application.Features.Provinces.Commands.Update;

public class UpdateProvinceCommand : IRequest<UpdatedProvinceResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public string[] Roles => [Admin, Write, ProvincesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProvinces"];

    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand, UpdatedProvinceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProvinceRepository _provinceRepository;
        private readonly ProvinceBusinessRules _provinceBusinessRules;

        public UpdateProvinceCommandHandler(IMapper mapper, IProvinceRepository provinceRepository,
                                         ProvinceBusinessRules provinceBusinessRules)
        {
            _mapper = mapper;
            _provinceRepository = provinceRepository;
            _provinceBusinessRules = provinceBusinessRules;
        }

        public async Task<UpdatedProvinceResponse> Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            Province? province = await _provinceRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _provinceBusinessRules.ProvinceShouldExistWhenSelected(province);
            province = _mapper.Map(request, province);

            await _provinceRepository.UpdateAsync(province!);

            UpdatedProvinceResponse response = _mapper.Map<UpdatedProvinceResponse>(province);
            return response;
        }
    }
}