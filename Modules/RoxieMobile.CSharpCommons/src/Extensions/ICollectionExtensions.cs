using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class ICollectionExtensions
    {
// MARK: - Methods: Generic Collection

        /// <summary>
        /// Casts a specified collection to an <see cref="ICollection{T}"/> interface.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to cast.</param>
        /// <returns>A collection casted to an <see cref="ICollection{T}"/> interface.</returns>
        public static ICollection<T> AsCollection<T>(this ICollection<T> collection) =>
            collection;
    }
}
