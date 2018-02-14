using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using RoxieMobile.CSharpCommons.Diagnostics;
using RoxieMobile.CSharpCommons.Extensions;
using RoxieMobile.CSharpCommons.Localization.Xml.Internal;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// An <see cref="IXmlStringLocalizerFactory"/> that creates instances of <see cref="XmlStringLocalizer"/>.
    /// </summary>
    /// <remarks>
    /// <see cref="XmlStringLocalizerFactory"/> offers multiple ways to set the relative path of
    /// resources to be used. They are, in order of precedence:
    /// <see cref="ResourceLocationAttribute"/> -> <see cref="LocalizationOptions.ResourcesPath"/> -> the project root.
    /// </remarks>
    public class XmlStringLocalizerFactory : IXmlStringLocalizerFactory
    {
        private readonly IResourceNamesCache _resourceNamesCache = new ResourceNamesCache();
        private readonly ConcurrentDictionary<string, XmlStringLocalizer> _localizerCache =
            new ConcurrentDictionary<string, XmlStringLocalizer>();
        private readonly string _resourcesRelativePath;

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizer"/>.
        /// </summary>
        /// <param name="localizationOptions">The <see cref="IOptions{LocalizationOptions}"/>.</param>
        public XmlStringLocalizerFactory(IOptions<LocalizationOptions> localizationOptions)
        {
            Guard.NotNull(localizationOptions, Funcs.Null(nameof(localizationOptions)));

            _resourcesRelativePath = localizationOptions.Value.ResourcesPath ?? string.Empty;

            if (_resourcesRelativePath.IsNotEmpty()) {
                _resourcesRelativePath = _resourcesRelativePath
                    .Replace(Path.AltDirectorySeparatorChar, '.')
                    .Replace(Path.DirectorySeparatorChar, '.') + '.';
            }
        }

        /// <summary>
        /// Gets the resource prefix used to look up the resource.
        /// </summary>
        /// <param name="typeInfo">The type of the resource to be looked up.</param>
        /// <returns>The prefix for resource lookup.</returns>
        protected virtual string GetResourcePrefix(TypeInfo typeInfo)
        {
            Guard.NotNull(typeInfo, Funcs.Null(nameof(typeInfo)));

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
        protected virtual string GetResourcePrefix(
            TypeInfo typeInfo,
            string baseNamespace,
            string resourcesRelativePath)
        {
            Guard.NotNull(typeInfo, Funcs.Null(nameof(typeInfo)));
            Guard.NotEmpty(baseNamespace, Funcs.Empty(nameof(baseNamespace)));

            if (resourcesRelativePath.IsEmpty()) {
                return typeInfo.FullName;
            }
            else {
                // This expectation is defined by dotnet's automatic resource storage.
                // We have to conform to "{RootNamespace}.{ResourceLocation}.{FullTypeName - AssemblyName}".
                var assemblyName = new AssemblyName(typeInfo.Assembly.FullName).Name;
                return baseNamespace + '.' + resourcesRelativePath + TrimPrefix(typeInfo.FullName, assemblyName + '.');
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
            Guard.NotEmpty(baseResourceName, Funcs.Empty(nameof(baseResourceName)));
            Guard.NotEmpty(baseNamespace, Funcs.Empty(nameof(baseNamespace)));

            var assemblyName = new AssemblyName(baseNamespace);
            var assembly = Assembly.Load(assemblyName);
            var rootNamespace = GetRootNamespace(assembly);
            var resourceLocation = GetResourcePath(assembly);
            var locationPath = rootNamespace + "." + resourceLocation;

            baseResourceName = locationPath + TrimPrefix(baseResourceName, baseNamespace + ".");
            return baseResourceName;
        }

        /// <summary>
        /// Creates a <see cref="XmlStringLocalizer"/> using the <see cref="Assembly"/> and
        /// <see cref="Type.FullName"/> of the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="resourceSource">The <see cref="Type"/>.</param>
        /// <returns>The <see cref="XmlStringLocalizer"/>.</returns>
        public IXmlStringLocalizer Create(Type resourceSource)
        {
            Guard.NotNull(resourceSource, Funcs.Null(nameof(resourceSource)));

            var typeInfo = resourceSource.GetTypeInfo();
            var baseName = GetResourcePrefix(typeInfo);
            var assembly = typeInfo.Assembly;

            return _localizerCache.GetOrAdd(baseName, _ => CreateResourceManagerStringLocalizer(assembly, baseName));
        }

        /// <summary>
        /// Creates a <see cref="XmlStringLocalizer"/>.
        /// </summary>
        /// <param name="baseName">The base name of the resource to load strings from.</param>
        /// <param name="location">The location to load resources from.</param>
        /// <returns>The <see cref="XmlStringLocalizer"/>.</returns>
        public IXmlStringLocalizer Create(
            string baseName,
            string location)
        {
            Guard.NotNull(baseName, Funcs.Null(nameof(baseName)));
            Guard.NotNull(location, Funcs.Null(nameof(location)));

            return _localizerCache.GetOrAdd($"B={baseName},L={location}", _ => {

                var assemblyName = new AssemblyName(location);
                var assembly = Assembly.Load(assemblyName);

                baseName = GetResourcePrefix(baseName, location);
                return CreateResourceManagerStringLocalizer(assembly, baseName);
            });
        }

        /// <summary>Creates a <see cref="XmlStringLocalizer"/> for the given input.</summary>
        /// <param name="assembly">The assembly to create a <see cref="XmlStringLocalizer"/> for.</param>
        /// <param name="baseName">The base name of the resource to search for.</param>
        /// <returns>A <see cref="XmlStringLocalizer"/> for the given <paramref name="assembly"/> and <paramref name="baseName"/>.</returns>
        /// <remarks>This method is virtual for testing purposes only.</remarks>
        protected virtual XmlStringLocalizer CreateResourceManagerStringLocalizer(
            Assembly assembly,
            string baseName)
        {
            return new XmlStringLocalizer(
                new XmlResourceManager(baseName, assembly),
                assembly,
                baseName,
                _resourceNamesCache);
        }

        private string GetRootNamespace(Assembly assembly)
        {
            return new AssemblyName(assembly.FullName).Name;
        }

        private string GetResourcePath(Assembly assembly)
        {
            var resourceLocation = _resourcesRelativePath
                .Replace(Path.DirectorySeparatorChar, '.')
                .Replace(Path.AltDirectorySeparatorChar, '.');

            return resourceLocation;
        }

        private static string TrimPrefix(string name, string prefix)
        {
            return name.StartsWith(prefix, StringComparison.Ordinal)
                ? name.Substring(prefix.Length)
                : name;
        }
    }
}