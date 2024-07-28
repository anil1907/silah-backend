using Application.Features.ProductListings.Commands.Create;
using Application.Features.ProductListings.Commands.Delete;
using Application.Features.ProductListings.Commands.Update;
using Application.Features.ProductListings.Queries.GetById;
using Application.Features.ProductListings.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductListingsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProductListingResponse>> Add([FromBody] CreateProductListingCommand command)
    {
        CreatedProductListingResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProductListingResponse>> Update([FromBody] UpdateProductListingCommand command)
    {
        UpdatedProductListingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProductListingResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProductListingCommand command = new() { Id = id };

        DeletedProductListingResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProductListingResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProductListingQuery query = new() { Id = id };

        GetByIdProductListingResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListProductListingQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductListingQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProductListingListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}