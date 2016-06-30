using System;

namespace Sinina.OnlineShop.Infrastructure.Core.Logging
{
    /// <summary>
    /// Null object pattern logger implementation (logs nothing)
    /// </summary>
    public class NullLogger : ILogger
    {

        /// <summary>
        /// Is debug enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        public bool IsDebugEnabled(string logType)
        {
            return false;
        }

        /// <summary>
        /// Is info enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        public bool IsInfoEnabled(string logType)
        {
            return false;
        }

        /// <summary>
        /// Is warning enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        public bool IsWarnEnabled(string logType)
        {
            return false;
        }

        /// <summary>
        /// Is error enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        public bool IsErrorEnabled(string logType)
        {
            return false;
        }

        /// <summary>
        /// Is fatal enabled ?
        /// </summary>
        /// <param name="logType">log type, category, or logical group</param>
        /// <returns>Is enabled</returns>
        public bool IsFatalEnabled(string logType)
        {
            return false;
        }

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Debug(string message, Exception exception)
        {
        }

        /// <summary>
        /// Log debug message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Debug(string logType, string message, Exception exception)
        {
        }

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Info(string message, Exception exception)
        {
        }

        /// <summary>
        /// Log info message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Info(string logType, string message, Exception exception)
        {
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Warn(string message, Exception exception)
        {
        }

        /// <summary>
        /// Log warning message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Warn(string logType, string message, Exception exception)
        {
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Error(string message, Exception exception)
        {
        }

        /// <summary>
        /// Log error message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Error(string logType, string message, Exception exception)
        {
        }

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Fatal(string message, Exception exception)
        {
        }

        /// <summary>
        /// Log fatal message
        /// </summary>
        /// <param name="logType">log type or logical group</param>
        /// <param name="message">message to log</param>
        /// <param name="exception">exception</param>
        public void Fatal(string logType, string message, Exception exception)
        {
        }
    }
}
