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
        /// Checks that two objects refer to the same object. If they are not, an <see cref="GuardError"/>
        /// is thrown with the given message.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The object to compare to <c>expected</c></param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay)</param>
        /// <exception cref="GuardError" />
        public static void Same(object expected, object actual, string message = null)
        {
            if (TryIsFailure(() => Check.Same(expected, actual), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that two objects refer to the same object. If they are not, an <see cref="GuardError"/>
        /// is thrown with the given message.
        /// </summary>
        /// <param name="expected">The expected object</param>
        /// <param name="actual">The object to compare to <c>expected</c></param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="GuardError" />
        public static void Same(object expected, object actual, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Same(expected, actual), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}