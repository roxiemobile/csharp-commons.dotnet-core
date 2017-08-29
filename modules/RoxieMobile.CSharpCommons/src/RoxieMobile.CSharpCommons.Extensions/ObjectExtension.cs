using System;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ObjectExtension
    {
// MARK: - Methods

        public static T Tap<T>(this T source, Action<T> action)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }

            action(source);
            return source;
        }
    }
}