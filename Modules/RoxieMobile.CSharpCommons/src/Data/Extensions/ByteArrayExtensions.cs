using RoxieMobile.CSharpCommons.Data.Converters;

namespace RoxieMobile.CSharpCommons.Data.Extensions
{
    public static class ByteArrayExtensions
    {
// MARK: - Methods

        /// <summary>
        /// Returns a string representation of the byte array in the lowercase format.
        /// </summary>
        /// <param name="array">The byte array to be converted.</param>
        /// <returns>The hex string in the lowercase format.</returns>
        public static string ToLowerHexString(this byte[] array) =>
            HexConverter.ToLowerHexString(array);

        /// <summary>
        /// Returns a string representation of the byte array in the uppercase format.
        /// </summary>
        /// <param name="array">The byte array to be converted.</param>
        /// <returns>The hex string in the uppercase format.</returns>
        public static string ToUpperHexString(this byte[] array) =>
            HexConverter.ToUpperHexString(array);
    }
}