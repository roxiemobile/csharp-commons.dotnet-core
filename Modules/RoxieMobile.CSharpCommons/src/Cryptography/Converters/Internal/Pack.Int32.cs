namespace RoxieMobile.CSharpCommons.Cryptography.Converters.Internal
{
    internal static partial class Pack
    {
// MARK: - Methods: Big-Indian Order

        internal static byte[] Int32_To_BE(int n) =>
            UInt32_To_BE((uint) n);

        internal static void Int32_To_BE(int n, byte[] bs, int off = 0) =>
            UInt32_To_BE((uint) n, bs, off);

        internal static byte[] Int32_To_BE(int[] ns) =>
            UInt32_To_BE((uint[]) (object) ns);

        internal static void Int32_To_BE(int[] ns, byte[] bs, int off = 0) =>
            UInt32_To_BE((uint[]) (object) ns, bs, off);

// --

        internal static int BE_To_Int32(byte[] bs, int off = 0) =>
            (int) BE_To_UInt32(bs, off);

        internal static void BE_To_Int32(byte[] bs, int off, int[] ns) =>
            BE_To_UInt32(bs, off, (uint[]) (object) ns);

// MARK: - Methods: Little-Indian Order

        internal static byte[] Int32_To_LE(int n) =>
            UInt32_To_LE((uint) n);

        internal static void Int32_To_LE(int n, byte[] bs, int off = 0) =>
            UInt32_To_LE((uint) n, bs, off);

        internal static byte[] Int32_To_LE(int[] ns) =>
            UInt32_To_LE((uint[]) (object) ns);

        internal static void Int32_To_LE(int[] ns, byte[] bs, int off = 0) =>
            UInt32_To_LE((uint[]) (object) ns, bs, off);

// --

        internal static int LE_To_Int32(byte[] bs, int off = 0) =>
            (int) LE_To_UInt32(bs, off);

        internal static void LE_To_Int32(byte[] bs, int off, int[] ns) =>
            LE_To_UInt32(bs, off, (uint[]) (object) ns);
    }
}