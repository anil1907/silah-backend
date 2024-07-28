using Application.Features.ProductListings.Constants;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;
using static Application.Features.ProductListings.Constants.ProductListingsOperationClaims;

namespace Application.Features.ProductListings.Queries.GetList;

public class GetListProductListingQuery : IRequest<GetListResponse<GetListProductListingListItemDto>>, ISecuredRequest, ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string[] Roles => [Admin, Read];

    public bool BypassCache { get; }
    public string? CacheKey => $"GetListProductListings({PageRequest.PageIndex},{PageRequest.PageSize})";
    public string? CacheGroupKey => "GetProductListings";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductListingQueryHandler : IRequestHandler<GetListProductListingQuery, GetListResponse<GetListProductListingListItemDto>>
    {
        private readonly IProductListingRepository _productListingRepository;
        private readonly IMapper _mapper;

        public GetListProductListingQueryHandler(IProductListingRepository productListingRepository, IMapper mapper)
        {
            _productListingRepository = productListingRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListProductListingListItemDto>> Handle(GetListProductListingQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProductListing> productListings = await _productListingRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListProductListingListItemDto> response = _mapper.Map<GetListResponse<GetListProductListingListItemDto>>(productListings);
            return response;
        }
    }
}