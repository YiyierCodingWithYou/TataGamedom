using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Application.Features.Order.Commands.CreateOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.DeleteOrder;
using TataGamedomWebAPI.Application.Features.Order.Commands.UpdateOrder;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderDetails;
using TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderList;
using TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemDetails;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemList;
using TataGamedomWebAPI.Application.Features.OrderItem.Queries.GetOrderItemListByAccount;
using TataGamedomWebAPI.Application.Features.Product.Queries.GetProductTopFiveSalesList;

namespace TataGamedomWebAPI.Controllers;

[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderItemsController(IMediator mediator)
    {
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<List<OrderItemDto>> Get()
    {
        var orderItems = await _mediator.Send(new GetOrderItemListQuery());
        return orderItems;
    }

    [HttpGet("ProductTopFiveSales")]
    public async Task<ActionResult<List<ProductTopFiveSalesDto>>> GetProductTopFiveSales()
    {
        var products = await _mediator.Send(new GetProductTopFiveSalesListQuery());
        return Ok(products);
    }

    [HttpGet("order/{orderId}")]
    public async Task<ActionResult<List<OrderItemWithDetailsDto>>> GetListByAccountAndOrderIdWithDetails(int orderId) 
    {
        var orderItemList = await _mediator.Send(new GetOrderItemListByOrderIdQuery(orderId));
        return Ok(orderItemList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<OrderDetailsDto>> Get(int id)
    {
        var orderItemDetails = await _mediator.Send(new GetOrderItemDetailsQuery(id));
        return Ok(orderItemDetails);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Post(AddOrderItemToOrderCommand orderItem)
    {
        var response = await _mediator.Send(orderItem);
        return CreatedAtAction(nameof(Get), new { id = response });
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
