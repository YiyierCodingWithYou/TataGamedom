namespace TataGamedomWebAPI.Application.Contracts.ChatService;

public interface IChatService
{
   Task ReceiveMessage(string account, string messageContent, string memberName);
   Task ReceivePrivateMessage(string messageContent, string messageContent1, int notificationCounter, string receiverAccount);
}
