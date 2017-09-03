using System;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class IValidatableExtensions
    {
        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotValid(this IValidatable obj) =>
            obj != null && !obj.IsValid();

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNullOrValid(this IValidatable obj) =>
            obj == null || obj.IsValid();

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNullOrNotValid(this IValidatable obj) =>
            obj == null || !obj.IsValid();
    }
}