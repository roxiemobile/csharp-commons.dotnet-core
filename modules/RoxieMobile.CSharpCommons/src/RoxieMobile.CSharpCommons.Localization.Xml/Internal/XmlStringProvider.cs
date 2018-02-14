using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Localization.Internal;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    internal class XmlStringProvider : IResourceStringProvider
    {
        private readonly IResourceNamesCache _resourceNamesCache;
        private readonly XmlResourceManager _resourceManager;
        private readonly Assembly _assembly;

        internal XmlStringProvider(
            IResourceNamesCache resourceCache,
            XmlResourceManager resourceManager,
            Assembly assembly)
        {
            _resourceManager = resourceManager;
            _resourceNamesCache = resourceCache;
            _assembly = assembly;
        }

        private string GetResourceCacheKey(CultureInfo culture)
        {
            var resourceName = _resourceManager.BaseName;

            return $"Culture={culture.Name};resourceName={resourceName};Assembly={_assembly.FullName}";
        }

        public IList<string> GetAllResourceStrings(CultureInfo culture, bool throwOnMissing)
        {
            var cacheKey = GetResourceCacheKey(culture);

            return _resourceNamesCache.GetOrAdd(cacheKey, _ => {

                // We purposly don't dispose the ResourceSet because it causes an ObjectDisposedException
                // when you try to read the values later.
                var resourceSet = _resourceManager.GetResourceSet(culture, createIfNotExists: true, tryParents: false);
                if (resourceSet == null) {

                    if (throwOnMissing) {
                        throw new MissingXmlResourceException(Messages.FormatLocalization_MissingXmlResource(
                            _resourceManager.GetResourceFileName(culture)));
                    }

                    return null;
                }

                var names = new List<string>();
                foreach (DictionaryEntry entry in resourceSet) {
                    names.Add((string) entry.Key);
                }

                return names;
            });
        }
    }
}