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

        [Obsolete(Constants.WriteADescription)]
        public static void Empty(string value, string message = null)
        {
            if (!value.IsEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty(string value, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!value.IsEmpty()) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Array

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(T[] array, string message = null)
        {
            if (!array.IsEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(T[] array, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!array.IsEmpty()) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Collection

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(ICollection<T> collection, string message = null)
        {
            if (!collection.IsEmpty()) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void Empty<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!collection.IsEmpty()) {
                throw NewCheckException(block());
            }
        }
    }
}