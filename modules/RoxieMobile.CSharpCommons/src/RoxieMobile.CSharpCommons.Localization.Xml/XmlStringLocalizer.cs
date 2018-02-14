using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Localization.Internal;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Logging;
using RoxieMobile.CSharpCommons.Localization.Xml.Internal;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// An <see cref="IXmlStringLocalizer"/> that uses the <see cref="XmlResourceManager"/> and
    /// <see cref="XmlResourceReader"/> to provide localized strings.
    /// </summary>
    /// <remarks>This type is thread-safe.</remarks>
    public class XmlStringLocalizer : IXmlStringLocalizer
    {
        private static readonly string TAG = typeof(XmlStringLocalizer).Name;

        private readonly ConcurrentDictionary<string, object> _missingManifestCache =
            new ConcurrentDictionary<string, object>();
        private readonly IResourceNamesCache _resourceNamesCache;
        private readonly XmlResourceManager _resourceManager;
        private readonly IResourceStringProvider _resourceStringProvider;
        private readonly string _resourceBaseName;

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizer"/>.
        /// </summary>
        /// <param name="resourceManager">The <see cref="XmlResourceManager"/> to read strings from.</param>
        /// <param name="resourceAssembly">The <see cref="Assembly"/> that contains the strings as embedded resources.</param>
        /// <param name="baseName">The base name of the embedded resource that contains the strings.</param>
        /// <param name="resourceNamesCache">Cache of the list of strings for a given resource assembly name.</param>
        public XmlStringLocalizer(
            XmlResourceManager resourceManager,
            Assembly resourceAssembly,
            string baseName,
            IResourceNamesCache resourceNamesCache)
            : this(
                resourceManager,
                new AssemblyWrapper(resourceAssembly),
                baseName,
                resourceNamesCache)
        {}

        /// <summary>
        /// Intended for testing purposes only.
        /// </summary>
        public XmlStringLocalizer(
            XmlResourceManager resourceManager,
            AssemblyWrapper resourceAssemblyWrapper,
            string baseName,
            IResourceNamesCache resourceNamesCache)
            : this(
                resourceManager,
                new XmlStringProvider(
                    resourceNamesCache,
                    resourceManager,
                    resourceAssemblyWrapper.Assembly),
                baseName,
                resourceNamesCache)
        {}

        /// <summary>
        /// Intended for testing purposes only.
        /// </summary>
        public XmlStringLocalizer(
            XmlResourceManager resourceManager,
            IResourceStringProvider resourceStringProvider,
            string baseName,
            IResourceNamesCache resourceNamesCache)
        {
            Guard.NotNull(resourceManager, Funcs.Null(nameof(resourceManager)));
            Guard.NotNull(resourceStringProvider, Funcs.Null(nameof(resourceStringProvider)));
            Guard.NotNull(baseName, Funcs.Null(nameof(baseName)));
            Guard.NotNull(resourceNamesCache, Funcs.Null(nameof(resourceNamesCache)));

            _resourceStringProvider = resourceStringProvider;
            _resourceManager = resourceManager;
            _resourceBaseName = baseName;
            _resourceNamesCache = resourceNamesCache;
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                var value = GetStringSafely(name, null);

                return new LocalizedString(name, (value ?? name), resourceNotFound: (value == null),
                    searchedLocation: _resourceBaseName);
            }
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                var format = GetStringSafely(name, null);
                var value = string.Format(format ?? name, arguments);

                return new LocalizedString(name, value, resourceNotFound: (format == null),
                    searchedLocation: _resourceBaseName);
            }
        }

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizer"/> for a specific <see cref="CultureInfo"/>.
        /// </summary>
        /// <param name="culture">The <see cref="CultureInfo"/> to use.</param>
        /// <returns>A culture-specific <see cref="XmlStringLocalizer"/>.</returns>
        public IXmlStringLocalizer WithCulture(CultureInfo culture)
        {
            return culture == null
                ? new XmlStringLocalizer(
                    _resourceManager,
                    _resourceStringProvider,
                    _resourceBaseName,
                    _resourceNamesCache)
                : new XmlStringLocalizerWithCulture(
                    _resourceManager,
                    _resourceStringProvider,
                    _resourceBaseName,
                    _resourceNamesCache,
                    culture);
        }

        /// <inheritdoc />
        public virtual IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
            GetAllStrings(includeParentCultures, CultureInfo.CurrentUICulture);

        /// <summary>
        /// Returns all strings in the specified culture.
        /// </summary>
        /// <param name="includeParentCultures"></param>
        /// <param name="culture">The <see cref="CultureInfo"/> to get strings for.</param>
        /// <returns>The strings.</returns>
        protected IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures, CultureInfo culture)
        {
            Guard.NotNull(culture, Funcs.Null(nameof(culture)));

            var resourceNames = includeParentCultures
                ? GetResourceNamesFromCultureHierarchy(culture)
                : _resourceStringProvider.GetAllResourceStrings(culture, true);

            foreach (var name in resourceNames) {
                var value = GetStringSafely(name, culture);

                yield return new LocalizedString(name, (value ?? name), resourceNotFound: (value == null),
                    searchedLocation: _resourceBaseName);
            }
        }

        /// <summary>
        /// Gets a resource string from the <see cref="XmlResourceManager"/> and returns <c>null</c> instead of
        /// throwing exceptions if a match isn't found.
        /// </summary>
        /// <param name="name">The name of the string resource.</param>
        /// <param name="culture">The <see cref="CultureInfo"/> to get the string for.</param>
        /// <returns>The resource string, or <c>null</c> if none was found.</returns>
        protected string GetStringSafely(string name, CultureInfo culture)
        {
            Guard.NotNull(name, Funcs.Null(nameof(name)));

            var keyCulture = culture ?? CultureInfo.CurrentUICulture;

            var cacheKey = $"name={name}&culture={keyCulture.Name}";

            Logger.D(TAG, $"{nameof(XmlStringLocalizer)} searched for '{name}' in '{_resourceBaseName}' with culture '{keyCulture}'.");

            if (_missingManifestCache.ContainsKey(cacheKey)) {
                return null;
            }

            try {
                return (culture == null)
                    ? _resourceManager.GetString(name)
                    : _resourceManager.GetString(name, culture);
            }
            catch (MissingXmlResourceException) {
                _missingManifestCache.TryAdd(cacheKey, null);
                return null;
            }
        }

        private IEnumerable<string> GetResourceNamesFromCultureHierarchy(CultureInfo startingCulture)
        {
            var currentCulture = startingCulture;
            var resourceNames = new HashSet<string>();

            var hasAnyCultures = false;
            while (true) {

                var cultureResourceNames = _resourceStringProvider.GetAllResourceStrings(currentCulture, false);
                if (cultureResourceNames != null) {

                    foreach (var resourceName in cultureResourceNames) {
                        resourceNames.Add(resourceName);
                    }

                    hasAnyCultures = true;
                }

                if (Equals(currentCulture, currentCulture.Parent)) {
                    // currentCulture begat currentCulture, probably time to leave
                    break;
                }

                currentCulture = currentCulture.Parent;
            }

            if (!hasAnyCultures) {
                throw new MissingXmlResourceException(Messages.Localization_MissingXmlResource_Parent);
            }

            return resourceNames;
        }
    }
}