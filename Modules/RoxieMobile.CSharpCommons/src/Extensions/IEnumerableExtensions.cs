using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class IEnumerableExtensions
    {
// MARK: - Methods: Generic Enumerable

        /// <summary>
        /// Checks that a enumeration is <c>null</c> or empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="source">The enumeration to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="source"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty<T>([NotNullWhen(false)] this IEnumerable<T>? source)
        {
            switch (source) {

                case IReadOnlyCollection<T> rcl: {
                    return (rcl.Count < 1);
                }
                case ICollection<T> col: {
                    return (col.Count < 1);
                }
                case string str: {
                    return string.IsNullOrEmpty(str);
                }
                default: {
                    return (source == null) || !source.Any<T>();
                }
            }
        }

        /// <summary>
        /// Checks that a enumeration is not <c>null</c> and not empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="source">The enumeration to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="source"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty<T>([NotNullWhen(true)] this IEnumerable<T>? source) =>
            !source.IsEmpty();

// MARK: - Methods: Enumerable

        /// <summary>
        /// Checks that a enumeration is <c>null</c> or empty. 
        /// </summary>
        /// <param name="source">The enumeration to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="source"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty([NotNullWhen(false)] this IEnumerable? source)
        {
            switch (source) {

                case ICollection col: {
                    return (col.Count < 1);
                }
                case string str: {
                    return string.IsNullOrEmpty(str);
                }
                default: {
                    return (source == null) || !source.Any();
                }
            }
        }

        /// <summary>
        /// Checks that a enumeration is not <c>null</c> and not empty. 
        /// </summary>
        /// <param name="source">The enumeration to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="source"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty([NotNullWhen(true)] this IEnumerable? source) =>
            !source.IsEmpty();

// MARK: - Private Methods

        public static bool Any(this IEnumerable source) =>
            source.GetEnumerator().MoveNext();
    }
}
