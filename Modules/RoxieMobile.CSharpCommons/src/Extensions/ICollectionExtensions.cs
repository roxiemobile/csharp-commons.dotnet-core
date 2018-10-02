using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "ArrangeRedundantParentheses")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ICollectionExtensions
    {
// MARK: - Methods: Generic Collection

        /// <summary>
        /// Checks that a collection is <c>null</c> or empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty<T>(this ICollection<T> collection) =>
            (collection == null) || (collection.Count < 1);

        /// <summary>
        /// Checks that a collection is not <c>null</c> and not empty. 
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty<T>(this ICollection<T> collection) =>
            !collection.IsEmpty();

        /// <summary>
        /// Casts a specified collection to an <see cref="ICollection{T}"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to cast.</param>
        /// <returns>A collection casted to an <see cref="ICollection{T}"/> interface.</returns>
        public static ICollection<T> AsCollection<T>(this ICollection<T> collection) =>
            collection;

// MARK: - Methods: Collection

        /// <summary>
        /// Checks that a collection is <c>null</c> or empty. 
        /// </summary>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty(this ICollection collection) =>
            (collection == null) || (collection.Count < 1);

        /// <summary>
        /// Checks that a collection is not <c>null</c> and not empty. 
        /// </summary>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="collection"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty(this ICollection collection) =>
            !collection.IsEmpty();
    }
}