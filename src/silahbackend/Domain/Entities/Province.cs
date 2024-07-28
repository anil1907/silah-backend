using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Province : Entity<Guid>
{
    public string Name { get; set; }
}

