namespace RoxieMobile.CSharpCommons.Cryptography.Converters.Internal
{
    internal static partial class Pack
    {
// MARK: - Methods: Big-Indian Order

        internal static byte[] Int16_To_BE(short n) =>
            UInt16_To_BE((ushort) n);

        internal static void Int16_To_BE(short n, byte[] bs, int off = 0) =>
            UInt16_To_BE((ushort) n, bs, off);

        internal static byte[] Int16_To_BE(short[] ns) =>
            UInt16_To_BE((ushort[]) (object) ns);

        internal static void Int16_To_BE(short[] ns, byte[] bs, int off = 0) =>
            UInt16_To_BE((ushort[]) (object) ns, bs, off);

// --

        internal static short BE_To_Int16(byte[] bs, int off = 0) =>
            (short) BE_To_UInt16(bs, off);

        internal static void BE_To_Int16(byte[] bs, int off, short[] ns) =>
            BE_To_UInt16(bs, off, (ushort[]) (object) ns);

// MARK: - Methods: Little-Indian Order

        internal static byte[] Int16_To_LE(short n) =>
            UInt16_To_LE((ushort) n);

        internal static void Int16_To_LE(short n, byte[] bs, int off = 0) =>
            UInt16_To_LE((ushort) n, bs, off);

        internal static byte[] Int16_To_LE(short[] ns) =>
            UInt16_To_LE((ushort[]) (object) ns);

        internal static void Int16_To_LE(short[] ns, byte[] bs, int off = 0) =>
            UInt16_To_LE((ushort[]) (object) ns, bs, off);

// --

        internal static short LE_To_Int16(byte[] bs, int off = 0) =>
            (short) LE_To_UInt16(bs, off);

        internal static void LE_To_Int16(byte[] bs, int off, short[] ns) =>
            LE_To_UInt16(bs, off, (ushort[]) (object) ns);
    }
}