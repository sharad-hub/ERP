namespace ERP.Services
{
    public interface ILoggerService
    {
        void LogError(string message);
        void LogInfo(string message);
        void LogTrace(string message);
    }
}