using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.DeleteOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleItemsWithOrderId;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateMultipleOrderItems;

namespace TataGamedomWebAPI.Controllers;

[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrdersController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet("AllOrders")]
    public async Task<List<OrderDto>> Get()
    {
        var orders = await _mediator.Send(new GetOrderListQuery());
        return orders;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailsDto>> Get(int id)
    {
        var order = await _mediator.Send(new GetOrderDetailQuery(id));
        return Ok(order);
    }

    [HttpGet]
    [EnableCors("AllowCookie")]
    public async Task<ActionResult<List<OrderWithDeatilsDto>>> GetByAccount()
    {
        var orderList = await _mediator.Send(new GetOrderListByAccountQuery());
        return Ok(orderList);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateOrderCommand order)
    {
        var response = await _mediator.Send(order);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPost("OrderWithMultipleItems")]
	[EnableCors("AllowCookie")]
	[ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(CreateMultipleItemsWithOrderIdCommand orderItemListWithId)
    {
        List<CreateOrderItemResponseDto> response = await _mediator.Send(orderItemListWithId);
        return Ok(response);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Put(UpdateOrderCommand order)
    {
        await _mediator.Send(order);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var command = new DeleteOrderCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
