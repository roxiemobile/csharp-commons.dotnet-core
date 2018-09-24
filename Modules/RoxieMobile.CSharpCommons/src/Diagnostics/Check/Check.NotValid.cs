using System;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that an object is not <c>null</c> and not valid.
        /// </summary>
        /// <param name="obj">Object to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotValid(IValidatable obj, string message = null)
        {
            if (!obj?.IsNotValid() ?? true) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that an object is not <c>null</c> and not valid.
        /// </summary>
        /// <param name="obj">Object to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotValid(IValidatable obj, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!obj?.IsNotValid() ?? true) {
                throw NewCheckException(block());
            }
        }
    }
}