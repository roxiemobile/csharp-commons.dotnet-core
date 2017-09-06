using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class IEnumerableExtension
    {
// MARK: - Methods: Generic Enumerable

        /// <summary>
        /// Checks that a sequence is <c>null</c> or not contains any elements. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="sequence">The sequence to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="sequence"/> is <c>null</c> or not contains any elements.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> sequence) =>
            !sequence?.Any() ?? true;

        /// <summary>
        /// Checks that a sequence is not <c>null</c> and contains any elements. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="sequence">The sequence to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="sequence"/> is not <c>null</c> and contains any elements.</returns>
        public static bool IsNotEmpty<T>(this IEnumerable<T> sequence) =>
            !sequence.IsEmpty();

// MARK: - Methods: Enumerable

        /// <summary>
        /// Checks that a sequence is <c>null</c> or not contains any elements. 
        /// </summary>
        /// <param name="sequence">The sequence to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="sequence"/> is <c>null</c> or not contains any elements.</returns>
        public static bool IsEmpty(this IEnumerable sequence) =>
            !sequence?.Cast<object>().Any() ?? true;

        /// <summary>
        /// Checks that a sequence is not <c>null</c> and contains any elements. 
        /// </summary>
        /// <param name="sequence">The sequence to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="sequence"/> is not <c>null</c> and contains any elements.</returns>
        public static bool IsNotEmpty(this IEnumerable sequence) =>
            !sequence.IsEmpty();
    }
}