using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductListings;

public interface IProductListingService
{
    Task<ProductListing?> GetAsync(
        Expression<Func<ProductListing, bool>> predicate,
        Func<IQueryable<ProductListing>, IIncludableQueryable<ProductListing, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductListing>?> GetListAsync(
        Expression<Func<ProductListing, bool>>? predicate = null,
        Func<IQueryable<ProductListing>, IOrderedQueryable<ProductListing>>? orderBy = null,
        Func<IQueryable<ProductListing>, IIncludableQueryable<ProductListing, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductListing> AddAsync(ProductListing productListing);
    Task<ProductListing> UpdateAsync(ProductListing productListing);
    Task<ProductListing> DeleteAsync(ProductListing productListing, bool permanent = false);
}
