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
// MARK: - Methods: Array

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(T[] objects, string message = null)
        {
            if (TryIsFailure(() => Check.AllNull(objects), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(T[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllNull(objects), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }

// MARK: - Methods: Generic Collection

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(ICollection<T> collection, string message = null)
        {
            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.AllNull(collection), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}