using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;
using TataGamedomWebAPI.Infrastructure.OrderInfrastructure.Commands;
using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Controllers;

//Todo 改DTO
[EnableCors("AllowAny")]
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Order>>> Get()
    {
        return Ok(await _mediator.Send(new GetOrderListQuery()));
    }


    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Order>> Get(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        Order order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
        {
            return NotFound();
        }
        return Ok(order);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Order>> Post([FromBody] OrderCreateDto order)
    {
        if (order == null)
        {
            return BadRequest(order);
        }
        return Ok(await _mediator.Send(
            new CreateOrderCommand(
            order.MemberId,
            order.OrderStatusId,
            order.ShipmentStatusId,
            order.PaymentStatusId,
            order.ShipmemtMethodId,
            order.RecipientName,
            order.ToAddress)));
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Put(int id, [FromBody] Order order)
    {
        if (order == null || id != order.Id)
        {
            return BadRequest();
        }
        return Ok(await _mediator.Send(
            new UpdateOrderCommand(
            order.Id,
            order.OrderStatusId,
            order.ShipmentStatusId,
            order.PaymentStatusId,
            order.ShipmemtMethodId,
            order.TrackingNum)));
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        Order order = await _mediator.Send(new GetOrderByIdQuery(id));
        if (order == null)
        {
            return NotFound();
        }

        await _mediator.Send(new DeleteOrderCommand(id));
        return NoContent();
    }
}
