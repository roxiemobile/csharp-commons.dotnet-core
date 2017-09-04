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
        public static void Throws(Type expectedException, Action action, string message = null)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }

            if (TryIsFailure(() => Check.Throws(expectedException, action), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void Throws(Type expectedException, Action action, Func<string> block)
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.Throws(expectedException, action), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}