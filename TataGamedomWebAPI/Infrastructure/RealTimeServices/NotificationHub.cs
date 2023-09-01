using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;


namespace TataGamedomWebAPI.Infrastructure.RealTimeServices
{
	public class NotificationHub : Hub
	{
		public async Task SendNotificationToSpecificlMember (string recipientMemberAccount , string relationMemberAccount, string messageContent, int? relationPostId)
		{
			//await Clients.User(recipientMemberAccount).SendAsync("ReceiveNotification", recipientMemberAccount, relationMemberAccount, messageContent, relationPostId);
			await Clients.All.SendAsync("ReceiveNotification", recipientMemberAccount, relationMemberAccount, messageContent, relationPostId);
		}
	}
}
