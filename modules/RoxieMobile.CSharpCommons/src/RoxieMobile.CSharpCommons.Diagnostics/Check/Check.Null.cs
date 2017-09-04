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
        /// Checks that an object is null. If it is not, an <see cref="CheckException"/> is thrown with the given message.
        /// </summary>
        /// <param name="reference">Object to check or <c>null</c></param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay)</param>
        /// <exception cref="CheckException" />
        public static void Null(object reference, string message = null)
        {
            if (reference != null) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that an object is null. If it is not, an <see cref="CheckException"/> is thrown with the given message.
        /// </summary>
        /// <param name="reference">Object to check or <c>null</c></param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CheckException" />
        public static void Null(object reference, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (reference != null) {
                throw NewCheckException(block());
            }
        }
    }
}