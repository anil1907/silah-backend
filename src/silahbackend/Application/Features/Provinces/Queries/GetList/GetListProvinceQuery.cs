using Application.Features.Provinces.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.Provinces.Constants.ProvincesOperationClaims;

namespace Application.Features.Provinces.Queries.GetList;

public class GetListProvinceQuery : IRequest<GetListResponse<GetListProvinceListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProvinces({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProvinces";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProvinceQueryHandler : IRequestHandler<GetListProvinceQuery, GetListResponse<GetListProvinceListItemDto>>
    {
        private readonly IProvinceRepository _provinceRepository;
        private readonly IMapper _mapper;

        public GetListProvinceQueryHandler(IProvinceRepository provinceRepository, IMapper mapper)
        {
            _provinceRepository = provinceRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProvinceListItemDto>> Handle(GetListProvinceQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Province> provinces = await _provinceRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProvinceListItemDto> response = _mapper.Map<GetListResponse<GetListProvinceListItemDto>>(provinces);
            return response;
        }
    }
}