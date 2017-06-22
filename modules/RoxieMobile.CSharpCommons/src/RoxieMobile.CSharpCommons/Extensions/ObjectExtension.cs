using System;
using RoxieMobile.CSharpCommons.Diagnostics;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ObjectExtension
    {
// MARK: - Methods

        public static T Tap<T>(this T source, Action<T> actionHandler)
        {
            Require.RequireNotNull(actionHandler, $"{nameof(actionHandler)} is null");

            actionHandler(source);
            return source;
        }
    }
}
