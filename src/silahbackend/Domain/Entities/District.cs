using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class District : Entity<Guid>
{
    public string Name { get; set; }
    public virtual ICollection<Province> Provinces { get; set; }

    public District()
    {
        Provinces = new HashSet<Province>();
    }

    public District(Guid id, string name)
        : this()
    {
        Id = id;
        Name = name;
    }
}