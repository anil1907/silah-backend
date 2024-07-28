using Application.Features.ProductTypes.Commands.Create;
using Application.Features.ProductTypes.Commands.Delete;
using Application.Features.ProductTypes.Commands.Update;
using Application.Features.ProductTypes.Queries.GetById;
using Application.Features.ProductTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProductTypeResponse>> Add([FromBody] CreateProductTypeCommand command)
    {
        CreatedProductTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProductTypeResponse>> Update([FromBody] UpdateProductTypeCommand command)
    {
        UpdatedProductTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProductTypeResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProductTypeCommand command = new() { Id = id };

        DeletedProductTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProductTypeResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProductTypeQuery query = new() { Id = id };

        GetByIdProductTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListProductTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProductTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}