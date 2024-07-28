using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductTypes.Commands.Create;

public class CreatedProductTypeResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}