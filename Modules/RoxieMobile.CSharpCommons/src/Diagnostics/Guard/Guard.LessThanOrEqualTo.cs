﻿using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Checks that the parameter value is less than or equal to the maximum value.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The parameter value.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void LessThanOrEqualTo<T>(T value, T max, string? message = null)
            where T : notnull, IComparable<T>
        {
            if (TryIsFailure(() => Check.LessThanOrEqualTo(value, max), out var cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that the parameter value is less than or equal to the maximum value.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="value">The parameter value.</param>
        /// <param name="max">The maximum.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void LessThanOrEqualTo<T>(T value, T max, Func<string> block)
            where T : notnull, IComparable<T>
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.LessThanOrEqualTo(value, max), out var cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}
