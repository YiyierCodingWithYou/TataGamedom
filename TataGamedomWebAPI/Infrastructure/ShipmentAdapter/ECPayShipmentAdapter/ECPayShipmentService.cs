using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.LogisticsSelection;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Response;

namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.ECPayShipmentAdapter;

public class ECPayShipmentService
{
    private readonly string HashKey = "5294y06JbISpM5x9";
    private readonly string HashIV = "v77hoKGq4kWxNNIS";
    private readonly string BaseAPIUrl = "https://logistics-stage.ecpay.com.tw/Express";

    private static readonly HttpClient _httpClient;
    static ECPayShipmentService()
    {
        _httpClient = new HttpClient();
    }

    /// <summary>
    /// 開啟物流選擇頁
    /// </summary>
    /// <param name="logisticsSelection"></param>
    /// <returns></returns>
    public async Task<string?> SendLogisticsSelectionRequest(LogisticsSelectionRawDataDto logisticsSelection)
    {
        var requestJson = JsonSerializer.Serialize(new LogisticsSelectionRequestDto
        {
            RqHeader = new(),
            Data = ComputeEncodedLogisticsSelectionData(logisticsSelection)
        });

        var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAPIUrl}/v2/RedirectToLogisticsSelection")
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        var responseJson = await _httpClient.SendAsync(request);

        return await responseJson.Content.ReadAsStringAsync();          // Todo 解碼response data
    }

    /// <summary>
    /// 綠界傳回值格式:URL query string  
    /// 成功: 1| Response參數
    /// 失敗: 0| ErrorMessage
    /// 交易訊息代碼 105000___ 自訂錯誤代碼
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task<Dictionary<string, string>> SendLogisticsOrderForPickUpRequest(LogisticsOrderRequestDto order)
    {
        using FormUrlEncodedContent content = new FormUrlEncodedContent(ComputeOrderRequestData(order));
        HttpResponseMessage response = await _httpClient.PostAsync($"{BaseAPIUrl}/Create", content);
        string responseBody = await response.Content.ReadAsStringAsync();

        ThrowExceptionIfBadRequest(response, responseBody);

        NameValueCollection responseValues = HttpUtility.ParseQueryString(responseBody.Split('|')[1]);
        Dictionary<string, string> data = responseValues.AllKeys.ToDictionary(k => k!, k => responseValues[k]!);

        //ThrowExceptionIfCheckMacValueNotMatch(responseValues, data);    //加入OrderId後再打開
        
        return data;
    }

    private string ComputeEncodedLogisticsSelectionData(LogisticsSelectionRawDataDto logisticsSelection)
    {
        var encodedData = HttpUtility.UrlEncode(JsonSerializer.Serialize(logisticsSelection));
        byte[] key = Encoding.UTF8.GetBytes(HashKey);
        byte[] iv = Encoding.UTF8.GetBytes(HashIV);
        byte[] encrypted = AESEncryptStringToBytes(encodedData, key, iv);
        return Convert.ToBase64String(encrypted);
    }

    static byte[] AESEncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
    {
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException(nameof(plainText));
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException(nameof(Key));
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException(nameof(IV));

        byte[] encrypted;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            encrypted = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(plainText), 0, plainText.Length);
        }

        return encrypted;
    }

    /// <summary>
    /// 建立物流訂單-B2C及宅配
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private Dictionary<string, string> ComputeOrderRequestData(LogisticsOrderRequestDto order)
    {
        var orderDict = new Dictionary<string, string>
        {
            { "MerchantID", order.MerchantID },
            { "MerchantTradeNo", order.MerchantTradeNo },   //可為null，不可重複，但有給的話demo蠻好辨識的
            { "MerchantTradeDate", order.MerchantTradeDate},
            { "LogisticsType", order.LogisticsType},
            { "LogisticsSubType", order.LogisticsSubType},  //B2C接受參數: FAMI、UNIMART、HILIFE、UNIMARTFREEZE
            { "GoodsAmount", order.GoodsAmount.ToString() },  // todo 跟11確定總額&運費算法
            { "SenderName", order.SenderName},
            { "SenderCellPhone ", order.SenderCellPhone},
            { "ReceiverName", order.ReceiverName },  //todo 從購物車取memberInfo
            { "ReceiverCellPhone", order.ReceiverCellPhone },   //todo 從購物車取memberInfo
            { "ReceiverEmail", order.ReceiverEmail }, // todo?
            { "ServerReplyURL", order.ServerReplyURL},//localhost:3000/Orders" }, //todo ngrok
            { "ReceiverStoreID", order.ReceiverStoreID },  //todo 收件人門市代號，看能不能從11弄的db取  / 7-ELEVEN 超商：131386 7-ELEVEN 超商冷凍店取：896539 全家：006598 OK：1328
            //{ "ClientReplyURL", ""},  可以導覽前端頁面，目前採幕後建物流訂單，先不填。 todo => 寫一個有值得給LinePay用，目前LinePay沒物流
        };

        orderDict["CheckMacValue"] = GetCheckMacValue(orderDict);

        return orderDict;
    }

    /// <summary>
    /// 綠界加密規定: https://developers.ecpay.com.tw/?p=7424  
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private string GetCheckMacValue(Dictionary<string, string> order)
    {
        var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
        var checkValue = string.Join("&", param);

        checkValue = $"HashKey={HashKey}" + "&" + checkValue + $"&HashIV={HashIV}";
        checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

        return CalculateMD5Hash(checkValue).ToUpper();
    }

    private string CalculateMD5Hash(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "");
    }

    #region Exception
    private static void ThrowExceptionIfBadRequest(HttpResponseMessage response, string responseBody)
    {
        if (response.IsSuccessStatusCode == false || responseBody.StartsWith("0|") || responseBody.StartsWith("105000"))
        {
            throw new BadRequestException(responseBody);
        };
    }

    private void ThrowExceptionIfCheckMacValueNotMatch(NameValueCollection responseValues, Dictionary<string, string> data)
    {
        if (responseValues["CheckMacValue"] != GetCheckMacValue(data))
        {
            throw new BadRequestException($@"
綠界回傳參數與傳入參數不符:
檢查碼[CheckMacValue]:{GetCheckMacValue(data)}
傳回值: {responseValues}");
        }
    }
    #endregion
}
