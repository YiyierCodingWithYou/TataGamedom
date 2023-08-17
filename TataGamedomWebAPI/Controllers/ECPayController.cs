using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Request.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter.Dtos.Response.Payment;
using TataGamedomWebAPI.Infrastructure.PaymentAdapter.LinePaymentAdapter;
using TataGamedomWebAPI.Models.DTOs.Cart;
using TataGamedomWebAPI.Infrastructure;
using static System.Net.WebRequestMethods;
using System.Security.Cryptography.Xml;
using System;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace TataGamedomWebAPI.Controllers
{
	[EnableCors("AllowAny")]
	[Route("api/[controller]")]
	[ApiController]
	public class ECPayController : ControllerBase
	{
		///// <summary>
		///// 取得付款資訊
		///// </summary>
		///// <param name="id"></param>
		///// <returns></returns>
		//public ActionResult PayInfo(string id)
		//{
		//	var cache = MemoryCache.Default;
		//	var cacheData = cache.Get(id);
		//	var dataStr = JsonConvert.SerializeObject(cacheData);
		//	var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataStr);
		//	return View("EcpayView", data);
		//}

		///// <summary>
		///// 取得虛擬帳號 資訊
		///// </summary>
		///// <param name="id"></param>
		///// <returns></returns>
		//public ActionResult AccountInfo(string id)
		//{
		//	var cache = MemoryCache.Default;
		//	var cacheData = cache.Get(id);
		//	var dataStr = JsonConvert.SerializeObject(cacheData);
		//	var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(dataStr);
		//	return View("EcpayView", data);
		//}
		[HttpPost("Create")]
		public async Task<ActionResult<Dictionary<string, string>>> CreatePayment(int total)
		{
			var orderId = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 20);
			//需填入你的網址
			var website = $"https://localhost:3000";
			var order = new Dictionary<string, string>
			{
				//綠界需要的參數
				{ "MerchantTradeNo",  orderId},
				{ "MerchantTradeDate",  DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")},
				{ "TotalAmount",  total.ToString()},
				{ "TradeDesc",  "無"},
				{ "ItemName",  "獺獺玩國商品一批"},
				{ "ReturnURL",  $"{website}/Cart"},
				{ "MerchantID",  "3002607"},
				{ "PaymentType",  "aio"},
				{ "ChoosePayment",  "ALL"},
				{ "EncryptType",  "1"},
			};
			order["CheckMacValue"] = GetCheckMacValue(order);

			//呼叫綠界API

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
	}

}
