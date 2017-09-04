using System;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class ArrayExtensions
    {
        [Obsolete(Strings.WriteADescription)]
        public static bool IsEmpty<T>(this T[] array) =>
            (array == null) || (array.Length < 1);

        [Obsolete(Strings.WriteADescription)]
        public static bool IsNotEmpty<T>(this T[] array) =>
            !array.IsEmpty();
    }
}