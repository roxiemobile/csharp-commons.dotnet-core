using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Cryptography.Algorithms;
using RoxieMobile.CSharpCommons.Cryptography.Extensions;
using Xunit;
using static RoxieMobile.CSharpCommons.Cryptography.Converters.BigEndianBitConverter;

namespace RoxieMobile.CSharpCommons.Cryptography.UnitTests.Algorithms
{
    [SuppressMessage("ReSharper", "RedundantExplicitArrayCreation")]
    public sealed class SipHashTests
    {
// MARK: - Tests

        [Fact]
        private void TestSipHash64()
        {
            byte[] key = {
                0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
            };

            var data = new byte[64];
            for (var idx = 0; idx < data.Length; idx++) {
                data[idx] = (byte) idx;
            }

            // SipHash results for byte strings [], [0], [0,1], [0,1,2], etc...,
            // these match the values in the C test of SipHash at
            // https://github.com/veorq/SipHash/blob/master/vectors.h#L3
            ulong[] expected64 = {
                0x726FDB47DD0E0E31L, 0x74F839C593DC67FDL, 0x0D6C8009D9A94F5AL, 0x85676696D7FB7E2DL,
                0xCF2794E0277187B7L, 0x18765564CD99A68DL, 0xCBC9466E58FEE3CEL, 0xAB0200F58B01D137L,
                0x93F5F5799A932462L, 0x9E0082DF0BA9E4B0L, 0x7A5DBBC594DDB9F3L, 0xF4B32F46226BADA7L,
                0x751E8FBC860EE5FBL, 0x14EA5627C0843D90L, 0xF723CA908E7AF2EEL, 0xA129CA6149BE45E5L,
                0x3F2ACC7F57C29BDBL, 0x699AE9F52CBE4794L, 0x4BC1B3F0968DD39CL, 0xBB6DC91DA77961BDL,
                0xBED65CF21AA2EE98L, 0xD0F2CBB02E3B67C7L, 0x93536795E3A33E88L, 0xA80C038CCD5CCEC8L,
                0xB8AD50C6F649AF94L, 0xBCE192DE8A85B8EAL, 0x17D835B85BBB15F3L, 0x2F2E6163076BCFADL,
                0xDE4DAAACA71DC9A5L, 0xA6A2506687956571L, 0xAD87A3535C49EF28L, 0x32D892FAD841C342L,
                0x7127512F72F27CCEL, 0xA7F32346F95978E3L, 0x12E0B01ABB051238L, 0x15E034D40FA197AEL,
                0x314DFFBE0815A3B4L, 0x027990F029623981L, 0xCADCD4E59EF40C4DL, 0x9ABFD8766A33735CL,
                0x0E3EA96B5304A7D0L, 0xAD0C42D6FC585992L, 0x187306C89BC215A9L, 0xD4A60ABCF3792B95L,
                0xF935451DE4F21DF2L, 0xA9538F0419755787L, 0xDB9ACDDFF56CA510L, 0xD06C98CD5C0975EBL,
                0xE612A3CB9ECBA951L, 0xC766E62CFCADAF96L, 0xEE64435A9752FE72L, 0xA192D576B245165AL,
                0x0A8787BF8ECB74B2L, 0x81B3E73D20B49B6FL, 0x7FA8220BA3B2ECEAL, 0x245731C13CA42499L,
                0xB78DBFAF3A8D83BDL, 0xEA1AD565322A1A0BL, 0x60E61C23A3795013L, 0x6606D7E446282B93L,
                0x6CA4ECB15C5F91E1L, 0x9F626DA15C9625F3L, 0xE51B38608EF25F57L, 0x958A324CEB064572L,
            };

            for (var idx = 0; idx < data.Length; idx++) {
                CheckHash64(key, data, idx, expected64[idx]);
            }
        }

        [Fact]
        private void TestSipHash128()
        {
            byte[] key = {
                0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
            };

            var data = new byte[64];
            for (var idx = 0; idx < data.Length; idx++) {
                data[idx] = (byte) idx;
            }

            // SipHash results for byte strings [], [0], [0,1], [0,1,2], etc...,
            // these match the values in the C test of SipHash at
            // https://github.com/veorq/SipHash/blob/master/vectors.h#L197
            ulong[][] expected128 = {
                new ulong[] { 0xE6A825BA047F81A3L, 0x930255C71472F66DL, },
                new ulong[] { 0x44AF996BD8C187DAL, 0x45FC229B11597634L, },
                new ulong[] { 0xC75DA4A48D227781L, 0xE4FF0AF6DE8BA3FCL, },
                new ulong[] { 0x4EA967520CB6709CL, 0x51ED8529B0B6335FL, },
                new ulong[] { 0xAF8F9C2DC16481F8L, 0x7955CD7B7C6E0F7DL, },
                new ulong[] { 0x886F778059876813L, 0x27960E69077A5254L, },
                new ulong[] { 0x1386208B33CAEE14L, 0x5EA1D78F30A05E48L, },
                new ulong[] { 0x53C1DBD8BEEBF1A1L, 0x3982F01FA64AB8C0L, },
                new ulong[] { 0x61F55862BAA9623BL, 0xB49714F364E2830FL, },
                new ulong[] { 0xABBAD90A06994426L, 0xED716DBB028B7FC4L, },
                new ulong[] { 0x56691478C30D1100L, 0xBAFBD0F3D34754C9L, },
                new ulong[] { 0x77666B3868C55101L, 0x18DCE5816FDCB4A2L, },
                new ulong[] { 0x58F35E9066B226D6L, 0x25C13285F64D6382L, },
                new ulong[] { 0x108BC0E947E26998L, 0xF752B9C44F9329D0L, },
                new ulong[] { 0x9CDED766ACEFFC31L, 0x024949E45F48C77EL, },
                new ulong[] { 0x11A8B03399E99354L, 0xD9C3CF970FEC087EL, },
                new ulong[] { 0xBB54B067CAA4E26EL, 0x77052385BF1533FDL, },
                new ulong[] { 0x98B88D73E8063D47L, 0x4077E47AC466C054L, },
                new ulong[] { 0x8548BF23E4E526A4L, 0x23F7AEFE81A44D29L, },
                new ulong[] { 0xB0FA65CF31770178L, 0xB12E51528920D574L, },
                new ulong[] { 0x7390223F83FC259EL, 0xEB3938E8A544933EL, },
                new ulong[] { 0x215A52BE5A498E56L, 0x121D073ECD14228AL, },
                new ulong[] { 0x9A6BD15245B5294AL, 0xAE0AFF8E52109C46L, },
                new ulong[] { 0xE0F5A9D5DD84D1C9L, 0x1C69BF9A9AE28CCFL, },
                new ulong[] { 0xD850BD78AE79B42DL, 0xAD32618A178A2A88L, },
                new ulong[] { 0x7B445E2D045FCE8EL, 0x6F8F8DCBEAB95150L, },
                new ulong[] { 0xE807C3B3B4530B9CL, 0x661F147886E0AE7EL, },
                new ulong[] { 0xE4EAA669AF48F2ABL, 0x94EB9E122FEBD3BFL, },
                new ulong[] { 0x884B576816DA6406L, 0xF4AE587302F335B9L, },
                new ulong[] { 0xE97D33BFC49D4BAAL, 0xB76A7C463CFDD40CL, },
                new ulong[] { 0xDE6BAF1F477F5CEAL, 0x87226D68D4D71A2BL, },
                new ulong[] { 0xFCFA233218B03929L, 0x353DC4524FDE2317L, },
                new ulong[] { 0x3EFCEA5ECA56397CL, 0x68EB4665559D3E36L, },
                new ulong[] { 0x321CF0467107C677L, 0xCFFFA94E5F9DB6B6L, },
                new ulong[] { 0xDF7E84B86C98A637L, 0xDE549B30F1F02509L, },
                new ulong[] { 0xF9A8A99DE6F005A7L, 0xC88C3C922E1A2407L, },
                new ulong[] { 0x4648C4291F7DC43DL, 0x11674F90ED769E1EL, },
                new ulong[] { 0x1A0EFCE601BF620DL, 0x2B69D3C551473C0DL, },
                new ulong[] { 0x9E667CCA8B46038CL, 0xB5E7BE4B085EFDE4L, },
                new ulong[] { 0x9C2CAF3BB95B8A52L, 0xD92BD2D0E5CC7344L, },
                new ulong[] { 0xAD5DC9951E306ADFL, 0xD83B91C6C80CAE97L, },
                new ulong[] { 0x397F852C90891180L, 0xDBB6705E289135E7L, },
                new ulong[] { 0xBB31C2C96A3417E6L, 0x5B0CCACC34AE5036L, },
                new ulong[] { 0xAA21B7EF3734D927L, 0x89DF5AECDC211840L, },
                new ulong[] { 0x785E9CED9D7D2389L, 0x4273CC66B1C9B1D8L, },
                new ulong[] { 0x657D5EBF91806D4AL, 0x4CB150A294FA8911L, },
                new ulong[] { 0x89AEE75560F9330EL, 0x022949CF3D0EFC3FL, },
                new ulong[] { 0xD1190B722B431CE6L, 0x1B1563DC4BD8C88EL, },
                new ulong[] { 0xCF82F749F5AEE5F7L, 0x169B2608A6559037L, },
                new ulong[] { 0x4FA5B7D00F038D43L, 0x03641A20ADF237A8L, },
                new ulong[] { 0xE304BF4FEED390A5L, 0x3F4286F2270D7E24L, },
                new ulong[] { 0xC493FE72A1C1E25FL, 0x38F5F9AE7CD35CB1L, },
                new ulong[] { 0x6EB306BD5C32972CL, 0x7C013A8BD03D13B2L, },
                new ulong[] { 0x94CA6B7A2214C892L, 0x9ED32A009F65F09FL, },
                new ulong[] { 0x8C32D80B1150E8DCL, 0x871D91D64108D5FBL, },
                new ulong[] { 0x1279DAC78449F167L, 0xDA832592B52BE348L, },
                new ulong[] { 0xE94ED572CFF23819L, 0x362A1DA96F16947EL, },
                new ulong[] { 0xFE49ED46961E4874L, 0x8E6904163024620FL, },
                new ulong[] { 0xD8D6A998DEA5FC57L, 0x1D8A3D58D0386400L, },
                new ulong[] { 0xBE1CDCEF1CDEEC9FL, 0x595357D9743676D4L, },
                new ulong[] { 0x53F128EB000C04E3L, 0x40E772D8CB73CA66L, },
                new ulong[] { 0xFE1D836A9A009776L, 0x7A0F6793591CA9CCL, },
                new ulong[] { 0xA067F52123545358L, 0xBD5947F0A447D505L, },
                new ulong[] { 0x4A83502F77D15051L, 0x7CBD3F979A063E50L, },
            };

            for (var idx = 0; idx < data.Length; idx++) {
                CheckHash128(key, data, idx, expected128[idx]);
            }
        }

// MARK: - Private Methods

        private static void CheckHash64(byte[] key, byte[] data, int length, ulong expected)
        {
            var expectedString = GetBytes(expected).ToUpperHexString();
            var hashString = SipHash.Hash64(key, data, 0, length).ToUpperHexString();
            Assert.Equal(expectedString, hashString);
        }

        private static void CheckHash128(byte[] key, byte[] data, int length, ulong[] expected)
        {
            var expectedString = GetBytes(expected).ToUpperHexString();
            var hashString = SipHash.Hash128(key, data, 0, length).ToUpperHexString();
            Assert.Equal(expectedString, hashString);
        }
    }
}