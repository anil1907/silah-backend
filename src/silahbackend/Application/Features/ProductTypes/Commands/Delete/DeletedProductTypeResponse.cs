using NArchitecture.Core.Application.Responses;

namespace Application.Features.ProductTypes.Commands.Delete;

public class DeletedProductTypeResponse : IResponse
{
    public Guid Id { get; set; }
}