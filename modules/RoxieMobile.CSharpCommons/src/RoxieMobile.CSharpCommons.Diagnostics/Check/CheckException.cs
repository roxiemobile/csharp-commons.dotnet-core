using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// Thrown to indicate that an validation has failed.
    /// </summary>
    public sealed class CheckException : Exception
    {
// MARK: - Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class.
        /// </summary>
        public CheckException()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CheckException(string message)
            : base(message)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
        public CheckException(string message, Exception innerException)
            : base(message, innerException)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckException"/> class with a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="innerException">The exception that is the cause of the current exception, or a <c>null</c> reference if no inner exception is specified.</param>
        public CheckException(Exception innerException)
            : base(null, innerException)
        {}
    }
}