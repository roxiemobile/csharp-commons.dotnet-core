using System;
using System.Collections.Generic;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Guard
    {
// MARK: - Methods: String

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty(string value, string message = null)
        {
            if (TryIsFailure(() => Check.NotEmpty(value), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty(string value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.NotEmpty(value), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Array

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(T[] array, string message = null)
        {
            if (TryIsFailure(() => Check.NotEmpty(array), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(T[] array, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.NotEmpty(array), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Generic Collection

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(ICollection<T> collection, string message = null)
        {
            if (TryIsFailure(() => Check.NotEmpty(collection), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.NotEmpty(collection), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}