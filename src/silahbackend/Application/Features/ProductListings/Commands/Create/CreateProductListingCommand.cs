using Application.Features.ProductListings.Constants;
using Application.Features.ProductListings.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.ProductListings.Constants.ProductListingsOperationClaims;

namespace Application.Features.ProductListings.Commands.Create;

public class CreateProductListingCommand : IRequest<CreatedProductListingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public required string Title { get; set; }
    public required double Price { get; set; }
    public required int PriceCurrency { get; set; }
    public required string Phone { get; set; }
    public required string Description { get; set; }
    public required int Status { get; set; }
    public required int NewOrUsed { get; set; }
    public required int LicenseStatus { get; set; }
    public required int ModelId { get; set; }
    public required int DistrictId { get; set; }
    public required int CategoryId { get; set; }
    public required int TypeId { get; set; }
    public required int BrandId { get; set; }
    public required int UserId { get; set; }

    public string[] Roles => [Admin, Write, ProductListingsOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductListings"];

    public class CreateProductListingCommandHandler : IRequestHandler<CreateProductListingCommand, CreatedProductListingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductListingRepository _productListingRepository;
        private readonly ProductListingBusinessRules _productListingBusinessRules;

        public CreateProductListingCommandHandler(IMapper mapper, IProductListingRepository productListingRepository,
                                         ProductListingBusinessRules productListingBusinessRules)
        {
            _mapper = mapper;
            _productListingRepository = productListingRepository;
            _productListingBusinessRules = productListingBusinessRules;
        }

        public async Task<CreatedProductListingResponse> Handle(CreateProductListingCommand request, CancellationToken cancellationToken)
        {
            ProductListing productListing = _mapper.Map<ProductListing>(request);

            await _productListingRepository.AddAsync(productListing);

            CreatedProductListingResponse response = _mapper.Map<CreatedProductListingResponse>(productListing);
            return response;
        }
    }
}