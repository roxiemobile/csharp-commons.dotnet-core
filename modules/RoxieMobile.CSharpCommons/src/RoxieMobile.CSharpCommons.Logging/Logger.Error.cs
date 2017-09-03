using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "ClassCannotBeInstantiated")]
    public sealed partial class Logger
    {
// MARK: - Methods

        public static void E(string tag, string message)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, message);
            }
        }

        public static void E(string tag, Func<string> message)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, message());
            }
        }

        public static void E(Type type, string message)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(type.Name, message);
            }
        }

        public static void E(Type type, Func<string> message)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(type.Name, message());
            }
        }

// MARK: - Methods

        public static void E(string tag, string message, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, message, exception);
            }
        }

        public static void E(string tag, Func<string> message, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, message(), exception);
            }
        }

        public static void E(Type type, string message, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(type.Name, message, exception);
            }
        }

        public static void E(Type type, Func<string> message, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(type.Name, message(), exception);
            }
        }

// MARK: - Methods

        public static void E(string tag, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(tag, exception);
            }
        }

        public static void E(Type type, Exception exception)
        {
            if (IsLoggable(LogLevel.Error)) {
                Shared.GetLogger()?.E(type.Name, exception);
            }
        }
    }
}