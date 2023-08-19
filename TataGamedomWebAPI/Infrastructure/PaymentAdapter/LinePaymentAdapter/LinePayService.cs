using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;

namespace TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;

public class LinePayService
{
    private readonly string channelId = "2000361109";
    private readonly string channelSecretKey = "0e4e5eea8de9d55687434baf986c7d43";
    private readonly string linePayBaseApiUrl = "https://sandbox-api-pay.line.me";
    private static HttpClient client;
    private readonly JsonProvider _jsonProvider;
    private readonly AppDbContext _dbContext;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LinePayService(AppDbContext dbContext, IHttpContextAccessor httpContextAccessor)
    {
        client = new HttpClient();
        _jsonProvider = new JsonProvider();
        this._dbContext = dbContext;
        this._httpContextAccessor = httpContextAccessor;
    }

    public async Task<PaymentResponseDto> SendPaymentRequestWithCartInfo()
    {

        string? account = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault()?.Value;

        //Maping LinePayproduct
        List<LinePayProductDto> productDtos = await _dbContext.Carts
            .Where(c => c.Member.Account == account)
            .Select(c => new LinePayProductDto 
            {
                Name = c.Product.Game!.ChiName,
                Quantity = 1,
                Price = c.Product.Price,   //未處理優惠
            })
            .ToListAsync();


        //Maping PackageDto
        List<PackageDto> packageDtos = new List<PackageDto>();
        packageDtos.Add(new PackageDto
        {
            Id = Guid.NewGuid().ToString(),
            Amount = productDtos.Select(p => p.Price).Sum(),
            Products = productDtos
        });


        //Mapping to paymentRequestDto
        PaymentRequestDto? paymentRequestDto = new PaymentRequestDto
        {
            Amount = packageDtos.Select(p => p.Amount).Sum(),
            Currency = "TWD",
            OrderId = Guid.NewGuid().ToString(),     //todo => 先建訂單，傳Index到OrderId
            Packages = packageDtos,
            RedirectUrls = new RedirectUrlsDto
            {
                ConfirmUrl = "https://localhost:3000/LinePayConfirmPayment",
                CancelUrl = ""
            }
        };



        var json = _jsonProvider.Serialize(paymentRequestDto);
        var nonce = Guid.NewGuid().ToString();
        var requstUrl = "/v3/payments/request";
        var signature = SignatureProvider.HMACSHA256(channelSecretKey, channelSecretKey + requstUrl + json + nonce);

        var request = new HttpRequestMessage(HttpMethod.Post, linePayBaseApiUrl + requstUrl)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        client.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", nonce);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization", signature);

        var response = await client.SendAsync(request);
        var linePayResponse = _jsonProvider.Deserialize<PaymentResponseDto>(await response.Content.ReadAsStringAsync());

        Console.WriteLine(nonce);
        Console.WriteLine(signature);



        // Todo 刪除購物車


        return linePayResponse;
    }

    public async Task<PaymentResponseDto> SendPaymentRequest(PaymentRequestDto dto)
    {
        var json = _jsonProvider.Serialize(dto);
        var nonce = Guid.NewGuid().ToString();
        var requstUrl = "/v3/payments/request";
        var signature = SignatureProvider.HMACSHA256(channelSecretKey, channelSecretKey + requstUrl + json + nonce);

        var request = new HttpRequestMessage(HttpMethod.Post, linePayBaseApiUrl + requstUrl)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        client.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", nonce);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization", signature);

        var response = await client.SendAsync(request);
        var linePayResponse = _jsonProvider.Deserialize<PaymentResponseDto>(await response.Content.ReadAsStringAsync());

        Console.WriteLine(nonce);
        Console.WriteLine(signature);

        return linePayResponse;
    }

    public async Task<PaymentConfirmResponseDto> ConfirmPayment(string transactionId, string orderId, PaymentConfirmDto dto)
    {
        var json = _jsonProvider.Serialize(dto);

        var nonce = Guid.NewGuid().ToString();
        var requestUrl = string.Format("/v3/payments/{0}/confirm", transactionId);
        var signature = SignatureProvider.HMACSHA256(channelSecretKey, channelSecretKey + requestUrl + json + nonce);

        var request = new HttpRequestMessage(HttpMethod.Post, String.Format(linePayBaseApiUrl + requestUrl, transactionId))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        client.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", nonce);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization", signature);

        var response = await client.SendAsync(request);
        var responseDto = _jsonProvider.Deserialize<PaymentConfirmResponseDto>(await response.Content.ReadAsStringAsync());
        return responseDto;
    }

    public async Task<PaymentRefundResponseDto> RefundPayment(string transactionId, PaymentRefundRequestDto dto)
    {
        string json = _jsonProvider.Serialize(dto);
        string nonce = Guid.NewGuid().ToString();
        var requestUrl = string.Format("/v3/payments/{0}/refund", transactionId);
        
        var signature = SignatureProvider.HMACSHA256(channelSecretKey, channelSecretKey + requestUrl + json + nonce);

        var request = new HttpRequestMessage(HttpMethod.Post, String.Format(linePayBaseApiUrl + requestUrl, transactionId))
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        client.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", nonce);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization", signature);

        var response = await client.SendAsync(request);
        var responseDto = _jsonProvider.Deserialize<PaymentRefundResponseDto>(await response.Content.ReadAsStringAsync());
        return responseDto;
    }


    public async void TransactionCancel(string transactionId)
    {
        Console.WriteLine($"訂單 {transactionId} 已取消");
    }


}

