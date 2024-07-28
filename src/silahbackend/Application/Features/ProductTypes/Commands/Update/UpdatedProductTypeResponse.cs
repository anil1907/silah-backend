using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductTypes.Commands.Update;

public class UpdatedProductTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}