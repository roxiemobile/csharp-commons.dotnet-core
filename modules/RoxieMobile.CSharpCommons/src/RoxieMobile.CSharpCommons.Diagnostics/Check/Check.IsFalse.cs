﻿using System;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that a condition is false. If it isn't it throws an <see cref="CheckException"/> with the given message.
        /// </summary>
        /// <param name="condition">Condition to be checked</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay)</param>
        /// <exception cref="CheckException" />
        public static void IsFalse(bool condition, string message = null)
        {
            if (condition) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that a condition is false. If it isn't it throws an <see cref="CheckException"/> with the given message.
        /// </summary>
        /// <param name="condition">Condition to be checked</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CheckException" />
        public static void IsFalse(bool condition, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (condition) {
                throw NewCheckException(block());
            }
        }
    }
}