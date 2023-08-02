namespace TataGamedomWebAPI.Application.Contracts.Logging;

public interface IApperLogger<T>
{
    void LogInformation(string message, params object[] args);
    void LogWarning(string message, params object[] args);

}
