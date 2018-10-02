using System;
using System.Collections.Generic;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods: Array

        /// <summary>
        /// Checks that all an objects in array is <c>null</c>.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(T[] objects, string message = null)
        {
            if (TryIsFailure(() => Check.AllNull(objects), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that all an objects in array is <c>null</c>.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(T[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllNull(objects), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Generic Collection

        /// <summary>
        /// Checks that all an objects in collection is <c>null</c>.
        /// </summary>
        /// <param name="collection">A collection of objects.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(ICollection<T> collection, string message = null)
        {
            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that all an objects in collection is <c>null</c>.
        /// </summary>
        /// <param name="collection">A collection of objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Read-Only Generic Collection

        /// <summary>
        /// Checks that all an objects in read-only collection is <c>null</c>.
        /// </summary>
        /// <param name="collection">A read-only collection of objects.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(IReadOnlyCollection<T> collection, string message = null)
        {
            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that all an objects in read-only collection is <c>null</c>.
        /// </summary>
        /// <param name="collection">A read-only collection of objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void AllNull<T>(IReadOnlyCollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}