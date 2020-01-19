using System;
using System.Collections.Generic;
using Microsoft.Extensions.Localization;

// StringLocalizerOfT.cs
// @link https://github.com/dotnet/extensions/blob/master/src/Localization/Abstractions/src/StringLocalizerOfT.cs

// ReSharper disable once CheckNamespace
namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Provides strings for <typeparamref name="TResourceSource"/>.
    /// </summary>
    /// <typeparam name="TResourceSource">The <see cref="Type"/> to provide strings for.</typeparam>
    public class XmlStringLocalizer<TResourceSource> : IXmlStringLocalizer<TResourceSource>
    {
        private IXmlStringLocalizer _localizer;

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizer{TResourceSource}"/>.
        /// </summary>
        /// <param name="factory">The <see cref="IXmlStringLocalizerFactory"/> to use.</param>
        public XmlStringLocalizer(IXmlStringLocalizerFactory factory)
        {
            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            _localizer = factory.Create(typeof(TResourceSource));
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return _localizer[name];
            }
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }

                return _localizer[name, arguments];
            }
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
            _localizer.GetAllStrings(includeParentCultures);
    }
}
