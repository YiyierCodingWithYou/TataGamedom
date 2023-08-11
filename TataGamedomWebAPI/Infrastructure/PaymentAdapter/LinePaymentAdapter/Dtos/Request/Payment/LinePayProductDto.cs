namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class LinePayProductDto
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public int Price { get; set; }
    public string? Id { get; set; }
    public string? ImageUrl { get; set; }
    public int? OriginalPrice { get; set; }
}
