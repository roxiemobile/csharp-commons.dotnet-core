using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "ClassCannotBeInstantiated")]
    public sealed partial class Logger
    {
// MARK: - Methods

        public static void W(string tag, string message)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, message);
            }
        }

        public static void W(string tag, Func<string> message)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, message());
            }
        }

        public static void W(Type type, string message)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(type.Name, message);
            }
        }

        public static void W(Type type, Func<string> message)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(type.Name, message());
            }
        }

// MARK: - Methods

        public static void W(string tag, string message, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, message, exception);
            }
        }

        public static void W(string tag, Func<string> message, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, message(), exception);
            }
        }

        public static void W(Type type, string message, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(type.Name, message, exception);
            }
        }

        public static void W(Type type, Func<string> message, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(type.Name, message(), exception);
            }
        }

// MARK: - Methods

        public static void W(string tag, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(tag, exception);
            }
        }

        public static void W(Type type, Exception exception)
        {
            if (IsLoggable(LogLevel.Warning)) {
                Shared.GetLogger()?.W(type.Name, exception);
            }
        }
    }
}
