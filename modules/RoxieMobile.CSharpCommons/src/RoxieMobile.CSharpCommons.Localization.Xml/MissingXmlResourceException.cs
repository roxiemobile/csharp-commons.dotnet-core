using System;
using RoxieMobile.CSharpCommons.Localization.Xml.Resources;

namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    public sealed class MissingXmlResourceException : SystemException
    {
        public MissingXmlResourceException()
            : base(Messages.Argument_MissingXmlResourceException)
        {}

        public MissingXmlResourceException(String message)
            : base(message)
        {}

        public MissingXmlResourceException(String message, Exception inner)
            : base(message, inner)
        {}
    }
}