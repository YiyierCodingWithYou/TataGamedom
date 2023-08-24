namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;

public class RedirectUrlsDto
{
    public string ConfirmUrl { get; set; } = "https://localhost:3000/LinePayConfirmPayment";
    //掃完QRCode之後的確認付款頁，點擊確認後呼叫Confirm API 完成付款
    //呼叫Confirm API的參數也在這裡，前端傳給Confirm API 的參數Amount要對上後端CreateRequest的Amount
    public string CancelUrl { get; set; } = "https://localhost:3000/Cart";
    public string? AppPackageName { get; set; }
    public string? ConfirmUrlType { get; set; }
}
