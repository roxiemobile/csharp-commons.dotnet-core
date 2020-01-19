using System.Globalization;
using System.Resources;
using RoxieMobile.CSharpCommons.Diagnostics;

// ReSharper disable MemberCanBePrivate.Global
namespace RoxieMobile.CSharpCommons.Localization.Xml.Resources
{
    // ASP.NET Core Localization with help of SharedResources
    // @link https://stackoverflow.com/a/42649361

    internal static class Messages
    {
// MARK: - Properties

        public static string Localization_MissingXmlResource =>
            GetString("Localization_MissingXmlResource");

        public static string Localization_MissingXmlResource_Parent =>
            GetString("Localization_MissingXmlResource_Parent");

        public static string ResourceReaderIsClosed =>
            GetString("ResourceReaderIsClosed");

        public static string InvalidOperation_EnumEnded =>
            GetString("InvalidOperation_EnumEnded");

        public static string InvalidOperation_EnumNotStarted =>
            GetString("InvalidOperation_EnumNotStarted");

        public static string MissingResource_NoNeutralDisk =>
            GetString("MissingResource_NoNeutralDisk");

        public static string InvalidOperation_ResMgrBadResSet_Type =>
            GetString("InvalidOperation_ResMgrBadResSet_Type");

        public static string Argument_MustBeRuntimeAssembly =>
            GetString("Argument_MustBeRuntimeAssembly");

        public static string Arg_MissingXmlResourceException =>
            GetString("Arg_MissingXmlResourceException");

// MARK: - Private Properties

        private static ResourceManager ResourceManager =>
            new ResourceManager(typeof(Messages).FullName!, typeof(Messages).Assembly);

        private static string GetString(string name)
        {
            var value = ResourceManager.GetString(name, CultureInfo.InvariantCulture);
            Guard.NotNull(value, Funcs.Null(nameof(value)));
            return value!;
        }

// MARK: - Methods

        public static string FormatLocalization_MissingXmlResource(object? p0) =>
            string.Format(CultureInfo.CurrentCulture, Localization_MissingXmlResource, p0);

        public static string FormatInvalidOperation_ResMgrBadResSet_Type(object? p0) =>
            string.Format(CultureInfo.CurrentCulture, InvalidOperation_ResMgrBadResSet_Type, p0);
    }
}
