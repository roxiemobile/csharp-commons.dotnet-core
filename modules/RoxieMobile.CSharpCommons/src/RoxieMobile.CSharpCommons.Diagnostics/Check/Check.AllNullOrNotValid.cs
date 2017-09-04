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
    public static partial class Check
    {
// MARK: - Methods

        [Obsolete(Strings.WriteADescription)]
        public static void AllNullOrNotValid(IValidatable[] objects, string message = null)
        {
            if (!TryAllNullOrNotValid(objects)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllNullOrNotValid(IValidatable[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNullOrNotValid(objects)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllNullOrNotValid(IValidatable[] objects) =>
            objects.IsEmpty() || objects.All(s => s.IsNullOrNotValid());
    }
}