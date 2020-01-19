using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

// Elysium-Extra/Source/Framework/Guard 
// @link https://github.com/RehanSaeed/Elysium-Extra/tree/master/Source/Framework/Guard

// ImageSharp/src/ImageSharp/Common/Helpers
// @link https://github.com/SixLabors/ImageSharp/tree/master/src/ImageSharp/Common/Helpers

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// These methods can be used directly: `Guard.isTrue(...)`.
    /// </summary>
    [DebuggerStepThrough]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static partial class Guard
    {
// MARK: - Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class with a specified error message and a reference to the inner exception that is the cause of this error.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the error.</param>
        /// <param name="innerException">The exception that is the cause of the current error, or a <c>null</c> reference if no inner exception is specified.</param>
        public static GuardError NewGuardError(string? message, Exception? innerException = null) =>
            string.IsNullOrWhiteSpace(message)
                ? new GuardError(innerException)
                : new GuardError(message, innerException);

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class with a reference to the inner exception that is the cause of this error.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current error, or a <c>null</c> reference if no inner exception is specified.</param>
        public static GuardError NewGuardError(Exception? innerException = null) =>
            new GuardError(innerException);

// MARK: - Private Methods

        private static bool TryIsFailure(Action block, out Exception? cause)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            cause = null;
            try {
                block();
            }
            catch (CheckException e) {
                cause = e;
            }

            return (cause != null);
        }
    }
}
