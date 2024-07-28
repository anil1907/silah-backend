using Application.Features.Provinces.Commands.Create;
using Application.Features.Provinces.Commands.Delete;
using Application.Features.Provinces.Commands.Update;
using Application.Features.Provinces.Queries.GetById;
using Application.Features.Provinces.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProvincesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProvinceResponse>> Add([FromBody] CreateProvinceCommand command)
    {
        CreatedProvinceResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProvinceResponse>> Update([FromBody] UpdateProvinceCommand command)
    {
        UpdatedProvinceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProvinceResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProvinceCommand command = new() { Id = id };

        DeletedProvinceResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProvinceResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProvinceQuery query = new() { Id = id };

        GetByIdProvinceResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListProvinceQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProvinceQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProvinceListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}