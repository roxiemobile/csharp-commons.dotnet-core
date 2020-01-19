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
        /// Checks that a string is not <c>null</c>, not empty and contains not only whitespace characters.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="GuardError"/> (<c>null</c> okay).</param>
        /// <exception cref="GuardError" />
        public static void NotBlank(string? value, string? message = null)
        {
            if (TryIsFailure(() => Check.NotBlank(value), out var cause)) {
                throw NewGuardError(message, cause);
            }
        }

        /// <summary>
        /// Checks that a string is not <c>null</c>, not empty and contains not only whitespace characters.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="GuardError"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="GuardError" />
        public static void NotBlank(string? value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.NotBlank(value), out var cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}
