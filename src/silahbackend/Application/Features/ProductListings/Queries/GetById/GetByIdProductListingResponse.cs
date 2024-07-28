using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductListings.Queries.GetById;

public class GetByIdProductListingResponse : IResponse
{
    public Guid Id { get; set; }
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
}