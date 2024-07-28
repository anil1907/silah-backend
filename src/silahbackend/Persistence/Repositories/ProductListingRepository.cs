using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProductListingRepository : EfRepositoryBase<ProductListing, Guid, BaseDbContext>, IProductListingRepository
{
    public ProductListingRepository(BaseDbContext context) : base(context)
    {
    }
}