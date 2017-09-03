using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using RoxieMobile.CSharpCommons.DataAnnotations.Legacy;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class StringExtension
    {
// MARK: - Methods

        [Obsolete(Constants.WriteADescription)]
        public static bool IsEmpty(this string value) =>
            string.IsNullOrEmpty(value);

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotEmpty(this string value) =>
            !value.IsEmpty();

        [Obsolete(Constants.WriteADescription)]
        public static bool IsBlank(this string value) =>
            string.IsNullOrWhiteSpace(value);

        [Obsolete(Constants.WriteADescription)]
        public static bool IsNotBlank(this string value) =>
            !value.IsBlank();

        [Obsolete(Constants.CodeRefactoringIsRequired)]
        public static T ToEnum<T>(this string source)
        {
            var enumType = typeof(T);
            foreach (var value in Enum.GetValues(enumType)) {

                var stringValue = value.ToString();
                var attributeValue = enumType
                    .GetField(stringValue)
                    .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                    .Cast<EnumMemberAttribute>()
                    .Select(a => a.Value)
                    .SingleOrDefault() ?? stringValue;

                if (string.Equals(source, attributeValue, StringComparison.OrdinalIgnoreCase)) {
                    return (T) value;
                }
            }

            // Done
            throw new ArgumentException($"The value ‘{source}’ is not supported.");
        }
    }
}