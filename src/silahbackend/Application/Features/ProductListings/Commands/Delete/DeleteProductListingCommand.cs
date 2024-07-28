using Application.Features.ProductListings.Constants;
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

namespace Application.Features.ProductListings.Commands.Delete;

public class DeleteProductListingCommand : IRequest<DeletedProductListingResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, ProductListingsOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetProductListings"];

    public class DeleteProductListingCommandHandler : IRequestHandler<DeleteProductListingCommand, DeletedProductListingResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductListingRepository _productListingRepository;
        private readonly ProductListingBusinessRules _productListingBusinessRules;

        public DeleteProductListingCommandHandler(IMapper mapper, IProductListingRepository productListingRepository,
                                         ProductListingBusinessRules productListingBusinessRules)
        {
            _mapper = mapper;
            _productListingRepository = productListingRepository;
            _productListingBusinessRules = productListingBusinessRules;
        }

        public async Task<DeletedProductListingResponse> Handle(DeleteProductListingCommand request, CancellationToken cancellationToken)
        {
            ProductListing? productListing = await _productListingRepository.GetAsync(predicate: pl => pl.Id == request.Id, cancellationToken: cancellationToken);
            await _productListingBusinessRules.ProductListingShouldExistWhenSelected(productListing);

            await _productListingRepository.DeleteAsync(productListing!);

            DeletedProductListingResponse response = _mapper.Map<DeletedProductListingResponse>(productListing);
            return response;
        }
    }
}