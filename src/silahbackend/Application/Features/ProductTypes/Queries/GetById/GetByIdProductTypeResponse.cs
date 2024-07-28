using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductTypes.Queries.GetById;

public class GetByIdProductTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}