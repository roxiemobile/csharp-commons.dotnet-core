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
        /// <param name="source">Enumerator's value.</param>
        /// <returns>A string representation of an Enumerator's value.</returns>
        public static string ToEnumString(this Enum source)
        {
            var stringValue = source.ToString();
            return source
                .GetType()
                .GetField(stringValue)?
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .Cast<EnumMemberAttribute>()
                .Select(a => a.Value)
                .SingleOrDefault() ?? stringValue;
        }
    }
}
