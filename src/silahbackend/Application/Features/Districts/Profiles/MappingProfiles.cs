using Application.Features.Districts.Commands.Create;
using Application.Features.Districts.Commands.Delete;
using Application.Features.Districts.Commands.Update;
using Application.Features.Districts.Queries.GetById;
using Application.Features.Districts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Districts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDistrictCommand, District>();
        CreateMap<District, CreatedDistrictResponse>();

        CreateMap<UpdateDistrictCommand, District>();
        CreateMap<District, UpdatedDistrictResponse>();

        CreateMap<DeleteDistrictCommand, District>();
        CreateMap<District, DeletedDistrictResponse>();

        CreateMap<District, GetByIdDistrictResponse>();

        CreateMap<District, GetListDistrictListItemDto>();
        CreateMap<IPaginate<District>, GetListResponse<GetListDistrictListItemDto>>();
    }
}