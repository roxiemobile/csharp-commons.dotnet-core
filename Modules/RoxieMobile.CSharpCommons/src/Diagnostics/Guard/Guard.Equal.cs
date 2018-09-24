using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Checks that two objects are equal. If <c>expected</c> and <c>actual</c> are <c>null</c>, they are considered equal. 
        /// </summary>
        /// <param name="expected">Expected object to check.</param>
        /// <param name="actual">The object to check against <see cref="expected"/>.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void Equal(object expected, object actual, string message = null)
        {
            if (TryIsFailure(() => Check.Equal(expected, actual), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that two objects are equal. If <c>expected</c> and <c>actual</c> are <c>null</c>, they are considered equal. 
        /// </summary>
        /// <param name="expected">Expected object to check.</param>
        /// <param name="actual">The object to check against <see cref="expected"/>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void Equal(object expected, object actual, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Equal(expected, actual), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}