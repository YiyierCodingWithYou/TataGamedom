using Microsoft.AspNetCore.Mvc;
using System.Collections.Specialized;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Web;
using TataGamedomWebAPI.Application.Exceptions;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.LogisticsSelection;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.QueryLogisticsTradeInfo;
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


    #region 開啟物流選擇頁(url)
    public async Task<string> SendLogisticsSelectionRequest(LogisticsSelectionRawDataDto logisticsSelection)
    {
        var requestJson = JsonSerializer.Serialize(new LogisticsSelectionRequestDto
        {
            RqHeader = new(),
            Data = ComputeEncodedData(logisticsSelection)
        });

        var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAPIUrl}/v2/RedirectToLogisticsSelection")
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(request);


        #region Todo 測試Aes解密，目前遇到responseJson是html頁面，FromBase64String會出問題
        //string responseJson = await response.Content.ReadAsStringAsync();
        //byte[] key = Encoding.UTF8.GetBytes(HashKey);
        //byte[] iv = Encoding.UTF8.GetBytes(HashIV);
        //string decodedAesResponse = DecryptStringFromBytes_Aes(Convert.FromBase64String(responseJson), key, iv);
        //string decodedData = HttpUtility.UrlDecode(decodedAesResponse);
        //Console.WriteLine(decodedData);
        #endregion

        string htmlContent = await response.Content.ReadAsStringAsync();
        
        var guid = Guid.NewGuid().ToString();
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files/LogisticsSelectionHtml", $"{guid}.html");
        await System.IO.File.WriteAllTextAsync(filePath, htmlContent);

        return $"/Files/LogisticsSelectionHtml/{guid}.html";
    }


    // 綠界新版物流 加密規定: https://developers.ecpay.com.tw/?p=10205
    private string ComputeEncodedData<T>(T data)
    {
        var encodedData = HttpUtility.UrlEncode(JsonSerializer.Serialize(data));
        byte[] key = Encoding.UTF8.GetBytes(HashKey);
        byte[] iv = Encoding.UTF8.GetBytes(HashIV);
        byte[] encrypted = EncryptStringToBytes_Aes(encodedData, key, iv);
        return Convert.ToBase64String(encrypted);
    }

    #endregion

    #region 建立物流訂單-B2C及宅配


    // 綠界傳回值格式:URL query string  
    // 成功: 1| Response參數
    // 失敗: 0| ErrorMessage
    // 交易訊息代碼 105000___ 自訂錯誤代碼
    public async Task<Dictionary<string, string>> SendLogisticsOrderForPickUpRequest(LogisticsOrderRequestDto order)
    {
        using FormUrlEncodedContent content = new FormUrlEncodedContent(ComputeOrderRequestData(order));
        HttpResponseMessage response = await _httpClient.PostAsync($"{BaseAPIUrl}/Create", content);
        string responseBody = await response.Content.ReadAsStringAsync();

        ThrowExceptionIfBadRequest(response, responseBody);

        NameValueCollection responseValues = HttpUtility.ParseQueryString(responseBody.Split('|')[1]);
        Dictionary<string, string> data = responseValues.AllKeys.ToDictionary(k => k!, k => responseValues[k]!);

        ThrowExceptionIfCheckMacValueNotMatch(responseValues, data);    //加入OrderId後再打開

        return data;
    }

    private Dictionary<string, string> ComputeOrderRequestData(LogisticsOrderRequestDto order)
    {
        var orderDict = new Dictionary<string, string>
        {
            { "MerchantID", order.MerchantID },
            { "MerchantTradeNo", order.MerchantTradeNo },   //目前從前端傳回新建訂單的OrderIndex
            { "MerchantTradeDate", order.MerchantTradeDate},
            { "LogisticsType", order.LogisticsType},
            { "LogisticsSubType", order.LogisticsSubType},  //B2C接受參數: FAMI、UNIMART、HILIFE、UNIMARTFREEZE
            { "GoodsAmount", order.GoodsAmount.ToString() },
            { "SenderName", order.SenderName},
            { "SenderCellPhone ", order.SenderCellPhone},
            { "ReceiverName", order.ReceiverName },
            { "ReceiverCellPhone", order.ReceiverCellPhone },   //todo 從購物車取memberInfo
            { "ReceiverEmail", order.ReceiverEmail }, // todo?
            { "ServerReplyURL", order.ServerReplyURL},//localhost:3000/Orders" }, //todo ngrok
            { "ReceiverStoreID", order.ReceiverStoreID },// 7-ELEVEN 超商：131386 7-ELEVEN 超商冷凍店取：896539 全家：006598 OK：1328
            //{ "ClientReplyURL", ""},  可以導覽前端頁面，目前採幕後建物流訂單，先不填。 todo => 寫一個有值的給LinePay用，目前LinePay沒物流
        };

        orderDict["CheckMacValue"] = GetCheckMacValue(orderDict);

        return orderDict;
    }


    // 綠界舊版物流 雜湊規定: https://developers.ecpay.com.tw/?p=7424  
    private string GetCheckMacValue(Dictionary<string, string> order)
    {
        var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();
        var checkValue = string.Join("&", param);

        checkValue = $"HashKey={HashKey}" + "&" + checkValue + $"&HashIV={HashIV}";
        checkValue = HttpUtility.UrlEncode(checkValue).ToLower();

        return CalculateMD5Hash(checkValue).ToUpper();
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

    #endregion

    #region 查詢物流訂單
    public async Task<QueryLogisticsTradeInfoResponseDto?> SendLogisticsTradeInfoQueryRequest(QueryLogisticsTradeInfoDto tradeInfoDto)
    {
        var requestJson = JsonSerializer.Serialize(new
        {
            PlatformID = string.Empty,
            MerchantID = "2000132",
            RqHeader = new RqHeader(),
            Data = ComputeEncodedData(tradeInfoDto)
        });

        var request = new HttpRequestMessage(HttpMethod.Post, $"{BaseAPIUrl}/v2/QueryLogisticsTradeInfo")
        {
            Content = new StringContent(requestJson, Encoding.UTF8, "application/json")
        };

        var response = await _httpClient.SendAsync(request);

        using var responseStream = await response.Content.ReadAsStreamAsync();
        QueryLogisticsTradeInfoResponseDto? tradeInfo = await JsonSerializer.DeserializeAsync<QueryLogisticsTradeInfoResponseDto>(responseStream);
        tradeInfo.DecodedData = DecodeAes(tradeInfo);

        return tradeInfo;
    }

    private TradeInfoResponseData DecodeAes(QueryLogisticsTradeInfoResponseDto? tradeInfo)
    {
        byte[] key = Encoding.UTF8.GetBytes(HashKey);
        byte[] iv = Encoding.UTF8.GetBytes(HashIV);
        string decodedAesResponse = DecryptStringFromBytes_Aes(Convert.FromBase64String(tradeInfo.Data), key, iv);
        string decodedData = HttpUtility.UrlDecode(decodedAesResponse);
        
        Console.WriteLine(decodedData);
        var dataObject = JsonSerializer.Deserialize<TradeInfoResponseData>(decodedData);
        return dataObject;
    }   
    #endregion

    #region Aes 加密/解密
    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
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

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }
        }

        return encrypted;
    }

    static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));
        if (Key == null || Key.Length <= 0)
            throw new ArgumentNullException(nameof(Key));
        if (IV == null || IV.Length <= 0)
            throw new ArgumentNullException(nameof(IV));

        string? plaintext = null;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        return plaintext;
    }
    #endregion

    #region MD5 雜湊
    private string CalculateMD5Hash(string input)
    {
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = System.Security.Cryptography.MD5.HashData(inputBytes);
        return BitConverter.ToString(hashBytes).Replace("-", "");
    }

    #endregion



}
