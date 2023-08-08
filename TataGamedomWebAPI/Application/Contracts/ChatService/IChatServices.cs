namespace TataGamedomWebAPI.Application.Contracts.ChatService;

public interface IChatServices
{
   Task SendMessage(string userName, string messageContent);
}
