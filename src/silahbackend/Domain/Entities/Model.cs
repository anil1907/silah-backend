using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Model : Entity<Guid>
{
    public string Name { get; set; }
    public Guid BrandId { get; set; }
    public virtual Brand? Brand { get; set; }

    public Model(Guid id, Guid brandId, string name)
    {
        Id = id;
        BrandId = brandId;
        Name = name;
    }
}
