namespace TataGamedomWebAPI.Application.Features.Order.Queries.GetOrderListByAccount;

public class OrderWithDeatilsDto
{
    public int Id { get; set; }
    public required List<string> GameChiName { get; set; }

    public required List<bool> ProductIsVirtual { get; set; }

    public DateTime CreatedAt { get; set; }

    public decimal Total { get; set; }

    public required string OrderStatusCodeName { get; set; }

}
