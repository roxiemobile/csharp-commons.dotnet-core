using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RoxieMobile.CSharpCommons.Localization.Xml.Internal.Resources;

// ResourceManagerStringLocalizerFactory.cs
// @link https://github.com/dotnet/extensions/blob/master/src/Localization/Localization/src/ResourceManagerStringLocalizerFactory.cs

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// An <see cref="IXmlStringLocalizerFactory"/> that creates instances of <see cref="XmlResourceManagerStringLocalizer"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="XmlResourceManagerStringLocalizerFactory"/> offers multiple ways to set the relative path of
    /// resources to be used. They are, in order of precedence:
    /// <see cref="ResourceLocationAttribute"/> -> <see cref="LocalizationOptions.ResourcesPath"/> -> the project root.
    /// </remarks>
    public class XmlResourceManagerStringLocalizerFactory : IXmlStringLocalizerFactory
    {
        private readonly IResourceNamesCache _resourceNamesCache = new ResourceNamesCache();
        private readonly ConcurrentDictionary<string, XmlResourceManagerStringLocalizer> _localizerCache =
            new ConcurrentDictionary<string, XmlResourceManagerStringLocalizer>();
        private readonly string _resourcesRelativePath;
        private readonly ILoggerFactory _loggerFactory;

        /// <summary>
        /// Creates a new <see cref="XmlResourceManagerStringLocalizer"/>.
        /// </summary>
        /// <param name="localizationOptions">The <see cref="IOptions{LocalizationOptions}"/>.</param>
        /// <param name="loggerFactory">The <see cref="ILoggerFactory"/>.</param>
        public XmlResourceManagerStringLocalizerFactory(
            IOptions<LocalizationOptions> localizationOptions,
            ILoggerFactory loggerFactory)
        {
            if (localizationOptions == null)
            {
                throw new ArgumentNullException(nameof(localizationOptions));
            }

            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }

            _resourcesRelativePath = localizationOptions.Value.ResourcesPath ?? string.Empty;
            _loggerFactory = loggerFactory;

            if (!string.IsNullOrEmpty(_resourcesRelativePath))
            {
                _resourcesRelativePath = _resourcesRelativePath.Replace(Path.AltDirectorySeparatorChar, '.')
                    .Replace(Path.DirectorySeparatorChar, '.') + ".";
            }
        }

        /// <summary>
        /// Gets the resource prefix used to look up the resource.
        /// </summary>
        /// <param name="typeInfo">The type of the resource to be looked up.</param>
        /// <returns>The prefix for resource lookup.</returns>
        protected virtual string GetResourcePrefix(TypeInfo typeInfo)
        {
            if (typeInfo == null)
            {
                throw new ArgumentNullException(nameof(typeInfo));
            }

            return GetResourcePrefix(typeInfo, GetRootNamespace(typeInfo.Assembly), GetResourcePath(typeInfo.Assembly));
        }

        /// <summary>
        /// Gets the resource prefix used to look up the resource.
        /// </summary>
        /// <param name="typeInfo">The type of the resource to be looked up.</param>
        /// <param name="baseNamespace">The base namespace of the application.</param>
        /// <param name="resourcesRelativePath">The folder containing all resources.</param>
        /// <returns>The prefix for resource lookup.</returns>
        /// <remarks>
        /// For the type "Sample.Controllers.Home" if there's a resourceRelativePath return
        /// "Sample.Resourcepath.Controllers.Home" if there isn't one then it would return "Sample.Controllers.Home".
        /// </remarks>
        protected virtual string GetResourcePrefix(TypeInfo typeInfo, string baseNamespace, string resourcesRelativePath)
        {
            if (typeInfo == null)
            {
                throw new ArgumentNullException(nameof(typeInfo));
            }

            if (string.IsNullOrEmpty(baseNamespace))
            {
                throw new ArgumentNullException(nameof(baseNamespace));
            }

            if (string.IsNullOrEmpty(resourcesRelativePath))
            {
                return typeInfo.FullName!;
            }
            else
            {
                // This expectation is defined by dotnet's automatic resource storage.
                // We have to conform to "{RootNamespace}.{ResourceLocation}.{FullTypeName - RootNamespace}".
                return baseNamespace + "." + resourcesRelativePath + TrimPrefix(typeInfo.FullName!, baseNamespace + ".");
            }
        }

        /// <summary>
        /// Gets the resource prefix used to look up the resource.
        /// </summary>
        /// <param name="baseResourceName">The name of the resource to be looked up</param>
        /// <param name="baseNamespace">The base namespace of the application.</param>
        /// <returns>The prefix for resource lookup.</returns>
        protected virtual string GetResourcePrefix(string baseResourceName, string baseNamespace)
        {
            if (string.IsNullOrEmpty(baseResourceName))
            {
                throw new ArgumentNullException(nameof(baseResourceName));
            }

            if (string.IsNullOrEmpty(baseNamespace))
            {
                throw new ArgumentNullException(nameof(baseNamespace));
            }

            var assemblyName = new AssemblyName(baseNamespace);
            var assembly = Assembly.Load(assemblyName);
            var rootNamespace = GetRootNamespace(assembly);
            var resourceLocation = GetResourcePath(assembly);
            var locationPath = rootNamespace + "." + resourceLocation;

            baseResourceName = locationPath + TrimPrefix(baseResourceName, baseNamespace + ".");

            return baseResourceName;
        }

        /// <summary>
        /// Creates a <see cref="XmlResourceManagerStringLocalizer"/> using the <see cref="Assembly"/> and
        /// <see cref="Type.FullName"/> of the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="resourceSource">The <see cref="Type"/>.</param>
        /// <returns>The <see cref="XmlResourceManagerStringLocalizer"/>.</returns>
        public IXmlStringLocalizer Create(Type resourceSource)
        {
            if (resourceSource == null)
            {
                throw new ArgumentNullException(nameof(resourceSource));
            }

            var typeInfo = resourceSource.GetTypeInfo();

            var baseName = GetResourcePrefix(typeInfo);

            var assembly = typeInfo.Assembly;

            return _localizerCache.GetOrAdd(baseName, _ => CreateXmlResourceManagerStringLocalizer(assembly, baseName));
        }

        /// <summary>
        /// Creates a <see cref="XmlResourceManagerStringLocalizer"/>.
        /// </summary>
        /// <param name="baseName">The base name of the resource to load strings from.</param>
        /// <param name="location">The location to load resources from.</param>
        /// <returns>The <see cref="XmlResourceManagerStringLocalizer"/>.</returns>
        public IXmlStringLocalizer Create(string baseName, string location)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException(nameof(baseName));
            }

            if (location == null)
            {
                throw new ArgumentNullException(nameof(location));
            }

            return _localizerCache.GetOrAdd($"B={baseName},L={location}", _ =>
            {
                var assemblyName = new AssemblyName(location);
                var assembly = Assembly.Load(assemblyName);
                baseName = GetResourcePrefix(baseName, location);

                return CreateXmlResourceManagerStringLocalizer(assembly, baseName);
            });
        }

        /// <summary>Creates a <see cref="XmlResourceManagerStringLocalizer"/> for the given input.</summary>
        /// <param name="assembly">The assembly to create a <see cref="XmlResourceManagerStringLocalizer"/> for.</param>
        /// <param name="baseName">The base name of the resource to search for.</param>
        /// <returns>A <see cref="XmlResourceManagerStringLocalizer"/> for the given <paramref name="assembly"/> and <paramref name="baseName"/>.</returns>
        /// <remarks>This method is virtual for testing purposes only.</remarks>
        protected virtual XmlResourceManagerStringLocalizer CreateXmlResourceManagerStringLocalizer(
            Assembly assembly,
            string baseName)
        {
            return new XmlResourceManagerStringLocalizer(
                new XmlResourceManager(baseName, assembly),
                assembly,
                baseName,
                _resourceNamesCache,
                _loggerFactory.CreateLogger<XmlResourceManagerStringLocalizer>());
        }

        /// <summary>
        /// Gets the resource prefix used to look up the resource.
        /// </summary>
        /// <param name="location">The general location of the resource.</param>
        /// <param name="baseName">The base name of the resource.</param>
        /// <param name="resourceLocation">The location of the resource within <paramref name="location"/>.</param>
        /// <returns>The resource prefix used to look up the resource.</returns>
        protected virtual string GetResourcePrefix(string location, string baseName, string resourceLocation)
        {
            // Re-root the base name if a resources path is set
            return location + "." + resourceLocation + TrimPrefix(baseName, location + ".");
        }

        /// <summary>Gets a <see cref="ResourceLocationAttribute"/> from the provided <see cref="Assembly"/>.</summary>
        /// <param name="assembly">The assembly to get a <see cref="ResourceLocationAttribute"/> from.</param>
        /// <returns>The <see cref="ResourceLocationAttribute"/> associated with the given <see cref="Assembly"/>.</returns>
        /// <remarks>This method is protected and virtual for testing purposes only.</remarks>
        protected virtual ResourceLocationAttribute? GetResourceLocationAttribute(Assembly assembly)
        {
//            return assembly.GetCustomAttribute<ResourceLocationAttribute>();

            return null;
        }

        /// <summary>Gets a <see cref="RootNamespaceAttribute"/> from the provided <see cref="Assembly"/>.</summary>
        /// <param name="assembly">The assembly to get a <see cref="RootNamespaceAttribute"/> from.</param>
        /// <returns>The <see cref="RootNamespaceAttribute"/> associated with the given <see cref="Assembly"/>.</returns>
        /// <remarks>This method is protected and virtual for testing purposes only.</remarks>
        protected virtual RootNamespaceAttribute? GetRootNamespaceAttribute(Assembly assembly)
        {
//            return assembly.GetCustomAttribute<RootNamespaceAttribute>();

            return null;
        }

        private string GetRootNamespace(Assembly assembly)
        {
            var rootNamespaceAttribute = GetRootNamespaceAttribute(assembly);

            return rootNamespaceAttribute?.RootNamespace ??
                new AssemblyName(assembly.FullName!).Name!;
        }

        private string GetResourcePath(Assembly assembly)
        {
            var resourceLocationAttribute = GetResourceLocationAttribute(assembly);

            // If we don't have an attribute assume all assemblies use the same resource location.
            var resourceLocation = resourceLocationAttribute == null
                ? _resourcesRelativePath
                : resourceLocationAttribute.ResourceLocation + ".";
            resourceLocation = resourceLocation
                .Replace(Path.DirectorySeparatorChar, '.')
                .Replace(Path.AltDirectorySeparatorChar, '.');

            return resourceLocation;
        }

        private static string TrimPrefix(string name, string prefix)
        {
            if (name.StartsWith(prefix, StringComparison.Ordinal))
            {
                return name.Substring(prefix.Length);
            }

            return name;
        }
    }
}
