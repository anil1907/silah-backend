using Application.Features.ProductTypes.Commands.Create;
using Application.Features.ProductTypes.Commands.Delete;
using Application.Features.ProductTypes.Commands.Update;
using Application.Features.ProductTypes.Queries.GetById;
using Application.Features.ProductTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProductTypeCommand, ProductType>();
        CreateMap<ProductType, CreatedProductTypeResponse>();

        CreateMap<UpdateProductTypeCommand, ProductType>();
        CreateMap<ProductType, UpdatedProductTypeResponse>();

        CreateMap<DeleteProductTypeCommand, ProductType>();
        CreateMap<ProductType, DeletedProductTypeResponse>();

        CreateMap<ProductType, GetByIdProductTypeResponse>();

        CreateMap<ProductType, GetListProductTypeListItemDto>();
        CreateMap<IPaginate<ProductType>, GetListResponse<GetListProductTypeListItemDto>>();
    }
}