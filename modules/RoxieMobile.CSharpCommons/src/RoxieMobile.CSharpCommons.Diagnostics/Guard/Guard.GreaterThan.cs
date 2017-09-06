using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Checks that the parameter value is greater than the minimum value, otherwise throws an <see cref="GuardError"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <param name="value">The parameter value</param>
        /// <param name="min">The minimum</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay)</param>
        /// <exception cref="GuardError" />
        public static void GreaterThan<T>(T value, T min, string message = null)
            where T : IComparable<T>
        {
            if (TryIsFailure(() => Check.GreaterThan(value, min), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that the parameter value is greater than the minimum value, otherwise throws an <see cref="GuardError"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <param name="value">The parameter value</param>
        /// <param name="min">The minimum</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="GuardError" />
        public static void GreaterThan<T>(T value, T min, Func<string> block)
            where T : IComparable<T>
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.GreaterThan(value, min), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}