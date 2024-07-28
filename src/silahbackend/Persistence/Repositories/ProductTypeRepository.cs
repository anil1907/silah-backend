using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductTypeRepository : EfRepositoryBase<ProductType, Guid, BaseDbContext>, IProductTypeRepository
{
    public ProductTypeRepository(BaseDbContext context) : base(context)
    {
    }
}