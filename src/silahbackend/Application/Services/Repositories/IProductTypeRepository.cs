using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProductTypeRepository : IAsyncRepository<ProductType, Guid>, IRepository<ProductType, Guid>
{
}