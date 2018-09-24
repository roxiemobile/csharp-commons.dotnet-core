using System;

// ReSharper disable once CheckNamespace
namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Represents a factory that creates <see cref="IXmlStringLocalizer"/> instances.
    /// </summary>
    public interface IXmlStringLocalizerFactory
    {
        /// <summary>
        /// Creates an <see cref="IXmlStringLocalizer"/> using the <see cref="System.Reflection.Assembly"/> and
        /// <see cref="Type.FullName"/> of the specified <see cref="Type"/>.
        /// </summary>
        /// <param name="resourceSource">The <see cref="Type"/>.</param>
        /// <returns>The <see cref="IXmlStringLocalizer"/>.</returns>
        IXmlStringLocalizer Create(Type resourceSource);

        /// <summary>
        /// Creates an <see cref="IXmlStringLocalizer"/>.
        /// </summary>
        /// <param name="baseName">The base name of the resource to load strings from.</param>
        /// <param name="location">The location to load resources from.</param>
        /// <returns>The <see cref="IXmlStringLocalizer"/>.</returns>
        IXmlStringLocalizer Create(string baseName, string location);
    }
}