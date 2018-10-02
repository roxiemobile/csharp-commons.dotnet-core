using System;

namespace RoxieMobile.CSharpCommons.Cryptography.Converters
{
    // HexConverter
    // @link https://www.openmuc.org/asn1/javadoc/org/openmuc/jasn1/util/HexConverter.html
    // @link https://docs.jboss.org/jbossas/javadoc/7.1.2.Final/org/jboss/sasl/util/HexConverter.html

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

        /// <summary>
        /// Converts the specified hex encoded <see cref="string"/> into a byte array.
        /// </summary>
        /// <param name="hexString">The hex encoded string to convert.</param>
        /// <returns>The raw byte array.</returns>
        public static byte[] ToByteArray(string hexString)
        {
            // SoapHexBinary
            // @link https://github.com/mono/linux-packaging-mono/blob/master/mcs/class/corlib/System.Runtime.Remoting.Metadata.W3cXsd2001/SoapHexBinary.cs

            // Most light weight conversion from hex to byte in C#?
            // @link https://stackoverflow.com/a/14332574

            if (hexString.Length % 2 != 0) {
                throw new ArgumentException("Input must have even number of characters.");
            }

            var buffer = new byte [hexString.Length / 2];
            for (int idx = 0, bufIndex = 0; idx < hexString.Length - 1; idx += 2) {
                // @formatter:off
                buffer[bufIndex]   = ParseNibble(hexString[idx + 0]);
                buffer[bufIndex] <<= 4;
                buffer[bufIndex]  += ParseNibble(hexString[idx + 1]);
                // @formatter:on
                bufIndex++;
            }
            return buffer;
        }

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

        private static byte ParseNibble(char ch)
        {
            // @formatter:off
            switch (ch)
            {
                case '0': case '1': case '2': case '3': case '4':
                case '5': case '6': case '7': case '8': case '9':
                    return (byte) (ch - '0');
                case 'a': case 'b': case 'c': case 'd': case 'e': case 'f':
                    return (byte) (ch - ('a' - 10));
                case 'A': case 'B': case 'C': case 'D': case 'E': case 'F':
                    return (byte) (ch - ('A' - 10));
                default:
                    throw new ArgumentException($"Invalid nibble: {ch}");
            }
            // @formatter:on
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