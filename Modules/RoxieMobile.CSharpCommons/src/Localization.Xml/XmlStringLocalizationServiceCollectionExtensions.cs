using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using RoxieMobile.CSharpCommons.Diagnostics;

// ReSharper disable once CheckNamespace
namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Extension methods for setting up localization services in an <see cref="IServiceCollection" />.
    /// </summary>
    public static class XmlStringLocalizationServiceCollectionExtensions
    {
        /// <summary>
        /// Adds services required for application localization with strings from XML file(s).
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddXmlStringLocalization(this IServiceCollection services)
        {
            Guard.NotNull(services, Funcs.Null(nameof(services)));

            services.AddOptions();

            AddXmlStringLocalizationServices(services);

            return services;
        }

        /// <summary>
        /// Adds services required for application localization with strings from XML file(s).
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
        /// <param name="setupAction">
        /// An <see cref="Action{LocalizationOptions}"/> to configure the <see cref="LocalizationOptions"/>.
        /// </param>
        /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
        public static IServiceCollection AddXmlStringLocalization(
            this IServiceCollection services,
            Action<LocalizationOptions> setupAction)
        {
            Guard.NotNull(services, Funcs.Null(nameof(services)));
            Guard.NotNull(setupAction, Funcs.Null(nameof(setupAction)));

            AddXmlStringLocalizationServices(services, setupAction);

            return services;
        }

        private static void AddXmlStringLocalizationServices(IServiceCollection services)
        {
            services.TryAddSingleton<IXmlStringLocalizerFactory, XmlStringLocalizerFactory>();
            services.TryAddTransient(typeof(IXmlStringLocalizer<>), typeof(XmlStringLocalizer<>));
        }

        private static void AddXmlStringLocalizationServices(
            IServiceCollection services,
            Action<LocalizationOptions> setupAction)
        {
            AddXmlStringLocalizationServices(services);
            services.Configure(setupAction);
        }
    }
}