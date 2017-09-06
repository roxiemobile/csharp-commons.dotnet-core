﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Verifies that the exact exception or a derived exception type is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the exception expected to be thrown.</typeparam>
        /// <param name="action">A delegate to the code that is expected to throw an exception when executed.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="action"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException">Thrown when an exception was not thrown, or when an exception of the incorrect type is thrown.</exception>
        public static void ThrowsAny<T>(Action action, string message = null)
            where T : Exception
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }

            if (!TryThrowsAny<T>(action, () => message, out CheckException exception)) {
                throw exception;
            }
        }

        /// <summary>
        /// Verifies that the exact exception or a derived exception type is thrown.
        /// </summary>
        /// <typeparam name="T">The type of the exception expected to be thrown.</typeparam>
        /// <param name="action">A delegate to the code that is expected to throw an exception when executed.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="action"/> or <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException">Thrown when an exception was not thrown, or when an exception of the incorrect type is thrown.</exception>
        public static void ThrowsAny<T>(Action action, Func<string> block)
            where T : Exception
        {
            if (action == null) {
                throw new ArgumentNullException(nameof(action));
            }
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryThrowsAny<T>(action, block, out CheckException exception)) {
                throw exception;
            }
        }

// MARK: - Private Methods

        [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
        private static bool TryThrowsAny<T>(Action action, Func<string> block, out CheckException exception)
            where T : Exception
        {
            Exception cause = null;
            exception = null;

            try {
                action.Invoke();
            }
            catch (Exception e) {
                cause = e;
            }
            finally {

                if (cause == null) {
                    var message = block();

                    exception = NewCheckException(message.IsNotEmpty()
                            ? message
                            : $"Expected {typeof(T).Name} to be thrown, but nothing was thrown.",
                        cause);
                }
                else if (!typeof(T).GetTypeInfo().IsAssignableFrom(cause.GetType().GetTypeInfo())) {
                    var message = block();

                    exception = NewCheckException(message.IsNotEmpty()
                            ? message
                            : $"Unexpected exception type thrown. Expected: {typeof(T).Name} but was: {cause.GetType().Name}",
                        cause);
                }
            }

            // Done
            return (exception == null);
        }
    }
}