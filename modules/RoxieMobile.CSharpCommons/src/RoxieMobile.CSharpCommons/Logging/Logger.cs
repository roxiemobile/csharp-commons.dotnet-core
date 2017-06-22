using System;

namespace RoxieMobile.CSharpCommons.Logging
{
    public sealed class Logger
    {
// MARK: - Construction

        public static Logger Shared => LazyInstance.Value;

        private static readonly Lazy<Logger> LazyInstance = new Lazy<Logger>(() => new Logger());

        private Logger() {}

// MARK: - Properties

        public Logger SetLogger(IContract logger)
        {
            lock (_syncLock) {
                _logger = logger;
            }
            return this;
        }

        private IContract GetLogger()
        {
            lock (_syncLock) {
                return _logger;
            }
        }

        public Logger SetLogLevel(LogLevel level)
        {
            lock (_syncLock) {
                _logLevel = level;
            }
            return this;
        }

        public LogLevel GetLogLevel()
        {
            lock (_syncLock) {
                return _logLevel;
            }
        }

// MARK: - Methods

        public static void V(string tag, string msg)
        {
            if (IsLoggable(LogLevel.Verbose)) {
                Shared.GetLogger()?.V(tag, msg);
            }
        }

        public static void D(string tag, string msg)
        {
            if (IsLoggable(LogLevel.Debug)) {
                Shared.GetLogger()?.D(tag, msg);
            }
        }

        public static void I(string tag, string msg)
        {
            if (IsLoggable(LogLevel.Information)) {
                Shared.GetLogger()?.I(tag, msg);
            }
        }

        public static void W(string tag, string msg)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, msg);
            }
        }

        public static void W(string tag, string msg, Exception exc)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, msg, exc);
            }
        }

        public static void W(string tag, Exception exc)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, exc);
            }
        }

        public static void E(string tag, string msg)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, msg);
            }
        }

        public static void E(string tag, string msg, Exception exc)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, msg, exc);
            }
        }

        public static void E(string tag, Exception exc)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, exc);
            }
        }

// MARK: - Methods

        public static bool IsLoggable(LogLevel level)
        {
            return level >= Shared.GetLogLevel();
        }

// MARK: - Inner Types

        public interface IContract
        {
            void V(string tag, string msg);
            void D(string tag, string msg);
            void I(string tag, string msg);
            void W(string tag, string msg);
            void W(string tag, string msg, Exception exc);
            void W(string tag, Exception exc);
            void E(string tag, string msg);
            void E(string tag, string msg, Exception exc);
            void E(string tag, Exception exc);
        }

        public enum LogLevel
        {
            // Use Logger.V()
            Verbose,
            // Use Logger.D()
            Debug,
            // Use Logger.I()
            Information,
            // Use Logger.W()
            Warning,
            // Use Logger.E()
            Error,
            // Turn off all logging
            Suppress
        }

// MARK: - Variables

        private IContract _logger;

        private LogLevel _logLevel = LogLevel.Information;

        private readonly object _syncLock = new object();
    }
}
