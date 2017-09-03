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

        [Obsolete(Constants.WriteADescription)]
        public static void NullOrNotValid(IValidatable obj, string message = null)
        {
            if (!obj.IsNullOrNotValid()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void NullOrNotValid(IValidatable obj, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!obj.IsNullOrNotValid()) {
                throw NewCheckException(block());
            }
        }
    }
}