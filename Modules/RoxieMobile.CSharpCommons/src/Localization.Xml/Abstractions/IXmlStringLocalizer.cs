using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;

// ReSharper disable once CheckNamespace
namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Represents a service that provides localized strings from XML files.
    /// </summary>
    public interface IXmlStringLocalizer
    {
        /// <summary>
        /// Gets the string resource with the given name.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <returns>The string resource as a <see cref="LocalizedString"/>.</returns>
        LocalizedString this[string name] { get; }

        /// <summary>
        /// Gets the string resource with the given name and formatted with the supplied arguments.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <param name="arguments">The values to format the string with.</param>
        /// <returns>The formatted string resource as a <see cref="LocalizedString"/>.</returns>
        LocalizedString this[string name, params object[] arguments] { get; }

        /// <summary>
        /// Gets all string resources.
        /// </summary>
        /// <param name="includeParentCultures">
        /// A <see cref="System.Boolean"/> indicating whether to include strings from parent cultures.
        /// </param>
        /// <returns>The strings.</returns>
        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);

        /// <summary>
        /// Creates a new <see cref="IXmlStringLocalizer"/> for a specific <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="CultureInfo"/> to use.</param>
        /// <returns>A culture-specific <see cref="IXmlStringLocalizer"/>.</returns>
        IXmlStringLocalizer WithCulture(CultureInfo culture);
    }
}