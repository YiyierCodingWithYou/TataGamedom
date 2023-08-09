namespace TataGamedomWebAPI.Application.Contracts.ChatService;

public interface IChatService
{
   Task SendMessage(string userName, string messageContent);
}
