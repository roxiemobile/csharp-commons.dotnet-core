using System;
using System.Linq;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that all an objects in array is not <c>null</c> and not valid.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void AllNotValid(IValidatable[] objects, string message = null)
        {
            if (!TryAllNotValid(objects)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that all an objects in array is not <c>null</c> and not valid.
        /// </summary>
        /// <param name="objects">An array of objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void AllNotValid(IValidatable[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNotValid(objects)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllNotValid(IValidatable[] objects) =>
            objects.IsEmpty() || objects.All(o => o?.IsNotValid() ?? false);
    }
}