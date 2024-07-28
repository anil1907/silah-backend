using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProductType : Entity<Guid>
{
    public string Name { get; set; }
}
