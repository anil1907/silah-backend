using Application.Features.ProductTypes.Rules;
using Application.Services.Repositories;
using NArchitecture.Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductTypes;

public class ProductTypeManager : IProductTypeService
{
    private readonly IProductTypeRepository _productTypeRepository;
    private readonly ProductTypeBusinessRules _productTypeBusinessRules;

    public ProductTypeManager(IProductTypeRepository productTypeRepository, ProductTypeBusinessRules productTypeBusinessRules)
    {
        _productTypeRepository = productTypeRepository;
        _productTypeBusinessRules = productTypeBusinessRules;
    }

    public async Task<ProductType?> GetAsync(
        Expression<Func<ProductType, bool>> predicate,
        Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductType? productType = await _productTypeRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productType;
    }

    public async Task<IPaginate<ProductType>?> GetListAsync(
        Expression<Func<ProductType, bool>>? predicate = null,
        Func<IQueryable<ProductType>, IOrderedQueryable<ProductType>>? orderBy = null,
        Func<IQueryable<ProductType>, IIncludableQueryable<ProductType, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductType> productTypeList = await _productTypeRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productTypeList;
    }

    public async Task<ProductType> AddAsync(ProductType productType)
    {
        ProductType addedProductType = await _productTypeRepository.AddAsync(productType);

        return addedProductType;
    }

    public async Task<ProductType> UpdateAsync(ProductType productType)
    {
        ProductType updatedProductType = await _productTypeRepository.UpdateAsync(productType);

        return updatedProductType;
    }

    public async Task<ProductType> DeleteAsync(ProductType productType, bool permanent = false)
    {
        ProductType deletedProductType = await _productTypeRepository.DeleteAsync(productType);

        return deletedProductType;
    }
}
