namespace RoxieMobile.CSharpCommons.Abstractions.Providers
{
    public interface IByteArrayProvider
    {
        /// <summary>
        /// Encodes the contents of the object and returns the resulting byte array.
        /// </summary>
        byte[] ToByteArray();
    }
}
