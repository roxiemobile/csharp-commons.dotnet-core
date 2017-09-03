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

        [Obsolete(Constants.WriteADescription)]
        public static void Empty(string value, string message = null)
        {
            if (TryIsFailure(() => Check.Empty(value), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty(string value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Empty(value), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Array

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(T[] array, string message = null)
        {
            if (TryIsFailure(() => Check.Empty(array), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(T[] array, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Empty(array), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Generic Collection

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(ICollection<T> collection, string message = null)
        {
            if (TryIsFailure(() => Check.Empty(collection), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Empty(collection), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}