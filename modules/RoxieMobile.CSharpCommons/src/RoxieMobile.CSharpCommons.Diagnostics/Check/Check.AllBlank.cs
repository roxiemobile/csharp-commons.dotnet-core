using System;
using System.Linq;
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
        /// Checks that all a string objects in array is <c>null</c>, empty or contains only whitespace characters.
        /// </summary>
        /// <param name="values">An array of string objects.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void AllBlank(string[] values, string message = null)
        {
            if (!TryAllBlank(values)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that all a string objects in array is <c>null</c>, empty or contains only whitespace characters.
        /// </summary>
        /// <param name="values">An array of string objects.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
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