using Application.Features.ProductListings.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductListings;

public class ProductListingManager : IProductListingService
{
    private readonly IProductListingRepository _productListingRepository;
    private readonly ProductListingBusinessRules _productListingBusinessRules;

    public ProductListingManager(IProductListingRepository productListingRepository, ProductListingBusinessRules productListingBusinessRules)
    {
        _productListingRepository = productListingRepository;
        _productListingBusinessRules = productListingBusinessRules;
    }

    public async Task<ProductListing?> GetAsync(
        Expression<Func<ProductListing, bool>> predicate,
        Func<IQueryable<ProductListing>, IIncludableQueryable<ProductListing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductListing? productListing = await _productListingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productListing;
    }

    public async Task<IPaginate<ProductListing>?> GetListAsync(
        Expression<Func<ProductListing, bool>>? predicate = null,
        Func<IQueryable<ProductListing>, IOrderedQueryable<ProductListing>>? orderBy = null,
        Func<IQueryable<ProductListing>, IIncludableQueryable<ProductListing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductListing> productListingList = await _productListingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productListingList;
    }

    public async Task<ProductListing> AddAsync(ProductListing productListing)
    {
        ProductListing addedProductListing = await _productListingRepository.AddAsync(productListing);

        return addedProductListing;
    }

    public async Task<ProductListing> UpdateAsync(ProductListing productListing)
    {
        ProductListing updatedProductListing = await _productListingRepository.UpdateAsync(productListing);

        return updatedProductListing;
    }

    public async Task<ProductListing> DeleteAsync(ProductListing productListing, bool permanent = false)
    {
        ProductListing deletedProductListing = await _productListingRepository.DeleteAsync(productListing);

        return deletedProductListing;
    }
}
