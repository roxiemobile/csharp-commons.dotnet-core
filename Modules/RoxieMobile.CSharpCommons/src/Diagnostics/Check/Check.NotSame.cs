using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that two objects do not refer to the same object.
        /// </summary>
        /// <param name="unexpected">Unexpected object to check.</param>
        /// <param name="actual">The object to compare to <see cref="unexpected"/>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotSame(object? unexpected, object? actual, string? message = null)
        {
            if (ReferenceEquals(unexpected, actual)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that two objects do not refer to the same object.
        /// </summary>
        /// <param name="unexpected">Unexpected object to check.</param>
        /// <param name="actual">The object to compare to <see cref="unexpected"/>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotSame(object? unexpected, object? actual, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (ReferenceEquals(unexpected, actual)) {
                throw NewCheckException(block());
            }
        }
    }
}
