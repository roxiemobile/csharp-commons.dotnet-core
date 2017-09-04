using System;
using System.Collections.Generic;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods: String

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty(string value, string message = null)
        {
            if (!value.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.NotImplemented)]
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

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(T[] array, string message = null)
        {
            if (!array.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.NotImplemented)]
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

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(ICollection<T> collection, string message = null)
        {
            if (!collection.IsNotEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.NotImplemented)]
        public static void NotEmpty<T>(ICollection<T> collection, Func<string> block)
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