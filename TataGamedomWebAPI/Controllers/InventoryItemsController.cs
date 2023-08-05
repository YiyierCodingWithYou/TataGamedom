using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Application.Features.InventoryItem.Commands.CreateInventoryItem;
using TataGamedomWebAPI.Application.Features.InventoryItem.Commands.DeleteInventoryItem;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemDetails;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemList;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryDetails;
using TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetRemainingInventoryQuantity;

namespace TataGamedomWebAPI.Controllers;

[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class InventoryItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public InventoryItemsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<InventoryItemDto>>> Get() => Ok(await _mediator.Send(new GetInventoryItemQuery()));

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryItemDto>> Get(int id) => Ok(await _mediator.Send(new GetInventoryItemDetailsQuery(id)));

    [HttpGet("{productId}/RemainingQuantity")]
    public async Task<ActionResult<int>> RemainingInventoryQuantity(int productId) 
        => Ok(await _mediator.Send(new GetRemainingInventoryQuantityQuery(productId)));


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Post(CreateInventoryItemCommand inventoryItem)
    {
        int response = await _mediator.Send(new CreateInventoryItemCommand());
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id) 
    {
        await _mediator.Send(new DeleteInventoryItemCommand { Id = id });
        return NoContent();
    }
}
