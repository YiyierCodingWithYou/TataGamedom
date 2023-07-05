using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Security.Policy;
using System.Web.Helpers;

namespace TataGamedom.Models.Infra
{
	public class OrderEmailHelper : EmailHelper
	{
		private string senderEmail = "apalan60@gmail.com";  /*"TataGamedom @gmail.com"*///;
		public void SendEmail(string trackingNum, string name, string email)
		{
			var subject = "[訂購商品已出貨]";
			var body = $@"Hi {name}, 您訂購的商品已出貨，貨態追蹤代碼為 {trackingNum} ,再麻煩您留意取貨訊息";

			var from = senderEmail;
			var to = /*email*/"TataGamedom @gmail.com";

			SendFromGmail(from, to, subject, body);
		}
		public virtual void SendFromGmail(string from, string to, string subject, string body)
		{
			// todo 以下是開發時,測試之用, 只是建立text file, 不真的寄出信
			//var path = HttpContext.Current.Server.MapPath("~/files/Mails");
			//CreateTextFile(path, from, to, subject, body);
			//return;

			// 以下是實作程式, 可以視需要真的寄出信, 或者只是單純建立text file,供開發時使用
			// ref https://dotblogs.com.tw/chichiblog/2018/04/20/122816
			var smtpAccount = from;

			// TODO 請在這裡填入密碼,或從web.config裡讀取
			var smtpPassword = "pjchjpfhtpfihggj";

			var smtpServer = "smtp.gmail.com";
			var SmtpPort = 587;

			var mms = new MailMessage();
			mms.From = new MailAddress(smtpAccount);
			mms.Subject = subject;
			mms.Body = body;
			mms.IsBodyHtml = true;
			mms.SubjectEncoding = Encoding.UTF8;
			mms.To.Add(new MailAddress(to));

			using (var client = new SmtpClient(smtpServer, SmtpPort))
			{
				client.EnableSsl = true;
				client.Credentials = new NetworkCredential(smtpAccount, smtpPassword);//寄信帳密 
				client.Send(mms); //寄出信件
			}
		}

//		private void CreateTextFile(string path, string from, string to, string subject, string body)
//		{
//			var fileName = $"{to.Replace("@", "_")} {DateTime.Now.ToString("yyyyMMdd_HHmmss")}.txt";
//			var fullPath = Path.Combine(path, fileName);

//			var contents = $@"from:{from}
//to:{to}
//subject:{subject}

//{body}";
//			File.WriteAllText(fullPath, contents, Encoding.UTF8);
//		}
	}
}