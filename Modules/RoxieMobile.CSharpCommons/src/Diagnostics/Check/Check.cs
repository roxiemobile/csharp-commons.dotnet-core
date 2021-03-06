using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// These methods can be used directly: `Check.isTrue(...)`.
    /// </summary>
    [DebuggerStepThrough]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
        public static CheckException NewCheckException(string? message, Exception? innerException = null) =>
            string.IsNullOrWhiteSpace(message)
                ? new CheckException(innerException)
                : new CheckException(message, innerException);

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class with a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
        public static CheckException NewCheckException(Exception? innerException = null) =>
            new CheckException(innerException);
    }
}
