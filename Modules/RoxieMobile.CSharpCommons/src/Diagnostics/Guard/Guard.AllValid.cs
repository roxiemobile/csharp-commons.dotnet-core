using System;
using RoxieMobile.CSharpCommons.Abstractions.Models;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Checks that all an objects in array is not <c>null</c> and valid.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void AllValid(IValidatable[] objects, string message = null)
        {
            if (TryIsFailure(() => Check.AllValid(objects), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that all an objects in array is not <c>null</c> and valid.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void AllValid(IValidatable[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllValid(objects), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}