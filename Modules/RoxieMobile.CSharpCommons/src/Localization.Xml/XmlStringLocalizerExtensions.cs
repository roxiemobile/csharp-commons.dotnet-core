using System.Collections.Generic;
using Microsoft.Extensions.Localization;
using RoxieMobile.CSharpCommons.Diagnostics;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    public static class XmlStringLocalizerExtensions
    {
        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="stringLocalizer">The <see cref="IXmlStringLocalizer"/>.</param>
        /// <param name="name">The name of the string resource.</param>
        /// <returns>The string resource as a <see cref="LocalizedString"/>.</returns>
        public static LocalizedString GetString(
            this IXmlStringLocalizer stringLocalizer,
            string name)
        {
            Guard.NotNull(stringLocalizer, Funcs.Null(nameof(stringLocalizer)));
            Guard.NotNull(name, Funcs.Null(nameof(name)));

            return stringLocalizer[name];
        }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="stringLocalizer">The <see cref="IXmlStringLocalizer"/>.</param>
        /// <param name="name">The name of the string resource.</param>
        /// <param name="arguments">The values to format the string with.</param>
        /// <returns>The formatted string resource as a <see cref="LocalizedString"/>.</returns>
        public static LocalizedString GetString(
            this IXmlStringLocalizer stringLocalizer,
            string name,
            params object[] arguments)
        {
            Guard.NotNull(stringLocalizer, Funcs.Null(nameof(stringLocalizer)));
            Guard.NotNull(name, Funcs.Null(nameof(name)));

            return stringLocalizer[name, arguments];
        }

        /// <summary>
        /// Gets all string resources including those for parent cultures.
        /// </summary>
        /// <param name="stringLocalizer">The <see cref="IXmlStringLocalizer"/>.</param>
        /// <returns>The string resources.</returns>
        public static IEnumerable<LocalizedString> GetAllStrings(this IXmlStringLocalizer stringLocalizer)
        {
            Guard.NotNull(stringLocalizer, Funcs.Null(nameof(stringLocalizer)));

            return stringLocalizer.GetAllStrings(includeParentCultures: true);
        }
    }
}