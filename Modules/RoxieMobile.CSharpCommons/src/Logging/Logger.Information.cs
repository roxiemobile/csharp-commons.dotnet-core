using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "ClassCannotBeInstantiated")]
    public sealed partial class Logger
    {
// MARK: - Methods

        public static void I(string tag, string message)
        {
            if (IsLoggable(LogLevel.Information)) {
                Shared.GetLogger()?.I(tag, message);
            }
        }

        public static void I(string tag, Func<string> message)
        {
            if (IsLoggable(LogLevel.Information)) {
                Shared.GetLogger()?.I(tag, message());
            }
        }

        public static void I(Type type, string message)
        {
            if (IsLoggable(LogLevel.Information)) {
                Shared.GetLogger()?.I(type.Name, message);
            }
        }

        public static void I(Type type, Func<string> message)
        {
            if (IsLoggable(LogLevel.Information)) {
                Shared.GetLogger()?.I(type.Name, message());
            }
        }
    }
}