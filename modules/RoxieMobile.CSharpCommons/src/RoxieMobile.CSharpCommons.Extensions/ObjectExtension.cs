using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ObjectExtension
    {
// MARK: - Methods

        [Obsolete(Strings.WriteADescription)]
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