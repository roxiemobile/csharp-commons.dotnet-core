using System;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Logging
{
    [SuppressMessage("ReSharper", "ClassCannotBeInstantiated")]
    public sealed partial class Logger
    {
// MARK: - Methods

        public static void V(string tag, string message)
        {
            if (IsLoggable(LogLevel.Verbose)) {
                Shared.GetLogger()?.V(tag, message);
            }
        }

        public static void V(string tag, Func<string> message)
        {
            if (IsLoggable(LogLevel.Verbose)) {
                Shared.GetLogger()?.V(tag, message());
            }
        }

        public static void V(Type type, string message)
        {
            if (IsLoggable(LogLevel.Verbose)) {
                Shared.GetLogger()?.V(type.Name, message);
            }
        }

        public static void V(Type type, Func<string> message)
        {
            if (IsLoggable(LogLevel.Verbose)) {
                Shared.GetLogger()?.V(type.Name, message());
            }
        }
    }
}