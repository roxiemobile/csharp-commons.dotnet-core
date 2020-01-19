using System;
using System.Runtime.Serialization;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

// MissingManifestResourceException.cs
// @link https://github.com/dotnet/runtime/blob/master/src/libraries/System.Private.CoreLib/src/System/Resources/MissingManifestResourceException.cs

namespace RoxieMobile.CSharpCommons.Localization.Xml.Internal.Resources
{
    [Serializable]
    public class MissingXmlResourceException : SystemException
    {
        public MissingXmlResourceException()
            : base(Messages.Arg_MissingXmlResourceException)
        {
//            HResult = System.HResults.COR_E_MISSINGMANIFESTRESOURCE;
        }

        public MissingXmlResourceException(string? message)
            : base(message)
        {
//            HResult = System.HResults.COR_E_MISSINGMANIFESTRESOURCE;
        }

        public MissingXmlResourceException(string? message, Exception? inner)
            : base(message, inner)
        {
//            HResult = System.HResults.COR_E_MISSINGMANIFESTRESOURCE;
        }

        protected MissingXmlResourceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
