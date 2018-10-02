using System;
using System.Collections.Generic;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods: String

        /// <summary>
        /// Checks that a string is not <c>null</c> and not empty.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotEmpty(string value, string message = null)
        {
            if (!value.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that a string is not <c>null</c> and not empty.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotEmpty(string value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!value.IsNotEmpty()) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Array

        /// <summary>
        /// Checks that an array is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="array">The array to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(T[] array, string message = null)
        {
            if (!array.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that an array is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="array">The array to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(T[] array, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!array.IsNotEmpty()) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Generic Collection

        /// <summary>
        /// Checks that a collection is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(ICollection<T> collection, string message = null)
        {
            if (!collection.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that a collection is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The collection to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!collection.IsNotEmpty()) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Read-Only Generic Collection

        /// <summary>
        /// Checks that a read-only collection is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The read-only collection to check or <c>null</c>.</param>
        /// <param name="message">The identifying message for the <see cref="CheckException"/> (<c>null</c> okay).</param>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(IReadOnlyCollection<T> collection, string message = null)
        {
            if (!collection.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        /// <summary>
        /// Checks that a read-only collection is not <c>null</c> and not empty.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="collection">The read-only collection to check or <c>null</c>.</param>
        /// <param name="block">The function which returns identifying message for the <see cref="CheckException"/>.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <see cref="block"/> is <c>null</c>.</exception>
        /// <exception cref="CheckException" />
        public static void NotEmpty<T>(IReadOnlyCollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!collection.IsNotEmpty()) {
                throw NewCheckException(block());
            }
        }
    }
}