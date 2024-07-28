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

namespace Application.Features.ProductListings.Commands.Update;

public class UpdateProductListingCommand : IRequest<UpdatedProductListingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
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

    public string[] Roles => [Admin, Write, ProductListingsOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductListings"];

    public class UpdateProductListingCommandHandler : IRequestHandler<UpdateProductListingCommand, UpdatedProductListingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductListingRepository _productListingRepository;
        private readonly ProductListingBusinessRules _productListingBusinessRules;

        public UpdateProductListingCommandHandler(IMapper mapper, IProductListingRepository productListingRepository,
                                         ProductListingBusinessRules productListingBusinessRules)
        {
            _mapper = mapper;
            _productListingRepository = productListingRepository;
            _productListingBusinessRules = productListingBusinessRules;
        }

        public async Task<UpdatedProductListingResponse> Handle(UpdateProductListingCommand request, CancellationToken cancellationToken)
        {
            ProductListing? productListing = await _productListingRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _productListingBusinessRules.ProductListingShouldExistWhenSelected(productListing);
            productListing = _mapper.Map(request, productListing);

            await _productListingRepository.UpdateAsync(productListing!);

            UpdatedProductListingResponse response = _mapper.Map<UpdatedProductListingResponse>(productListing);
            return response;
        }
    }
}