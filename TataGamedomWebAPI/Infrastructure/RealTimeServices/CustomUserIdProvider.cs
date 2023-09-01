using Microsoft.AspNetCore.SignalR;

namespace TataGamedomWebAPI.Infrastructure.RealTimeServices;

public class CustomUserIdProvider : IUserIdProvider
{
    public string GetUserId(HubConnectionContext connection)
    {
        return connection.User?.Identity?.Name;
    }
}


