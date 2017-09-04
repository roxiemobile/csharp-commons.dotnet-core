using System;
using System.Collections.Generic;
using System.Linq;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;
using RoxieMobile.CSharpCommons.Extensions;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods: Array

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(T[] objects, string message = null)
        {
            if (!TryAllNull(objects)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(T[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNull(objects)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Generic Collection

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(ICollection<T> collection, string message = null)
        {
            if (!TryAllNull(collection)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Strings.WriteADescription)]
        public static void AllNull<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNull(collection)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllNull<T>(T[] objects) =>
            objects.IsEmpty() || objects.All(o => o == null);

        private static bool TryAllNull<T>(ICollection<T> collection) =>
            collection.IsEmpty() || collection.All(o => o == null);
    }
}