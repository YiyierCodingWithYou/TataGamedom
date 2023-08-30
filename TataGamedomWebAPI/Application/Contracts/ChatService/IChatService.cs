namespace TataGamedomWebAPI.Application.Contracts.ChatService;

public interface IChatService
{
   Task ReceiveMessage(string account, string messageContent, string memberName);

}
