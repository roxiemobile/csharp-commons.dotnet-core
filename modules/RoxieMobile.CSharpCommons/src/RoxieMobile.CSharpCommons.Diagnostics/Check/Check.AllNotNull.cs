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

        [Obsolete(Constants.WriteADescription)]
        public static void AllNotNull<T>(T[] objects, string message = null)
        {
            if (!TryAllNotNull(objects)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void AllNotNull<T>(T[] objects, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNotNull(objects)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Methods: Generic Collection

        [Obsolete(Constants.WriteADescription)]
        public static void AllNotNull<T>(ICollection<T> collection, string message = null)
        {
            if (!TryAllNotNull(collection)) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void AllNotNull<T>(ICollection<T> collection, Func<string> block)
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (!TryAllNotNull(collection)) {
                throw NewCheckException(block());
            }
        }

// MARK: - Private Methods

        private static bool TryAllNotNull<T>(T[] objects) =>
            objects.IsEmpty() || objects.All(o => o != null);

        private static bool TryAllNotNull<T>(ICollection<T> collection) =>
            collection.IsEmpty() || collection.All(o => o != null);
    }
}