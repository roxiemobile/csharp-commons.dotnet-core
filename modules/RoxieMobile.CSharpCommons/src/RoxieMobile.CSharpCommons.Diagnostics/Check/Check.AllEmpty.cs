using System;
using System.Linq;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        [Obsolete(Constants.WriteADescription)]
        public static void AllEmpty(string[] values, string message = null)
        {
            if (!TryAllEmpty(values)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void AllEmpty(string[] values, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllEmpty(values)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllEmpty(string[] values) =>
            values.IsEmpty() || values.All(s => s.IsEmpty());
    }
}