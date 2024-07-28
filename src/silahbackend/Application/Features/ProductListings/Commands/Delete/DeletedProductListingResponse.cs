using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductListings.Commands.Delete;

public class DeletedProductListingResponse : IResponse
{
    public Guid Id { get; set; }
}