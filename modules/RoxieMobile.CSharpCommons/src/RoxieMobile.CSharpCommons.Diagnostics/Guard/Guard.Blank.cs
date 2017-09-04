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

        [Obsolete(Strings.NotImplemented)]
        public static void Blank(string value, string message = null)
        {
            if (TryIsFailure(() => Check.Blank(value), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.NotImplemented)]
        public static void Blank(string value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Blank(value), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}