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

        [Obsolete(Strings.WriteADescription)]
        public static void AllBlank(string[] values, string message = null)
        {
            if (!TryAllBlank(values)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllBlank(string[] values, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllBlank(values)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllBlank(string[] values) =>
            values.IsEmpty() || values.All(s => s.IsBlank());
    }
}