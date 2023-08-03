using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TataGamedomWebAPI.Infrastructure
{
	public class HashUtility
	{
		private readonly IConfiguration _configuration;

		public HashUtility(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string ToSHA256(string plainText)
		{
			string salt = _configuration["AppSettings:Salt"];

			if (salt == null)
			{
				throw new InvalidOperationException("AppSettings:Salt is not configured.");
				// 或者使用預設值
				// salt = "default-salt-value";
			}
			// 或者您也可以使用 GetSection 方法來讀取設定值
			// string salt = _configuration.GetSection("AppSettings")["Salt"];

			using (var mySHA256 = SHA256.Create())
			{
				var passwordBytes = Encoding.UTF8.GetBytes(salt + plainText);
				var hash = mySHA256.ComputeHash(passwordBytes);
				var sb = new StringBuilder();
				foreach (var b in hash) sb.Append(b.ToString("X2"));

				return sb.ToString();
			}
		}
		//public static string ToSHA256(string plainText, string salt)
		//{
		//	// ref https://docs.microsoft.com/zh-tw/dotnet/api/system.security.cryptography.sha256?view=net-6.0
		//	using (var mySHA256 = SHA256.Create())
		//	{
		//		var passwordBytes = Encoding.UTF8.GetBytes(salt + plainText);
		//		var hash = mySHA256.ComputeHash(passwordBytes);
		//		var sb = new StringBuilder();
		//		foreach (var b in hash) sb.Append(b.ToString("X2"));

		//		return sb.ToString();
		//	}
		//}

		//public static string GetSalt()
		//{
		//	return System.Configuration.ConfigurationManager.AppSettings["Salt"];
		//}
	}
}
