using MediatR;
using Microsoft.AspNetCore.Mvc;
using TataGamedom_FrontEnd.Models.EFModels;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Commands;
using TataGamedom_FrontEnd.Models.Infra.OrderInfra.Queries;

namespace TataGamedom_FrontEnd.Controllers.APIContorllers;


//Todo 改DTO

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
    
        =>Ok(await _mediator.Send(new GetOrderListQuery()));


    [HttpGet("{id : int}")]
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
    public async Task<ActionResult<Order>> Post([FromBody] Order order)
    {
        if (order == null) 
        {
            return BadRequest(order);
        }
        if (order.Id > 0) 
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
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
    public async Task<IActionResult>Put(int id, [FromBody] Order order)
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
