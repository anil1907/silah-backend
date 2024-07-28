using NArchitecture.Core.Application.Dtos;

namespace Application.Features.ProductTypes.Queries.GetList;

public class GetListProductTypeListItemDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}