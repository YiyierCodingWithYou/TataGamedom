using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateMultipleOrderItemReturns;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.CreateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.DeleteOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Commands.UpdateOrderItemReturn;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnDetails;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnList;
using TataGamedomWebAPI.Application.Features.OrderItemReturn.Queries.GetOrderItemReturnListByOrderId;

namespace TataGamedomWebAPI.Controllers;

[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class OrderItemReturnsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemReturnsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<OrderItemReturnDto>>> Get()
    {
        var orderItemReturn = await _mediator.Send(new GetOrderItemReturnListQuery());
        return Ok(orderItemReturn);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<OrderItemReturnDto>> Get(int id)
    {
        var orderItemReturns = await _mediator.Send(new GetOrderItemReturnDetailsQuery(id));
        return Ok(orderItemReturns);
    }

    [HttpGet("ItemIdList/{orderId}")]
    public async Task<ActionResult<OrderItemReturnDto>> GetOrderItemIdReturnList(int orderId)
    {
        var orderItemIdList = await _mediator.Send(new GetOrderItemReturnListByOrderIdQuery(orderId));
        return Ok(orderItemIdList);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateOrderItemReturnCommand orderItemReturn)
    {
        var response = await _mediator.Send(orderItemReturn);
        return CreatedAtAction(nameof(Get), new { id = response });
    }


    [HttpPost("MultipleOrderItemsReturn")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateMultipleItemReturnsCommand orderItemReturnList)
    {
        List<OrderItemReturnDto> response = await _mediator.Send(orderItemReturnList);
        return Ok(response);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateOrderItemReturnCommand orderItemReturn)
    {
        await _mediator.Send(orderItemReturn);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOrderItemReturnCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
