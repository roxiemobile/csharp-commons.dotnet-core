using System;
using System.Linq;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public partial class Check
    {
// MARK: - Methods

        [Obsolete(Strings.WriteADescription)]
        public static void AllValid(IValidatable[] objects, string message = null)
        {
            if (!TryAllValid(objects)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllValid(IValidatable[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllValid(objects)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllValid(IValidatable[] objects) =>
            objects.IsEmpty() || objects.All(s => s?.IsValid() ?? false);
    }
}