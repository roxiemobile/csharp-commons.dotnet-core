using System.Collections.Generic;
using System.Globalization;
using System.Resources;

// IResourceGroveler.cs
// @link https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Resources/IResourceGroveler.cs

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal.Resources
{
    internal interface IXmlResourceGroveler
    {
        ResourceSet? GrovelForResourceSet(CultureInfo culture, Dictionary<string, ResourceSet> localResourceSets, bool tryParents,
            bool createIfNotExists);
    }
}
