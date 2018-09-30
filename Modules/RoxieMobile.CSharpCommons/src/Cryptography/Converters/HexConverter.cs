using System;

namespace RoxieMobile.CSharpCommons.Cryptography.Converters
{
    /// <summary>
    /// A helper class for converting data types to their hex representation.
    /// </summary>
    public static class HexConverter
    {
// MARK: - Methods

        /// <summary>
        /// Returns a string representation of the byte array in the lowercase format.
        /// </summary>
        /// <param name="array">The byte array to be converted.</param>
        /// <returns>The hex string in the lowercase format.</returns>
        public static string ToLowerHexString(byte[] array) =>
            ByteArrayToHexString(array, LookupTable(CaseStyle.Lowercase));

        /// <summary>
        /// Returns a string representation of the byte array in the uppercase format.
        /// </summary>
        /// <param name="array">The byte array to be converted.</param>
        /// <returns>The hex string in the uppercase format.</returns>
        public static string ToUpperHexString(byte[] array) =>
            ByteArrayToHexString(array, LookupTable(CaseStyle.Uppercase));

// MARK: - Private Methods

        private static string ByteArrayToHexString(byte[] bytes, uint[] lookupTable)
        {
            // How do you convert a byte array to a hexadecimal string, and vice versa?
            // @link https://stackoverflow.com/a/624379
            // @link https://stackoverflow.com/a/24343727

            var result = new char[bytes.Length * 2];
            for (var idx = 0; idx < bytes.Length; ++idx) {
                var value = lookupTable[bytes[idx]];
                result[2 * idx] = (char) value;
                result[2 * idx + 1] = (char) (value >> 16);
            }
            return new string(result);
        }

        private static uint[] CreateLowerLookupTable()
        {
            var result = new uint[256];
            for (var idx = 0; idx < 256; ++idx) {
                var str = idx.ToString("x2");
                result[idx] = str[0] + ((uint) str[1] << 16);
            }
            return result;
        }

        private static uint[] CreateUpperLookupTable()
        {
            var result = new uint[256];
            for (var idx = 0; idx < 256; ++idx) {
                var str = idx.ToString("X2");
                result[idx] = str[0] + ((uint) str[1] << 16);
            }
            return result;
        }

        private static uint[] LookupTable(CaseStyle type)
        {
            switch (type) {
                case CaseStyle.Lowercase:
                    return _lowerLookupTable;
                case CaseStyle.Uppercase:
                    return _upperLookupTable;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

// MARK: - Inner Types

        private enum CaseStyle
        {
            Lowercase,
            Uppercase
        }

// MARK: - Variables

        private static readonly uint[] _lowerLookupTable = CreateLowerLookupTable();

        private static readonly uint[] _upperLookupTable = CreateUpperLookupTable();
    }
}