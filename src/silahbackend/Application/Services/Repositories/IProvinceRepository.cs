using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface IProvinceRepository : IAsyncRepository<Province, Guid>, IRepository<Province, Guid>
{
}