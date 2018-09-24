using System;
using System.Linq;
using System.Runtime.Serialization;

// Using EnumMemberAttribute and doing automatic string conversions
// @link https://stackoverflow.com/a/10418943
// @link https://github.com/smartcommunitylab/scwp.support/blob/master/CommonHelpers/EnumConverter.cs

namespace RoxieMobile.CSharpCommons.Extensions
{
    public static class EnumExtensions
    {
// MARK: - Methods

        /// <summary>
        /// Retrieve the string corresponding to the enum value for the given type.
        /// </summary>
        /// <param name="value">Enumerator's value</param>
        /// <returns>A string representation of an Enumerator's value.</returns>
        public static string ToEnumString(this Enum value)
        {
            var stringValue = value.ToString();
            return value
                .GetType()
                .GetField(stringValue)
                .GetCustomAttributes(typeof(EnumMemberAttribute), true)
                .Cast<EnumMemberAttribute>()
                .Select(a => a.Value)
                .SingleOrDefault() ?? stringValue;
        }
    }
}