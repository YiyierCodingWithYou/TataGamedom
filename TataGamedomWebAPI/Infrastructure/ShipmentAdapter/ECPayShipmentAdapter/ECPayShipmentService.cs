using System.Collections.Generic;
using System.Text;
using System.Web;

namespace TataGamedomWebAPI.Infrastructure.ShipmentAdapter.ECPayShipmentAdapter;

public class ECPayShipmentService
{
    private readonly string HashKey = "5294y06JbISpM5x9";
    private readonly string HashIV = "v77hoKGq4kWxNNIS";

    private readonly string MerchantID = "2000132";
    private readonly string MerchantTradeNo = "TataGamedomWeb";
    private readonly string LogisticsType = "CVS";
    private readonly string SenderName = "TataGamedomWeb";
    private readonly string SenderCellPhone = "0916224867";
    private readonly string ReceiverCellPhone = "0916224867";
    private readonly string ReceiverEmail = "tatagamedom@gmail.com";

    /// <summary>
    /// 測試介接資訊: B2C及宅配
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    private Dictionary<string, string> CreateLogisticsOrderForPickUp(Dictionary<string, string> order)
    {
        order = new Dictionary<string, string>
        {
            { "MerchantID", MerchantID },
            { "MerchantTradeNo", MerchantTradeNo },
            { "MerchantTradeDate", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") },
            { "LogisticsType", LogisticsType},
            { "LogisticsSubType", "FAMI"},  //申請類型為B2C，只能串參數為FAMI、UNIMART、HILIFE、UNIMARTFREEZE
            { "GoodsAmount", "100" },  // todo 跟11確定總額&運費算法
            { "SenderName", SenderName},
            { "SenderCellPhone ", SenderCellPhone},
            { "ReceiverName", "lisi" },  //todo 從購物車取memberInfo
            { "ReceiverCellPhone", ReceiverCellPhone },   //todo 從購物車取memberInfo
            { "ReceiverEmail", ReceiverEmail }, // todo?
            { "ServerReplyURL", "https://localhost:3000/Orders" }, //todo ngrok
            { "ReceiverStoreID", order["store_id"] },  //todo 收件人門市代號，看能不能從11弄的db取
            //{ "ClientReplyURL", ""},  可以導覽前端頁面，目前採幕後建物流訂單，先不填。 todo => 寫一個有值得給LinePay用，目前LinePay沒物流
        };

        order["CheckMacValue"] = GetCheckMacValue(order);  //https://developers.ecpay.com.tw/?p=7424  綠界加密規則

        return order;
    }

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
}
