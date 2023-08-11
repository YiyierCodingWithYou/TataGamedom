using MediatR;

namespace TataGamedomWebAPI.Application.Features.OrderItem.Commands.CreateOrderItem;

public class CreateOrderItemCommand : IRequest<int>
{
    public int OrderId { get; set; }

    public decimal ProductPrice { get; set; }

    public int ProductId { get; set; }

    public int InventoryItemId { get; set; }

}
