using System;
using System.Collections;
using System.Collections.Generic;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ICollectionExtensions
    {
// MARK: - Methods: Generic Collection

        [Obsolete(Constants.WriteADescription)]
        public static bool IsEmpty<T>(this ICollection<T> obj) =>
            (obj == null) || (obj.Count < 1);

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotEmpty<T>(this ICollection<T> obj) =>
            !obj.IsEmpty();

// MARK: - Methods: Collection

        [Obsolete(Constants.WriteADescription)]
        public static bool IsEmpty(this ICollection obj) =>
            (obj == null) || (obj.Count < 1);

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotEmpty(this ICollection obj) =>
            !obj.IsEmpty();
    }
}