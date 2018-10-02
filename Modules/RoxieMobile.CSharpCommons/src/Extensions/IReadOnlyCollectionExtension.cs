using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "ArrangeRedundantParentheses")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class IReadOnlyCollectionExtensions
    {
// MARK: - Methods: Read-Only Generic Collection

        /// <summary>
        /// Checks that a read-only collection is <c>null</c> or empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The read-only collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty<T>(this IReadOnlyCollection<T> collection) =>
            (collection == null) || (collection.Count < 1);

        /// <summary>
        /// Checks that a read-only collection is not <c>null</c> and not empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The read-only collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty<T>(this IReadOnlyCollection<T> collection) =>
            !collection.IsEmpty();

        /// <summary>
        /// Casts a specified collection to an <see cref="IReadOnlyCollection{T}"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to cast.</param>
        /// <returns>A collection casted to an <see cref="IReadOnlyCollection{T}"/> interface.</returns>
        public static IReadOnlyCollection<T> AsReadOnlyCollection<T>(this IReadOnlyCollection<T> collection) =>
            collection;
    }
}