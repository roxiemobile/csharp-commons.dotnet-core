using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Localization.Internal;
using RoxieMobile.CSharpCommons.Localization.Xml.Internal.Resources;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

// ResourceManagerStringProvider.cs
// @link https://github.com/dotnet/extensions/blob/master/src/Localization/Localization/src/Internal/ResourceManagerStringProvider.cs

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    /// <summary>
    /// This API supports infrastructure and is not intended to be used
    /// directly from your code. This API may change or be removed in future releases.
    /// </summary>
    public class XmlResourceManagerStringProvider : IResourceStringProvider
    {
        private readonly IResourceNamesCache _resourceNamesCache;
        private readonly XmlResourceManager _resourceManager;
        private readonly Assembly _assembly;
        private readonly string _resourceBaseName;

        public XmlResourceManagerStringProvider(
            IResourceNamesCache resourceCache,
            XmlResourceManager resourceManager,
            Assembly assembly,
            string baseName)
        {
            _resourceManager = resourceManager;
            _resourceNamesCache = resourceCache;
            _assembly = assembly;
            _resourceBaseName = baseName;
        }

        private string GetResourceCacheKey(CultureInfo culture)
        {
            var resourceName = _resourceManager.BaseName;

            return $"Culture={culture.Name};resourceName={resourceName};Assembly={_assembly.FullName}";
        }

        private string GetResourceName(CultureInfo culture)
        {
//            var resourceStreamName = _resourceBaseName;
//            if (!string.IsNullOrEmpty(culture.Name))
//            {
//                resourceStreamName += "." + culture.Name;
//            }
//            resourceStreamName += ".resources";
//
//            return resourceStreamName;

            return _resourceManager.GetResourceFileName(culture);
        }

        public IList<string> GetAllResourceStrings(CultureInfo culture, bool throwOnMissing)
        {
            var cacheKey = GetResourceCacheKey(culture);

            return _resourceNamesCache.GetOrAdd(cacheKey, _ =>
            {
                // We purposely don't dispose the ResourceSet because it causes an ObjectDisposedException when you try to read the values later.
                var resourceSet = _resourceManager.GetResourceSet(culture, createIfNotExists: true, tryParents: false);
                if (resourceSet == null)
                {
                    if (throwOnMissing)
                    {
                        throw new MissingXmlResourceException(Messages.FormatLocalization_MissingXmlResource(GetResourceName(culture)));
                    }
                    else
                    {
                        return null;
                    }
                }

//                var names = new List<string>();
//                foreach (DictionaryEntry entry in resourceSet)
//                {
//                    names.Add((string)entry.Key);
//                }

                var names = new List<string>();
                foreach (var item in resourceSet)
                {
                    if (item is DictionaryEntry entry)
                    {
                        names.Add((string) entry.Key);
                    }
                }

                return names;
            });
        }
    }
}
