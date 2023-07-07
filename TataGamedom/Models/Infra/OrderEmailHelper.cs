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
		public override void SendFromGmail(string from, string to, string subject, string body)
		{
			var smtpAccount = from;

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
				client.Credentials = new NetworkCredential(smtpAccount, smtpPassword);
				client.Send(mms);
			}
		}
	}
}