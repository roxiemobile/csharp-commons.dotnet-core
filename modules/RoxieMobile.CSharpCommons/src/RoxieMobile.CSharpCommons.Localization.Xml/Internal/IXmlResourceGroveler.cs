using System.Globalization;
using System.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal
{
    internal interface IXmlResourceGroveler
    {
        ResourceSet GrovelForResourceSet(CultureInfo culture, bool tryParents);
    }
}