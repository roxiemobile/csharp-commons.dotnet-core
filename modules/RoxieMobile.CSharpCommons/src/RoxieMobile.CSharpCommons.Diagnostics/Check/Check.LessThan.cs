﻿using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        /// <summary>
        /// Checks that the parameter value is less than the maximum value, otherwise throws an <see cref="CheckException"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <param name="value">The parameter value</param>
        /// <param name="max">The maximum</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay)</param>
        /// <exception cref="CheckException" />
        public static void LessThan<T>(T value, T max, string message = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(max) >= 0) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that the parameter value is less than the maximum value, otherwise throws an <see cref="CheckException"/>.
        /// </summary>
        /// <typeparam name="T">The type of the parameter</typeparam>
        /// <param name="value">The parameter value</param>
        /// <param name="max">The maximum</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/></param>
        /// <exception cref="ArgumentNullException" />
        /// <exception cref="CheckException" />
        public static void LessThan<T>(T value, T max, Func<string> block)
            where T : IComparable<T>
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (value.CompareTo(max) >= 0) {
                throw NewCheckException(block());
            }
        }
    }
}