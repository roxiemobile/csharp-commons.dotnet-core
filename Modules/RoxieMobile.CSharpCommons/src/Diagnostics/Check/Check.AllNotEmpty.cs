using System;
using System.Collections.Generic;
using System.Linq;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that all a string objects in collection is not <c>null</c> and not empty.
        /// </summary>
        /// <param name="collection">A collection of strings.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void AllNotEmpty(IEnumerable<string?>? collection, string? message = null)
        {
            if (!TryAllNotEmpty(collection)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that all a string objects in collection is not <c>null</c> and not empty.
        /// </summary>
        /// <param name="collection">A collection of strings.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void AllNotEmpty(IEnumerable<string?>? collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNotEmpty(collection)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllNotEmpty(IEnumerable<string?>? collection) =>
            (collection == null) || collection.All(s => s.IsNotEmpty());
    }
}
