// IStringLocalizerOfT.cs
// @link https://github.com/dotnet/extensions/blob/master/src/Localization/Abstractions/src/IStringLocalizerOfT.cs

// ReSharper disable once CheckNamespace
namespace RoxieMobile.CSharpCommons.Localization.Xml
{
    /// <summary>
    /// Represents an <see cref="IXmlStringLocalizer"/> that provides strings for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The <see cref="System.Type"/> to provide strings for.</typeparam>
    public interface IXmlStringLocalizer<out T> : IXmlStringLocalizer
    {

    }
}
