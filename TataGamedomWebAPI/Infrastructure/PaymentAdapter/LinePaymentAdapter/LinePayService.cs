using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using TataGamedomWebAPI.Infrastructure.Data;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.PaymentRefund;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentConfirm;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.PaymentRefund;
using TataGamedomWebAPI.Models.EFModels;

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

    public async Task<PaymentResponseDto> SendPaymentRequestWithCartInfo(ShipmentMethodDto shipment)
    {
        List<LinePayProductDto> productDtos = await GetProductsInCartsInfo(shipment);

        List<PackageDto> packageDtos = PutProductsIntoPackage(productDtos, shipment);

        PaymentRequestDto paymentRequestDto = CreatePaymentRequest(packageDtos, shipment);

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

        return linePayResponse;
    }

    public async Task<PaymentResponseDto> SendPaymentRequest(PaymentRequestDto dto)
    {
        var json = _jsonProvider.Serialize(dto);
        var nonce = Guid.NewGuid().ToString();
        var requstUrl = "/v3/payments/request";
        var signature = SignatureProvider.HMACSHA256(channelSecretKey, channelSecretKey + requstUrl + json + nonce);

        client.DefaultRequestHeaders.Add("X-LINE-ChannelId", channelId);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization-Nonce", nonce);
        client.DefaultRequestHeaders.Add("X-LINE-Authorization", signature);

        var request = new HttpRequestMessage(HttpMethod.Post, linePayBaseApiUrl + requstUrl)
        {
            Content = new StringContent(json, Encoding.UTF8, "application/json")
        };

        var response = await client.SendAsync(request);

        var linePayResponse = _jsonProvider.Deserialize<PaymentResponseDto>(await response.Content.ReadAsStringAsync());

        return linePayResponse;
    }

    public async Task<PaymentConfirmResponseDto> ConfirmPayment(string transactionId, PaymentConfirmDto dto)
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
        PaymentConfirmResponseDto responseDto = _jsonProvider.Deserialize<PaymentConfirmResponseDto>(await response.Content.ReadAsStringAsync());

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

        HttpResponseMessage response = await client.SendAsync(request);
        Console.WriteLine(response);
        try 
        {
            var responseDto = _jsonProvider.Deserialize<PaymentRefundResponseDto>(await response.Content.ReadAsStringAsync());
            return responseDto;

        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex);
        }
        return null;

    }

    public async void TransactionCancel(string transactionId)
    {
        Console.WriteLine($"訂單 {transactionId} 已取消");
    }

    private async Task<List<LinePayProductDto>> GetProductsInCartsInfo(ShipmentMethodDto shipmentMethodDto)
    {
        string? account = _httpContextAccessor.HttpContext?.User.Claims.Where(c => c.Type == ClaimTypes.Name).FirstOrDefault()?.Value;

        //Maping LinePayproduct
        List<LinePayProductDto> productDtos = await _dbContext.Carts
            .Where(c => c.Member.Account == account)
            .Select(c => new LinePayProductDto
            {
                Name = c.Product.Game!.ChiName,
                Quantity = 1,
                OriginalPrice = c.Product.Price,
                Price = c.Product.CouponsProducts
                .Any(
                    cp => DateTime.Now >= cp.Coupon.StartTime && DateTime.Now <= cp.Coupon.EndTime && cp.ProductId == c.ProductId) ?
                    (int)Math.Round(c.Product.CouponsProducts
                    .Where(cp => DateTime.Now >= cp.Coupon.StartTime && DateTime.Now <= cp.Coupon.EndTime && cp.ProductId == c.ProductId)
                            .Select
                            (
                                cp => cp.Coupon.DiscountTypeId == (int)DiscountType.PercentDiscount ? c.Product.Price * (cp.Coupon.Discount / 100.0)
                                : cp.Coupon.DiscountTypeId == (int)DiscountType.DirectDiscount ? c.Product.Price - cp.Coupon.Discount
                                : c.Product.Price
                            )
                        .FirstOrDefault(), 1)
                        :c.Product.Price,
            }) 
            .ToListAsync();

        int totalWithoutDiscount = productDtos.Sum(p => p.Price);
        productDtos.Add(new LinePayProductDto
        {
            Name = "運費和折扣",
            Quantity = 1,
            Price = CalculateTotalAmount(totalWithoutDiscount, shipmentMethodDto)- totalWithoutDiscount
        });

        return productDtos;
    }

    private static List<PackageDto> PutProductsIntoPackage(List<LinePayProductDto> productDtos, ShipmentMethodDto shipment)
    {
        int totalAmount = productDtos.Select(p => p.Price).Sum();

        int finalTotalAmount = CalculateTotalAmount(totalAmount, shipment);

        List<PackageDto> packageDtos = new List<PackageDto>();
        packageDtos.Add(new PackageDto
        {
            Amount = totalAmount,
            Products = productDtos
        });

        return packageDtos;
    }

    private static int CalculateTotalAmount(int amount, ShipmentMethodDto shipment)
    {
        int shippingCost = 0;

        if (shipment.Method != "payFirstAtHome" && shipment.Method != "payAtHome")
        {
            shippingCost = 60;
        }
        else
        {
            shippingCost = 80;
        }

        int total = amount > 2000 ? amount : amount + shippingCost;
        total = total > 3000 ? total - 300 : total;

        return total;
    }


    private static PaymentRequestDto CreatePaymentRequest(List<PackageDto> packageDtos, ShipmentMethodDto shipment)
    {
        //Mapping to paymentRequestDto
        PaymentRequestDto? paymentRequestDto = new PaymentRequestDto
        {
            Amount = packageDtos.Select(p => p.Amount).Sum(),
            OrderId = Guid.NewGuid().ToString(),    //todo => 先建訂單，傳Index到OrderId
            Packages = packageDtos,
            RedirectUrls = new RedirectUrlsDto()
        };
        return paymentRequestDto;
    }
}

public class ShipmentMethodDto 
{
    public string Method { get; set; } = string.Empty;
}


