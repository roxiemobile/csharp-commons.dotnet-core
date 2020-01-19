using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace RoxieMobile.CSharpCommons.Lang
{
    /// <summary>
    /// An exception that should not be silently handled and logged.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
    public class Error : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class.
        /// </summary>
        public Error()
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public Error(string? message)
            : base(message)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the <paramref name="innerException"/> parameter is not a <c>null</c> reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public Error(string? message, Exception? innerException)
            : base(message, innerException)
        {}

        /// <summary>
        /// Initializes a new instance of the <see cref="Error"/> class with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.</param>
        public Error(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {}
    }
}
