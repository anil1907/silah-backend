using Application.Features.Provinces.Commands.Create;
using Application.Features.Provinces.Commands.Delete;
using Application.Features.Provinces.Commands.Update;
using Application.Features.Provinces.Queries.GetById;
using Application.Features.Provinces.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Provinces.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateProvinceCommand, Province>();
        CreateMap<Province, CreatedProvinceResponse>();

        CreateMap<UpdateProvinceCommand, Province>();
        CreateMap<Province, UpdatedProvinceResponse>();

        CreateMap<DeleteProvinceCommand, Province>();
        CreateMap<Province, DeletedProvinceResponse>();

        CreateMap<Province, GetByIdProvinceResponse>();

        CreateMap<Province, GetListProvinceListItemDto>();
        CreateMap<IPaginate<Province>, GetListResponse<GetListProvinceListItemDto>>();
    }
}