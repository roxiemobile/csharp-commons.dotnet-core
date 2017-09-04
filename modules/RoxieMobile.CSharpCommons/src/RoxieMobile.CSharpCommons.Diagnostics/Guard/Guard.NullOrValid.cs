using System;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public partial class Guard
    {
// MARK: - Methods

        [Obsolete(Strings.WriteADescription)]
        public static void NullOrValid(IValidatable obj, string message = null)
        {
            if (TryIsFailure(() => Check.NullOrValid(obj), out Exception cause)) {
                throw NewGuardError(message, cause);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void NullOrValid(IValidatable obj, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (TryIsFailure(() => Check.NullOrValid(obj), out Exception cause)) {
                throw NewGuardError(block(), cause);
            }
        }
    }
}