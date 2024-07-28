using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductTypes;

public interface IProductTypeService
{
    Task<ProductType?> GetAsync(
        Expression<Func<ProductType, bool>> predicate,
        Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductType>?> GetListAsync(
        Expression<Func<ProductType, bool>>? predicate = null,
        Func<IQueryable<ProductType>, IOrderedQueryable<ProductType>>? orderBy = null,
        Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductType> AddAsync(ProductType productType);
    Task<ProductType> UpdateAsync(ProductType productType);
    Task<ProductType> DeleteAsync(ProductType productType, bool permanent = false);
}
