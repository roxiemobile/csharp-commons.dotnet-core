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

        [Obsolete(Strings.WriteADescription)]
        public static void LessThanOrEqualTo<TValue>(TValue value, TValue max, string message = null)
            where TValue : IComparable<TValue>
        {
            if (TryIsFailure(() => Check.LessThanOrEqualTo(value, max), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void LessThanOrEqualTo<TValue>(TValue value, TValue max, Func<string> block)
            where TValue : IComparable<TValue>
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.LessThanOrEqualTo(value, max), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}