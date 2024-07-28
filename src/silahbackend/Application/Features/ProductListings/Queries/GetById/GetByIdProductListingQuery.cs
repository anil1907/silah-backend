using Application.Features.ProductListings.Constants;
using Application.Features.ProductListings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using MediatR;
using static Application.Features.ProductListings.Constants.ProductListingsOperationClaims;

namespace Application.Features.ProductListings.Queries.GetById;

public class GetByIdProductListingQuery : IRequest<GetByIdProductListingResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Read];

    public class GetByIdProductListingQueryHandler : IRequestHandler<GetByIdProductListingQuery, GetByIdProductListingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductListingRepository _productListingRepository;
        private readonly ProductListingBusinessRules _productListingBusinessRules;

        public GetByIdProductListingQueryHandler(IMapper mapper, IProductListingRepository productListingRepository, ProductListingBusinessRules productListingBusinessRules)
        {
            _mapper = mapper;
            _productListingRepository = productListingRepository;
            _productListingBusinessRules = productListingBusinessRules;
        }

        public async Task<GetByIdProductListingResponse> Handle(GetByIdProductListingQuery request, CancellationToken cancellationToken)
        {
            ProductListing? productListing = await _productListingRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _productListingBusinessRules.ProductListingShouldExistWhenSelected(productListing);

            GetByIdProductListingResponse response = _mapper.Map<GetByIdProductListingResponse>(productListing);
            return response;
        }
    }
}