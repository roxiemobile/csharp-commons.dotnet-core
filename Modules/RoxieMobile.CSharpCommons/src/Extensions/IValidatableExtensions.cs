using RoxieMobile.CSharpCommons.Abstractions.Models;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class IValidatableExtensions
    {
        /// <summary>
        /// Checks that an object is not valid.
        /// </summary>
        /// <param name="obj">Object to check.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> is not valid.</returns>
        public static bool IsNotValid(this IValidatable obj) =>
            !obj.IsValid();

        /// <summary>
        /// Checks that an object is <c>null</c> or valid.
        /// </summary>
        /// <param name="obj">Object to check.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> is <c>null</c> or valid.</returns>
        public static bool IsNullOrValid(this IValidatable? obj) =>
            obj?.IsValid() ?? true;

        /// <summary>
        /// Checks that an object is <c>null</c> or not valid.
        /// </summary>
        /// <param name="obj">Object to check.</param>
        /// <returns><c>true</c> if the <paramref name="obj"/> is <c>null</c> or not valid.</returns>
        public static bool IsNullOrNotValid(this IValidatable? obj) =>
            !obj?.IsValid() ?? true;
    }
}
