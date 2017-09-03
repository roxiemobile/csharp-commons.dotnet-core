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
        /// Checks that two objects are equal. If they are not, an <see cref="CheckException"/> is thrown
        /// with the given message. If <c>expected</c> and <c>actual</c> are <c>null</c>, they are considered equal. 
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <param name="actual">Actual value</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay)</param>
        /// <exception cref="CheckException" />
        public static void Equal(object expected, object actual, string message = null)
        {
            if (!Equals(expected, actual)) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that two objects are equal. If they are not, an <see cref="CheckException"/> is thrown
        /// with the given message. If <c>expected</c> and <c>actual</c> are <c>null</c>, they are considered equal. 
        /// </summary>
        /// <param name="expected">Expected value</param>
        /// <param name="actual">Actual value</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CheckException" />
        public static void Equal(object expected, object actual, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!Equals(expected, actual)) {
                throw NewCheckException(block());
            }
        }
    }
}