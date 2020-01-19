using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class IReadOnlyCollectionExtensions
    {
// MARK: - Methods: Read-Only Generic Collection

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
