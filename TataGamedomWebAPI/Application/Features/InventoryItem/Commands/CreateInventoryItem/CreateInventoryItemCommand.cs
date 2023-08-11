using MediatR;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Commands.CreateInventoryItem;

public class CreateInventoryItemCommand : IRequest<int>
{
    public string SKU { get; set; } = string.Empty;

    public int ProductId { get; set; }

    public int StockInSheetId { get; set; } = 50;  //Todo

    public decimal Cost { get; set; }

    public string GameKey { get; set; } = string.Empty;

}
