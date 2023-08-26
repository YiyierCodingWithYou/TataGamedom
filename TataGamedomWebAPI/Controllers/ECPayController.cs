using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Cors;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.ECPayShipmentAdapter;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.LogisticsSelection;
using TataGamedomWebAPI.Infrastructure.ShipmentAdapter.Dtos.Request.QueryLogisticsTradeInfo;

namespace TataGamedomWebAPI.Controllers
{
    [EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class ECPayController : ControllerBase
	{
		private readonly ECPayShipmentService _shipmentService;
        public ECPayController()
        {
            _shipmentService = new ECPayShipmentService();
        }

        [HttpPost("Create")]
		public async Task<ActionResult<Dictionary<string, string>>> CreatePayment(int total)
		{
			var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
			//需填入你的網址
			var website = $"https://localhost:3000";
			Dictionary<string, string> order = new Dictionary<string, string>
			{
				//綠界需要的參數
				{ "MerchantTradeNo",  orderId},
				{ "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
				{ "TotalAmount",  total.ToString()},
				{ "TradeDesc",  "無"},
				{ "ItemName",  "獺獺玩國商品一批"},
				{ "ReturnURL",  $"{website}/Orders"},
				{ "ClientBackURL", $"{website}/Cart?paymentSuccess=true" },
				{ "MerchantID",  "3002607"},
				{ "PaymentType",  "aio"},
				{ "ChoosePayment",  "ALL"},
				{ "EncryptType",  "1"},
				//{"OrderResultURL", "https://4601-61-222-34-1.ngrok-free.app/cart" }
			};
			order["CheckMacValue"] = GetCheckMacValue(order);
			return Ok(order);
		}
		private string GetCheckMacValue(Dictionary<string, string> order)
		{
			var param = order.Keys.OrderBy(x => x).Select(key => key + "=" + order[key]).ToList();

			var checkValue = string.Join("&", param);
			//測試用的 HashKey
			var hashKey = "pwFHCqoQZGmho4w6";
			//測試用的 HashIV
			var HashIV = "EkRm7iFT261dpevs";
			checkValue = $"HashKey={hashKey}" + "&" + checkValue + $"&HashIV={HashIV}";
			checkValue = HttpUtility.UrlEncode(checkValue).ToLower();
			checkValue = GetSHA256(checkValue);
			return checkValue.ToUpper();
		}
		private string GetSHA256(string value)
		{
			var result = new StringBuilder();
			var sha256 = System.Security.Cryptography.SHA256.Create();
			var bts = Encoding.UTF8.GetBytes(value);
			var hash = sha256.ComputeHash(bts);
			for (int i = 0; i < hash.Length; i++)
			{
				result.Append(hash[i].ToString("X2"));
			}
			return result.ToString();
		}


        [HttpPost("LogisticsSelection")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> RedirectToLogisticsSelection(LogisticsSelectionRawDataDto logisticsSelection)
        {
            var fileUrl = await _shipmentService.SendLogisticsSelectionRequest(logisticsSelection);
            return Ok(new { url = fileUrl });
        }

        [HttpPost("LogisticsOrder")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CreateLogisticsOrderForPickUp(LogisticsOrderRequestDto order) 
		{
			return Ok(await _shipmentService.SendLogisticsOrderForPickUpRequest(order));
		}

        [HttpPost("LogisticsTradeInfo")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> QueryLogisticsTradeInfo(QueryLogisticsTradeInfoDto tradeInfo)
        {
            return Ok(await _shipmentService.SendLogisticsTradeInfoQueryRequest(tradeInfo));
        }
    }

}
