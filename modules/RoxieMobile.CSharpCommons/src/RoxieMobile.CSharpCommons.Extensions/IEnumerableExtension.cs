using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class IEnumerableExtension
    {
// MARK: - Methods: Generic Enumerable

        [Obsolete(Constants.WriteADescription)]
        public static bool IsEmpty<T>(this IEnumerable<T> obj) =>
            (obj == null) || !obj.Any();

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotEmpty<T>(this IEnumerable<T> obj) =>
            !obj.IsEmpty();

// MARK: - Methods: Enumerable

        [Obsolete(Constants.WriteADescription)]
        public static bool IsEmpty(this IEnumerable obj) =>
            (obj == null) || !obj.Cast<object>().Any();

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotEmpty(this IEnumerable obj) =>
            !obj.IsEmpty();
    }
}