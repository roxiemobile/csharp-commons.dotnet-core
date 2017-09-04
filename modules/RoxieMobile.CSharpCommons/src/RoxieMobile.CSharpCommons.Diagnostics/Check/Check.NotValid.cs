using System;
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
        public static void NotValid(IValidatable obj, string message = null)
        {
            if (!obj.IsNotValid()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void NotValid(IValidatable obj, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!obj.IsNotValid()) {
                throw NewCheckException(block());
            }
        }
    }
}