using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace RoxieMobile.CSharpCommons.Extensions
{
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class StringExtension
    {
// MARK: - Methods

        /// <summary>
        /// Checks that a string is <c>null</c> or empty.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="value"/> is <c>null</c> or empty.</returns>
        public static bool IsEmpty([NotNullWhen(false)] this string? value) =>
            string.IsNullOrEmpty(value);

        /// <summary>
        /// Checks that a string is not <c>null</c> and not empty.
        /// </summary>
        /// <param name="value">The string to check or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="value"/> is not <c>null</c> and not empty.</returns>
        public static bool IsNotEmpty([NotNullWhen(true)] this string? value) =>
            !value.IsEmpty();

        /// <summary>
        /// Checks that a string is <c>null</c>, empty or contains only whitespace characters.
        /// </summary>
        /// <param name="value">The string to test or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="value"/> is null or empty, or if <paramref name="value"/> contains only whitespace characters.</returns>
        public static bool IsBlank([NotNullWhen(false)] this string? value) =>
            string.IsNullOrWhiteSpace(value);

        /// <summary>
        /// Checks that a string is not <c>null</c>, not empty and contains not only whitespace characters.
        /// </summary>
        /// <param name="value">The string to test or <c>null</c>.</param>
        /// <returns><c>true</c> if the <paramref name="value"/> is not null, not empty, and if <paramref name="value"/> contains not only whitespace characters.</returns>
        public static bool IsNotBlank([NotNullWhen(true)] this string? value) =>
            !value.IsBlank();

        /// <summary>Returns the given string if it is non <c>null</c>; the empty string otherwise.</summary>
        public static string NullToEmpty(this string? source) =>
            source ?? string.Empty;

        /// <summary>
        /// Converts the string representation of the name or attribute value of one or more enumerated constants to an equivalent enumerated object.
        /// </summary>
        /// <typeparam name="TEnum">An enumeration type.</typeparam>
        /// <param name="source">A string containing the name or attribute value to convert.</param>
        /// <returns>An object of type <typeparamref name="TEnum"/> whose value is represented by <paramref name="source"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="source"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="source"/> is a name, but not one of the named constants defined for the enumeration.</exception>
        [return: NotNull]
        public static TEnum ToEnum<TEnum>(this string source)
        {
            if (source == null) {
                throw new ArgumentNullException(nameof(source));
            }

            var enumType = typeof(TEnum);
            foreach (var enumValue in Enum.GetValues(enumType).OfType<TEnum>()) {

                var stringValue = enumValue!.ToString().NullToEmpty();
                if (stringValue.IsEmpty()) {
                    continue;
                }

                var attributeValue = enumType
                    .GetField(stringValue)?
                    .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .Cast<EnumMemberAttribute>()
                    .Select(a => a.Value)
                    .SingleOrDefault() ?? stringValue;

                if (string.Equals(source, attributeValue, StringComparison.OrdinalIgnoreCase)) {
                    return enumValue;
                }
            }

            // Not found
            throw new ArgumentException($"The value ‘{source}’ is not supported.");
        }
    }
}
