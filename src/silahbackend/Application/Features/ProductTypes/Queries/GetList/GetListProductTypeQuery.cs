using Application.Features.ProductTypes.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductTypes.Constants.ProductTypesOperationClaims;

namespace Application.Features.ProductTypes.Queries.GetList;

public class GetListProductTypeQuery : IRequest<GetListResponse<GetListProductTypeListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProductTypes({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProductTypes";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductTypeQueryHandler : IRequestHandler<GetListProductTypeQuery, GetListResponse<GetListProductTypeListItemDto>>
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public GetListProductTypeQueryHandler(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductTypeListItemDto>> Handle(GetListProductTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductType> productTypes = await _productTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductTypeListItemDto> response = _mapper.Map<GetListResponse<GetListProductTypeListItemDto>>(productTypes);
            return response;
        }
    }
}