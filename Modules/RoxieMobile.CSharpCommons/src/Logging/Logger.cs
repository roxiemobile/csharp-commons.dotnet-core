using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public sealed partial class Logger
    {
// MARK: - Construction

        public static Logger Shared => _instance.Value;

        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        private Logger()
        {}

// MARK: - Properties

        public Logger SetLogger(IContract? logger)
        {
            lock (_syncLock) {
                _logger = logger;
            }
            return this;
        }

        private IContract? GetLogger()
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

        private IContract? _logger;

        private LogLevel _logLevel = LogLevel.Information;

        private readonly object _syncLock = new object();
    }
}
