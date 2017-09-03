using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// Thrown to indicate that an validation has failed.
    /// </summary>
    [Obsolete("Extend from uncatchable exception")]
    public sealed class GuardError : Exception
    {
// MARK: - Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class.
        /// </summary>
        public GuardError()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public GuardError(string message)
            : base(message)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class with a specified error message and a reference to the inner exception that is the cause of this error.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the error.</param>
        /// <param name="innerException">The exception that is the cause of the current error, or a <c>null</c> reference if no inner exception is specified.</param>
        public GuardError(string message, Exception innerException)
            : base(message, innerException)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardError"/> class with a reference to the inner exception that is the cause of this error.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current error, or a <c>null</c> reference if no inner exception is specified.</param>
        public GuardError(Exception innerException)
            : base(null, innerException)
        {}
    }
}