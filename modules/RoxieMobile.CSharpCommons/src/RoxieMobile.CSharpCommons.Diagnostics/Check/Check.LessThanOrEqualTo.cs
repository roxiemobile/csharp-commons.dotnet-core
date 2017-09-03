using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Diagnostics
{
    /// <summary>
    /// A set of methods useful for validating objects states. Only failed checks are throws exceptions.
    /// </summary>
    public static partial class Check
    {
// MARK: - Methods

        [Obsolete(Constants.WriteADescription)]
        public static void LessThanOrEqualTo<TValue>(TValue value, TValue max, string message = null)
            where TValue : IComparable<TValue>
        {
            if (value.CompareTo(max) > 0) {
                throw NewCheckException(message);
            }
        }

        [Obsolete(Constants.WriteADescription)]
        public static void LessThanOrEqualTo<TValue>(TValue value, TValue max, Func<string> block)
            where TValue : IComparable<TValue>
        {
            if (block == null) {
                throw new ArgumentNullException(nameof(block));
            }

            if (value.CompareTo(max) > 0) {
                throw NewCheckException(block());
            }
        }
    }
}