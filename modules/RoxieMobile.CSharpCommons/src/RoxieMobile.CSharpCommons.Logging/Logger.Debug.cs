using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "ClassCannotBeInstantiated")]
    public sealed partial class Logger
    {
// MARK: - Methods

        public static void D(string tag, string message)
        {
            if (IsLoggable(LogLevel.Debug)) {
                Shared.GetLogger()?.D(tag, message);
            }
        }

        public static void D(string tag, Func<string> message)
        {
            if (IsLoggable(LogLevel.Debug)) {
                Shared.GetLogger()?.D(tag, message());
            }
        }

        public static void D(Type type, string message)
        {
            if (IsLoggable(LogLevel.Debug)) {
                Shared.GetLogger()?.D(type.Name, message);
            }
        }

        public static void D(Type type, Func<string> message)
        {
            if (IsLoggable(LogLevel.Debug)) {
                Shared.GetLogger()?.D(type.Name, message());
            }
        }
    }
}