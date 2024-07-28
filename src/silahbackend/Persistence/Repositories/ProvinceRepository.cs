using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ProvinceRepository : EfRepositoryBase<Province, Guid, BaseDbContext>, IProvinceRepository
{
    public ProvinceRepository(BaseDbContext context) : base(context)
    {
    }
}