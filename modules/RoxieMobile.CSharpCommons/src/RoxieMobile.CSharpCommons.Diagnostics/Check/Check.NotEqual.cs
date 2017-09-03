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
        /// Checks that two objects are <b>not</b> equals. If they are, an <see cref="CheckException"/> is thrown
        /// with the given message. If <code>unexpected</code> and <c>actual</c> are <c>null</c>,
        /// they are considered equal.
        /// </summary>
        /// <param name="unexpected">Unexpected value to check</param>
        /// <param name="actual">The value to check against <c>unexpected</c></param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay)</param>
        /// <exception cref="CheckException" />
        public static void NotEqual(object unexpected, object actual, string message = null)
        {
            if (Equals(unexpected, actual)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that two objects are <b>not</b> equals. If they are, an <see cref="CheckException"/> is thrown
        /// with the given message. If <code>unexpected</code> and <c>actual</c> are <c>null</c>,
        /// they are considered equal.
        /// </summary>
        /// <param name="unexpected">Unexpected value to check</param>
        /// <param name="actual">The value to check against <c>unexpected</c></param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CheckException" />
        public static void NotEqual(object unexpected, object actual, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (Equals(unexpected, actual)) {
                throw NewCheckException(block());
            }
        }
    }
}