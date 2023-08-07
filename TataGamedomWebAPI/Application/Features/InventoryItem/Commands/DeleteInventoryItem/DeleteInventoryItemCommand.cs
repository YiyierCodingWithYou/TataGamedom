using MediatR;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Commands.DeleteInventoryItem;

public class DeleteInventoryItemCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
