using TataGamedomWebAPI.Models.Dtos;
using TataGamedomWebAPI.Models.EFModels;

namespace TataGamedomWebAPI.Application.Features.InventoryItem.Queries.GetInventoryItemDetails;

public class InventoryItemDetailsDto
{
    public int Id { get; set; }

    public string Index { get; set; } = null!;

    public int ProductId { get; set; }

    public int StockInSheetId { get; set; }

    public decimal Cost { get; set; }

    public string? GameKey { get; set; }

}


