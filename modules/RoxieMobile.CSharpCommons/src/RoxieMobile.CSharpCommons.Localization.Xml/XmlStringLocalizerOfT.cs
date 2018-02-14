using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.Extensions.Localization;
using RoxieMobile.CSharpCommons.Diagnostics;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Provides strings for <typeparamref name="TResourceSource"/>.
    /// </summary>
    /// <typeparam name="TResourceSource">The <see cref="Type"/> to provide strings for.</typeparam>
    public class XmlStringLocalizer<TResourceSource> : IXmlStringLocalizer<TResourceSource>
    {
        private readonly IXmlStringLocalizer _localizer;

        /// <summary>
        /// Creates a new <see cref="XmlStringLocalizer{TResourceSource}"/>.
        /// </summary>
        /// <param name="factory">The <see cref="IXmlStringLocalizerFactory"/> to use.</param>
        public XmlStringLocalizer(IXmlStringLocalizerFactory factory)
        {
            Guard.NotNull(factory, Funcs.Null(nameof(factory)));

            _localizer = factory.Create(typeof(TResourceSource));
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                return _localizer[name];
            }
        }

        /// <inheritdoc />
        public virtual LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                Guard.NotNull(name, Funcs.Null(nameof(name)));

                return _localizer[name, arguments];
            }
        }

        /// <inheritdoc />
        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures) =>
            _localizer.GetAllStrings(includeParentCultures);

        /// <inheritdoc />
        public virtual IXmlStringLocalizer WithCulture(CultureInfo culture) =>
            _localizer.WithCulture(culture);
    }
}