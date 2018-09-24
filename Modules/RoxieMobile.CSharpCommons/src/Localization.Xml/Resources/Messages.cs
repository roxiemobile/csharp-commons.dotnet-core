using System.Globalization;
using System.Resources;

// ReSharper disable MemberCanBePrivate.Global
namespace RoxieMobile.CSharpCommons.Localization.Xml.Resources
{
    // ASP.NET Core Localization with help of SharedResources
    // @link https://stackoverflow.com/a/42649361

    internal static class Messages
    {
// MARK: - Properties

        public static string Localization_MissingXmlResource =>
            ResourceManager.GetString("Localization_MissingXmlResource", CultureInfo.InvariantCulture);

        public static string Localization_MissingXmlResource_Parent =>
            ResourceManager.GetString("Localization_MissingXmlResource_Parent", CultureInfo.InvariantCulture);

        public static string ResourceReaderIsClosed =>
            ResourceManager.GetString("ResourceReaderIsClosed", CultureInfo.InvariantCulture);

        public static string InvalidOperation_EnumEnded =>
            ResourceManager.GetString("InvalidOperation_EnumEnded", CultureInfo.InvariantCulture);

        public static string InvalidOperation_EnumNotStarted =>
            ResourceManager.GetString("InvalidOperation_EnumNotStarted", CultureInfo.InvariantCulture);

        public static string MissingResource_NoNeutralDisk =>
            ResourceManager.GetString("MissingResource_NoNeutralDisk", CultureInfo.InvariantCulture);

        public static string InvalidOperation_ResMgrBadResSet_Type =>
            ResourceManager.GetString("InvalidOperation_ResMgrBadResSet_Type", CultureInfo.InvariantCulture);

        public static string Argument_MustBeRuntimeAssembly =>
            ResourceManager.GetString("Argument_MustBeRuntimeAssembly", CultureInfo.InvariantCulture);

        public static string Argument_MissingXmlResourceException =>
            ResourceManager.GetString("Argument_MissingXmlResourceException", CultureInfo.InvariantCulture);

// MARK: - Private Properties

        private static ResourceManager ResourceManager =>
            new ResourceManager(typeof(Messages).FullName, typeof(Messages).Assembly);

// MARK: - Methods

        public static string FormatLocalization_MissingXmlResource(object p0) =>
            string.Format(CultureInfo.CurrentCulture, Localization_MissingXmlResource, p0);

        public static string FormatInvalidOperation_ResMgrBadResSet_Type(object p0) =>
            string.Format(CultureInfo.CurrentCulture, InvalidOperation_ResMgrBadResSet_Type, p0);
    }
}