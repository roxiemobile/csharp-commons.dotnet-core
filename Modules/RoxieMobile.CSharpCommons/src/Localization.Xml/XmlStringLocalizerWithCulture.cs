using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Localization.Internal;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Localization.Xml.Internal;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// An <see cref="IXmlStringLocalizer"/> that uses the <see cref="XmlResourceManager"/> and
    /// <see cref="XmlResourceReader"/> to provide localized strings for a specific <see cref="CultureInfo"/>.
    /// </summary>
    public class XmlStringLocalizerWithCulture : XmlStringLocalizer
    {
        private readonly string _resourceBaseName;
        private readonly CultureInfo _culture;

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizerWithCulture"/>.
        /// </summary>
        /// <param name="resourceManager">The <see cref="XmlResourceManager"/> to read strings from.</param>
        /// <param name="resourceStringProvider">The <see cref="IResourceStringProvider"/> that can find the resources.</param>
        /// <param name="baseName">The base name of the embedded resource that contains the strings.</param>
        /// <param name="resourceNamesCache">Cache of the list of strings for a given resource assembly name.</param>
        /// <param name="culture">The specific <see cref="CultureInfo"/> to use.</param>
        internal XmlStringLocalizerWithCulture(
            XmlResourceManager resourceManager,
            IResourceStringProvider resourceStringProvider,
            string baseName,
            IResourceNamesCache resourceNamesCache,
            CultureInfo culture)
            : base(resourceManager, resourceStringProvider, baseName, resourceNamesCache)
        {
            Guard.NotNull(resourceManager, Funcs.Null(nameof(resourceManager)));
            Guard.NotNull(resourceStringProvider, Funcs.Null(nameof(resourceStringProvider)));
            Guard.NotNull(baseName, Funcs.Null(nameof(baseName)));
            Guard.NotNull(resourceNamesCache, Funcs.Null(nameof(resourceNamesCache)));
            Guard.NotNull(culture, Funcs.Null(nameof(culture)));

            _resourceBaseName = baseName;
            _culture = culture;
        }

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizerWithCulture"/>.
        /// </summary>
        /// <param name="resourceManager">The <see cref="XmlResourceManager"/> to read strings from.</param>
        /// <param name="resourceAssembly">The <see cref="Assembly"/> that contains the strings as embedded resources.</param>
        /// <param name="baseName">The base name of the embedded resource that contains the strings.</param>
        /// <param name="resourceNamesCache">Cache of the list of strings for a given resource assembly name.</param>
        /// <param name="culture">The specific <see cref="CultureInfo"/> to use.</param>
        public XmlStringLocalizerWithCulture(
            XmlResourceManager resourceManager,
            Assembly resourceAssembly,
            string baseName,
            IResourceNamesCache resourceNamesCache,
            CultureInfo culture)
            : base(resourceManager, resourceAssembly, baseName, resourceNamesCache)
        {
            Guard.NotNull(resourceManager, Funcs.Null(nameof(resourceManager)));
            Guard.NotNull(resourceAssembly, Funcs.Null(nameof(resourceAssembly)));
            Guard.NotNull(baseName, Funcs.Null(nameof(baseName)));
            Guard.NotNull(resourceNamesCache, Funcs.Null(nameof(resourceNamesCache)));
            Guard.NotNull(culture, Funcs.Null(nameof(culture)));

            _resourceBaseName = baseName;
            _culture = culture;
        }

        /// <inheritdoc />
        public override LocalizedString this[string name]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                var value = GetStringSafely(name, _culture);

                return new LocalizedString(name, (value ?? name), resourceNotFound: (value == null),
                    searchedLocation: _resourceBaseName);
            }
        }

        /// <inheritdoc />
        public override LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                var format = GetStringSafely(name, _culture);
                var value = string.Format(_culture, format ?? name, arguments);

                return new LocalizedString(name, value, resourceNotFound: (format == null),
                    searchedLocation: _resourceBaseName);
            }
        }

        /// <inheritdoc />
        public override IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
            GetAllStrings(includeParentCultures, _culture);
    }
}