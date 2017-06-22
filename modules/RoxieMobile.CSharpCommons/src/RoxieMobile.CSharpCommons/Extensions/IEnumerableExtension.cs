using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class IEnumerableExtension
    {
// MARK: - Methods

        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            return source == null || !source.Cast<object>().Any();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
    }
}
