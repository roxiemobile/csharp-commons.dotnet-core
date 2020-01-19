using System;
using System.Collections.Generic;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Checks that all a string objects in collection is <c>null</c> or empty.
        /// </summary>
        /// <param name="collection">A collection of strings.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void AllEmpty(IEnumerable<string?>? collection, string? message = null)
        {
            if (TryIsFailure(() => Check.AllEmpty(collection), out var cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that all a string objects in collection is <c>null</c> or empty.
        /// </summary>
        /// <param name="collection">A collection of strings.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void AllEmpty(IEnumerable<string?>? collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllEmpty(collection), out var cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}
