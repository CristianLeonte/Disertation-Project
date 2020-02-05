using System;
using System.Reflection;
using log4net;
using log4net.Config;

namespace Framework.Logging
{
    public class Logger : ILogger
    {
        public enum LogType
        {
            ///Click / Write / Clear / Blur / Open / Select
            Action,

            ///Sets an element's property/attr
            Setter,

            Info,

            Error,

            ///Gets an element property/attr
            Getter,

            /// Waits for page to catch up.
            Wait,

            NotDefined
        }
        private const string LogName = "Logger";
        private static ILog _log;
        public Logger()
        {
            try
            {
                XmlConfigurator.Configure();
                _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.ToString());
            }
        }

        public void Debug(string message)
        {
            if (_log.IsDebugEnabled)
            {
                _log.Debug(message);
            }
        }

        public void Error(string message)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
        }
        public void Error(string message, Exception ex)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message, ex);
            }
        }
        public void Fatal(string message)
        {
            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message);
            }
        }

        public void Info(string message)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message);
            }
        }

        public void Warn(string message)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(message);
            }
        }

        public static void Write(string message, LogType logType = LogType.NotDefined)
        {
            var timestampForConsole = DateTime.Now.ToString("yyyy-MM-dd H:mm:ss,fff") + " - ";
            var actionsLogStr = " (act)";   //filter str for writing to Actions log

            switch (logType)
            {
                case LogType.Action:
                case LogType.Setter:
                case LogType.Info:
                    Console.WriteLine(timestampForConsole + message);
                    _log.Info(message + actionsLogStr);      //log to Actions log also
                    break;
                case LogType.Error:
                    Console.WriteLine(timestampForConsole + message);
                    _log.Error(message + actionsLogStr);     //log to Actions log also
                    break;
                case LogType.Getter:
                case LogType.Wait:
                case LogType.NotDefined:
                    _log.Info(message);  //write to FullDetails log also (always)
                    break;
            }
        }

        //Logger.Info($"Run test {MethodBase.GetCurrentMethod().DeclaringType} started");
        //Logger.Info($"Run test {MethodBase.GetCurrentMethod().DeclaringType} finished");
    }
}
