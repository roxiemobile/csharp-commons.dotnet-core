using System;
using RoxieMobile.CSharpCommons.Lang;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ExceptionExtensions
    {
// MARK: - Methods

        /// <summary>
        /// Checks than an exception should not be handled by logging code.
        /// </summary>
        /// <param name="exception">Exception to test.</param>
        /// <returns><c>true</c> if exception should not be swallowed.</returns>
        public static bool IsCritical(this Exception exception) =>
            exception.IsError() || (exception.InnerException?.IsError() ?? false);

// MARK: - Private Methods

        private static bool IsError(this Exception exception) =>
            exception is SystemException || exception is Error;
    }
}
