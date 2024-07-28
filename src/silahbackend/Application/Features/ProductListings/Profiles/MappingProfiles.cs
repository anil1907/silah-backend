using Application.Features.ProductListings.Commands.Create;
using Application.Features.ProductListings.Commands.Delete;
using Application.Features.ProductListings.Commands.Update;
using Application.Features.ProductListings.Queries.GetById;
using Application.Features.ProductListings.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.ProductListings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProductListingCommand, ProductListing>();
        CreateMap<ProductListing, CreatedProductListingResponse>();

        CreateMap<UpdateProductListingCommand, ProductListing>();
        CreateMap<ProductListing, UpdatedProductListingResponse>();

        CreateMap<DeleteProductListingCommand, ProductListing>();
        CreateMap<ProductListing, DeletedProductListingResponse>();

        CreateMap<ProductListing, GetByIdProductListingResponse>();

        CreateMap<ProductListing, GetListProductListingListItemDto>();
        CreateMap<IPaginate<ProductListing>, GetListResponse<GetListProductListingListItemDto>>();
    }
}