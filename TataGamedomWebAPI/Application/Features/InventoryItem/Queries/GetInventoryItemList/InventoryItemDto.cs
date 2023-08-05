namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemList;

public class InventoryItemDto
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int ProductId { get; set; }

    public int StockInSheetId { get; set; }

    public decimal Cost { get; set; }

    public string? GameKey { get; set; }

}
