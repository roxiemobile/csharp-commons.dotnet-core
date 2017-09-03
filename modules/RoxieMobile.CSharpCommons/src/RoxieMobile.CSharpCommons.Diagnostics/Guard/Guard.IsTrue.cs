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
        /// Checks that a condition is true. If it isn't it throws an <see cref="GuardError"/> with the given message.
        /// </summary>
        /// <param name="condition">Condition to be checked</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay)</param>
        /// <exception cref="GuardError" />
        public static void IsTrue(bool condition, string message = null)
        {
            if (TryIsFailure(() => Check.IsTrue(condition), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that a condition is true. If it isn't it throws an <see cref="GuardError"/> with the given message.
        /// </summary>
        /// <param name="condition">Condition to be checked</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="GuardError" />
        public static void IsTrue(bool condition, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.IsTrue(condition), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}