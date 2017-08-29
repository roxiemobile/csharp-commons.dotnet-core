using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class StringExtension
    {
// MARK: - Methods

        [Obsolete("Code refactoring needed")]
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
            throw new ArgumentException($"The value '{source}' is not supported.");
        }
    }
}
