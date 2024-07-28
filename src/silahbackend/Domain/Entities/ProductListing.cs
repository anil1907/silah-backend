using NArchitecture.Core.Persistence.Repositories;
using System.Xml.Linq;

namespace Domain.Entities;
public class ProductListing : Entity<Guid>
{
    public string Title { get; set; }
    public double Price { get; set; }
    public int PriceCurrency { get; set; }
    public string Phone { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
    public int NewOrUsed { get; set; }
    public int LicenseStatus { get; set; }
    public int ModelId { get; set; }
    public int DistrictId { get; set; }
    public int CategoryId { get; set; }
    public int TypeId { get; set; }
    public int BrandId { get; set; }
    public int UserId { get; set; }

    //public virtual Model? Models { get; set; }
    //public virtual District? Districts { get; set; }
    //public virtual Category? Categorys { get; set; }
    //public virtual Type? Types { get; set; }
    //public virtual User? Users { get; set; }

    //public ProductListing()
    //{
    //    Models = new HashSet<Model>();
    //}

    //public Brand(Guid id, string name)
    //    : this()
    //{
    //    Id = id;
    //    Name = name;
    //}
}
