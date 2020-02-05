using System;

namespace Framework.Logging
{
    public interface ILogger
    {
        void Debug(string message);
        void Error(string message);
        void Error(string message, Exception ex);
        void Fatal(string message);
        void Info(string message);
        void Warn(string message);
    }
}