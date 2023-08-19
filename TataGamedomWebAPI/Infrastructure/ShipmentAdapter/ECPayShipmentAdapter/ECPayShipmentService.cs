using System.Text;
using System.Web;

namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.ECPayShipmentAdapter;

public class ECPayShipmentService
{
    private readonly Dictionary<string, string> _config;
    private static readonly HttpClient httpClient = new();

    public ECPayShipmentService(Dictionary<string, string> config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public async Task<Dictionary<string, string>> CreateOrderAsync(Dictionary<string, string> order)
    {
        var data = CreateOrderData(order);
        var result = await RequestAsync("Create", data);

        if (result != null)
        {
            order["cvs_shipping_code"] = result["RtnCode"];
            order["cvs_shipping_msg"] = result["RtnMsg"];
        }
        return order;
    }

    private Dictionary<string, string> CreateOrderData(Dictionary<string, string> order)
    {
        return new Dictionary<string, string>
        {
            { "MerchantID", _config["MerchantID"] },
            { "MerchantTradeNo", order["order_no"] },
            { "MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") },
            { "LogisticsType", "CVS" },
            { "LogisticsSubType", order["shipment"] },
            { "GoodsAmount", (decimal.Parse(order["amount"]) + decimal.Parse(order["shipping"])).ToString() },
            { "SenderName", _config["SenderName"] },
            { "SenderPhone", _config["SenderPhone"] },
            { "ReceiverName", order["name"] },
            { "ReceiverCellPhone", order["phone"] },
            { "ServerReplyURL", "your_call_back_url" },
            { "ReceiverStoreID", order["store_id"] }
        };
    }

    private async Task<Dictionary<string, string>> RequestAsync(string api, Dictionary<string, string> data)
    {
        data["CheckMacValue"] = Checksum(data);

        using var content = new FormUrlEncodedContent(data);
        var response = await httpClient.PostAsync($"{_config["url"]}{api}", content);
        var responseBody = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode && responseBody.StartsWith("1|"))
        {
            var tokens = responseBody.Split('|');
            var values = HttpUtility.ParseQueryString(tokens[1]);
            var valuesDict = values.AllKeys.ToDictionary(k => k, k => values[k]);

            if (values["CheckMacValue"] == Checksum(valuesDict))
            {
                return valuesDict;
            }
        }

        return null;
    }

    private string Checksum(Dictionary<string, string> data)
    {
        data.Remove("CheckMacValue");
        var sortedData = new SortedDictionary<string, string>(data);
        var sign = "HashKey=" + _config["HashKey"];
        foreach (var item in sortedData)
        {
            sign += $"&{item.Key}={item.Value}";
        }
        sign = Uri.EscapeDataString(sign + "&HashIV=" + _config["HashIV"]);
        sign = ApplyCustomUrlDecoding(sign);
        return CalculateMD5Hash(sign);
    }

    private string ApplyCustomUrlDecoding(string value)
    {
        return value
            .Replace("%20", "+")
            .Replace("%21", "!")
            .Replace("%28", "(")
            .Replace("%29", ")")
            .Replace("%2a", "*")
            .Replace("%2d", "-")
            .Replace("%2e", ".")
            .Replace("%5f", "_");
    }

    private string CalculateMD5Hash(string input)
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        var inputBytes = Encoding.ASCII.GetBytes(input);
        var hashBytes = md5.ComputeHash(inputBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "").ToUpper();
    }
}
