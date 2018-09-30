using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Cryptography.Algorithms;
using RoxieMobile.CSharpCommons.Cryptography.Extensions;
using Xunit;
using static RoxieMobile.CSharpCommons.Cryptography.Converters.BigEndianBitConverter;

namespace RoxieMobile.CSharpCommons.Cryptography.UnitTests.Algorithms
{
    [SuppressMessage("ReSharper", "RedundantExplicitArrayCreation")]
    public sealed class HighwayHashTests
    {
        [Fact]
        private void TestHighwayHash64()
        {
            byte[] key = {
                0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
                0x17, 0x16, 0x15, 0x14, 0x13, 0x12, 0x11, 0x10,
                0x1F, 0x1E, 0x1D, 0x1C, 0x1B, 0x1A, 0x19, 0x18
            };

            var data = new byte[64];
            for (var idx = 0; idx < data.Length; idx++) {
                data[idx] = (byte) idx;
            }

            // HighwayHash results for byte strings [], [0], [0,1], [0,1,2], etc...,
            // these match the values in the C++ test of HighwayHash at
            // https://github.com/google/highwayhash/blob/master/highwayhash/highwayhash_test.cc#L132
            ulong[] expected64 = {
                0x907A56DE22C26E53L, 0x7EAB43AAC7CDDD78L, 0xB8D0569AB0B53D62L, 0x5C6BEFAB8A463D80L,
                0xF205A46893007EDAL, 0x2B8A1668E4A94541L, 0xBD4CCC325BEFCA6FL, 0x4D02AE1738F59482L,
                0xE1205108E55F3171L, 0x32D2644EC77A1584L, 0xF6E10ACDB103A90BL, 0xC3BBF4615B415C15L,
                0x243CC2040063FA9CL, 0xA89A58CE65E641FFL, 0x24B031A348455A23L, 0x40793F86A449F33BL,
                0xCFAB3489F97EB832L, 0x19FE67D2C8C5C0E2L, 0x04DD90A69C565CC2L, 0x75D9518E2371C504L,
                0x38AD9B1141D3DD16L, 0x0264432CCD8A70E0L, 0xA9DB5A6288683390L, 0xD7B05492003F028CL,
                0x205F615AEA59E51EL, 0xEEE0C89621052884L, 0x1BFC1A93A7284F4FL, 0x512175B5B70DA91DL,
                0xF71F8976A0A2C639L, 0xAE093FEF1F84E3E7L, 0x22CA92B01161860FL, 0x9FC7007CCF035A68L,
                0xA0C964D9ECD580FCL, 0x2C90F73CA03181FCL, 0x185CF84E5691EB9EL, 0x4FC1F5EF2752AA9BL,
                0xF5B7391A5E0A33EBL, 0xB9B84B83B4E96C9CL, 0x5E42FE712A5CD9B4L, 0xA150F2F90C3F97DCL,
                0x7FA522D75E2D637DL, 0x181AD0CC0DFFD32BL, 0x3889ED981E854028L, 0xFB4297E8C586EE2DL,
                0x6D064A45BB28059CL, 0x90563609B3EC860CL, 0x7AA4FCE94097C666L, 0x1326BAC06B911E08L,
                0xB926168D2B154F34L, 0x9919848945B1948DL, 0xA2A98FC534825EBEL, 0xE9809095213EF0B6L,
                0x582E5483707BC0E9L, 0x086E9414A88A6AF5L, 0xEE86B98D20F6743DL, 0xF89B7FF609B1C0A7L,
                0x4C7D9CC19E22C3E8L, 0x9A97005024562A6FL, 0x5DD41CF423E6EBEFL, 0xDF13609C0468E227L,
                0x6E0DA4F64188155AL, 0xB755BA4B50D7D4A1L, 0x887A3484647479BDL, 0xAB8EEBE9BF2139A0L,
            };

            for (var idx = 0; idx < data.Length; idx++) {
                CheckHash64(key, data, idx, expected64[idx]);
            }
        }

        [Fact]
        private void TestHighwayHash128()
        {
            byte[] key = {
                0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
                0x17, 0x16, 0x15, 0x14, 0x13, 0x12, 0x11, 0x10,
                0x1F, 0x1E, 0x1D, 0x1C, 0x1B, 0x1A, 0x19, 0x18
            };

            var data = new byte[64];
            for (var idx = 0; idx < data.Length; idx++) {
                data[idx] = (byte) idx;
            }

            // HighwayHash results for byte strings [], [0], [0,1], [0,1,2], etc...,
            // these match the values in the C++ test of HighwayHash at
            // https://github.com/google/highwayhash/blob/master/highwayhash/highwayhash_test.cc#L157
            ulong[][] expected128 = {
                new ulong[] { 0x0FED268F9D8FFEC7L, 0x33565E767F093E6FL },
                new ulong[] { 0xD6B0A8893681E7A8L, 0xDC291DF9EB9CDCB4L },
                new ulong[] { 0x3D15AD265A16DA04L, 0x78085638DC32E868L },
                new ulong[] { 0x0607621B295F0BEBL, 0xBFE69A0FD9CEDD79L },
                new ulong[] { 0x26399EB46DACE49EL, 0x2E922AD039319208L },
                new ulong[] { 0x3250BDC386D12ED8L, 0x193810906C63C23AL },
                new ulong[] { 0x6F476AB3CB896547L, 0x7CDE576F37ED1019L },
                new ulong[] { 0x2A401FCA697171B4L, 0xBE1F03FF9F02796CL },
                new ulong[] { 0xA1E96D84280552E8L, 0x695CF1C63BEC0AC2L },
                new ulong[] { 0x142A2102F31E63B2L, 0x1A85B98C5B5000CCL },
                new ulong[] { 0x51A1B70E26B6BC5BL, 0x929E1F3B2DA45559L },
                new ulong[] { 0x88990362059A415BL, 0xBED21F22C47B7D13L },
                new ulong[] { 0xCD1F1F5F1CAF9566L, 0xA818BA8CE0F9C8D4L },
                new ulong[] { 0xA225564112FE6157L, 0xB2E94C78B8DDB848L },
                new ulong[] { 0xBD492FEBD1CC0919L, 0xCECD1DBC025641A2L },
                new ulong[] { 0x142237A52BC4AF54L, 0xE0796C0B6E26BCD7L },
                new ulong[] { 0x414460FFD5A401ADL, 0x029EA3D5019F18C8L },
                new ulong[] { 0xC52A4B96C51C9962L, 0xECB878B1169B5EA0L },
                new ulong[] { 0xD940CA8F11FBEACEL, 0xF93A46D616F8D531L },
                new ulong[] { 0x8AC49D0AE5C0CBF5L, 0x3FFDBF8DF51D7C93L },
                new ulong[] { 0xAC6D279B852D00A8L, 0x7DCD3A6BA5EBAA46L },
                new ulong[] { 0xF11621BD93F08A56L, 0x3173C398163DD9D5L },
                new ulong[] { 0x0C4CE250F68CF89FL, 0xB3123CDA411898EDL },
                new ulong[] { 0x15AB97ED3D9A51CEL, 0x7CE274479169080EL },
                new ulong[] { 0xCD001E198D4845B8L, 0xD0D9D98BD8AA2D77L },
                new ulong[] { 0x34F3D617A0493D79L, 0x7DD304F6397F7E16L },
                new ulong[] { 0x5CB56890A9F4C6B6L, 0x130829166567304FL },
                new ulong[] { 0x30DA6F8B245BD1C0L, 0x6F828B7E3FD9748CL },
                new ulong[] { 0xE0580349204C12C0L, 0x93F6DA0CAC5F441CL },
                new ulong[] { 0xF648731BA5073045L, 0x5FB897114FB65976L },
                new ulong[] { 0x024F8354738A5206L, 0x509A4918EB7E0991L },
                new ulong[] { 0x06E7B465E8A57C29L, 0x52415E3A07F5D446L },
                new ulong[] { 0x1984DF66C1434AAAL, 0x16FC1958F9B3E4B9L },
                new ulong[] { 0x111678AFE0C6C36CL, 0xF958B59DE5A2849DL },
                new ulong[] { 0x773FBC8440FB0490L, 0xC96ED5D243658536L },
                new ulong[] { 0x91E3DC710BB6C941L, 0xEA336A0BC1EEACE9L },
                new ulong[] { 0x25CFE3815D7AD9D4L, 0xF2E94F8C828FC59EL },
                new ulong[] { 0xB9FB38B83CC288F2L, 0x7479C4C8F850EC04L },
                new ulong[] { 0x1D85D5C525982B8CL, 0x6E26B1C16F48DBF4L },
                new ulong[] { 0x8A4E55BD6060BDE7L, 0x2134D599058B3FD0L },
                new ulong[] { 0x2A958FF994778F36L, 0xE8052D1AE61D6423L },
                new ulong[] { 0x89233AE6BE453233L, 0x3ACF9C87D7E8C0B9L },
                new ulong[] { 0x4458F5E27EA9C8D5L, 0x418FB49BCA2A5140L },
                new ulong[] { 0x090301837ED12A68L, 0x1017F69633C861E6L },
                new ulong[] { 0x330DD84704D49590L, 0x339DF1AD3A4BA6E4L },
                new ulong[] { 0x569363A663F2C576L, 0x363B3D95E3C95EF6L },
                new ulong[] { 0xACC8D08586B90737L, 0x2BA0E8087D4E28E9L },
                new ulong[] { 0x39C27A27C86D9520L, 0x8DB620A45160932EL },
                new ulong[] { 0x8E6A4AEB671A072DL, 0x6ED3561A10E47EE6L },
                new ulong[] { 0x0011D765B1BEC74AL, 0xD80E6E656EDE842EL },
                new ulong[] { 0x2515D62B936AC64CL, 0xCE088794D7088A7DL },
                new ulong[] { 0x91621552C16E23AFL, 0x264F0094EB23CCEFL },
                new ulong[] { 0x1E21880D97263480L, 0xD8654807D3A31086L },
                new ulong[] { 0x39D76AAF097F432DL, 0xA517E1E09D074739L },
                new ulong[] { 0x0F17A4F337C65A14L, 0x2F51215F69F976D4L },
                new ulong[] { 0xA0FB5CDA12895E44L, 0x568C3DC4D1F13CD1L },
                new ulong[] { 0x93C8FC00D89C46CEL, 0xBAD5DA947E330E69L },
                new ulong[] { 0x817C07501D1A5694L, 0x584D6EE72CBFAC2BL },
                new ulong[] { 0x91D668AF73F053BFL, 0xF98E647683C1E0EDL },
                new ulong[] { 0x5281E1EF6B3CCF8BL, 0xBC4CC3DF166083D8L },
                new ulong[] { 0xAAD61B6DBEAAEEB9L, 0xFF969D000C16787BL },
                new ulong[] { 0x4325D84FC0475879L, 0x14B919BD905F1C2DL },
                new ulong[] { 0x79A176D1AA6BA6D1L, 0xF1F720C5A53A2B86L },
                new ulong[] { 0x74BD7018022F3EF0L, 0x3AEA94A8AD5F4BCBL },
            };

            for (var idx = 0; idx < data.Length; idx++) {
                CheckHash128(key, data, idx, expected128[idx]);
            }
        }

        [Fact]
        private void TestHighwayHash256()
        {
            byte[] key = {
                0x07, 0x06, 0x05, 0x04, 0x03, 0x02, 0x01, 0x00,
                0x0F, 0x0E, 0x0D, 0x0C, 0x0B, 0x0A, 0x09, 0x08,
                0x17, 0x16, 0x15, 0x14, 0x13, 0x12, 0x11, 0x10,
                0x1F, 0x1E, 0x1D, 0x1C, 0x1B, 0x1A, 0x19, 0x18
            };

            var data = new byte[64];
            for (var idx = 0; idx < data.Length; idx++) {
                data[idx] = (byte) idx;
            }

            // HighwayHash results for byte strings [], [0], [0,1], [0,1,2], etc...,
            // these match the values in the C++ test of HighwayHash at
            // https://github.com/google/highwayhash/blob/master/highwayhash/highwayhash_test.cc#L225
            ulong[][] expected256 = {
                new ulong[] { 0xDD44482AC2C874F5L, 0xD946017313C7351FL, 0xB3AEBECCB98714FFL, 0x41DA233145751DF4L },
                new ulong[] { 0xEDB941BCE45F8254L, 0xE20D44EF3DCAC60FL, 0x72651B9BCB324A47L, 0x2073624CB275E484L },
                new ulong[] { 0x3FDFF9DF24AFE454L, 0x11C4BF1A1B0AE873L, 0x115169CC6922597AL, 0x1208F6590D33B42CL },
                new ulong[] { 0x480AA0D70DD1D95CL, 0x89225E7C6911D1D0L, 0x8EA8426B8BBB865AL, 0xE23DFBC390E1C722L },
                new ulong[] { 0xC9CFC497212BE4DCL, 0xA85F9DF6AFD2929BL, 0x1FDA9F211DF4109EL, 0x07E4277A374D4F9BL },
                new ulong[] { 0xB4B4F566A4DC85B3L, 0xBF4B63BA5E460142L, 0x15F48E68CDDC1DE3L, 0x0F74587D388085C6L },
                new ulong[] { 0x6445C70A86ADB9B4L, 0xA99CFB2784B4CEB6L, 0xDAE29D40A0B2DB13L, 0xB6526DF29A9D1170L },
                new ulong[] { 0xD666B1A00987AD81L, 0xA4F1F838EB8C6D37L, 0xE9226E07D463E030L, 0x5754D67D062C526CL },
                new ulong[] { 0xF1B905B0ED768BC0L, 0xE6976FF3FCFF3A45L, 0x4FBE518DD9D09778L, 0xD9A0AFEB371E0D33L },
                new ulong[] { 0x80D8E4D70D3C2981L, 0xF10FBBD16424F1A1L, 0xCF5C2DBE9D3F0CD1L, 0xC0BFE8F701B673F2L },
                new ulong[] { 0xADE48C50E5A262BEL, 0x8E9492B1FDFE38E0L, 0x0784B74B2FE9B838L, 0x0E41D574DB656DCDL },
                new ulong[] { 0xA1BE77B9531807CFL, 0xBA97A7DE6A1A9738L, 0xAF274CEF9C8E261FL, 0x3E39B935C74CE8E8L },
                new ulong[] { 0x15AD3802E3405857L, 0x9D11CBDC39E853A0L, 0x23EA3E993C31B225L, 0x6CD9E9E3CAF4212EL },
                new ulong[] { 0x01C96F5EB1D77C36L, 0xA367F9C1531F95A6L, 0x1F94A3427CDADCB8L, 0x97F1000ABF3BD5D3L },
                new ulong[] { 0x0815E91EEEFF8E41L, 0x0E0C28FA6E21DF5DL, 0x4EAD8E62ED095374L, 0x3FFD01DA1C9D73E6L },
                new ulong[] { 0xC11905707842602EL, 0x62C3DB018501B146L, 0x85F5AD17FA3406C1L, 0xC884F87BD4FEC347L },
                new ulong[] { 0xF51AD989A1B6CD1FL, 0xF7F075D62A627BD9L, 0x7E01D5F579F28A06L, 0x1AD415C16A174D9FL },
                new ulong[] { 0x19F4CFA82CA4068EL, 0x3B9D4ABD3A9275B9L, 0x8000B0DDE9C010C6L, 0x8884D50949215613L },
                new ulong[] { 0x126D6C7F81AB9F5DL, 0x4EDAA3C5097716EEL, 0xAF121573A7DD3E49L, 0x9001AC85AA80C32DL },
                new ulong[] { 0x06AABEF9149155FAL, 0xDF864F4144E71C3DL, 0xFDBABCE860BC64DAL, 0xDE2BA54792491CB6L },
                new ulong[] { 0xADFC6B4035079FDBL, 0xA087B7328E486E65L, 0x46D1A9935A4623EAL, 0xE3895C440D3CEE44L },
                new ulong[] { 0xB5F9D31DEEA3B3DFL, 0x8F3024E20A06E133L, 0xF24C38C8288FE120L, 0x703F1DCF9BD69749L },
                new ulong[] { 0x2B3C0B854794EFE3L, 0x1C5D3F969BDACEA0L, 0x81F16AAFA563AC2EL, 0x23441C5A79D03075L },
                new ulong[] { 0x418AF8C793FD3762L, 0xBC6B8E9461D7F924L, 0x776FF26A2A1A9E78L, 0x3AA0B7BFD417CA6EL },
                new ulong[] { 0xCD03EA2AD255A3C1L, 0x0185FEE5B59C1B2AL, 0xD1F438D44F9773E4L, 0xBE69DD67F83B76E4L },
                new ulong[] { 0xF951A8873887A0FBL, 0x2C7B31D2A548E0AEL, 0x44803838B6186EFAL, 0xA3C78EC7BE219F72L },
                new ulong[] { 0x958FF151EA0D8C08L, 0x4B7E8997B4F63488L, 0xC78E074351C5386DL, 0xD95577556F20EEFAL },
                new ulong[] { 0x29A917807FB05406L, 0x3318F884351F578CL, 0xDD24EA6EF6F6A7FAL, 0xE74393465E97AEFFL },
                new ulong[] { 0x98240880935E6CCBL, 0x1FD0D271B09F97DAL, 0x56E786472700B183L, 0x291649F99F747817L },
                new ulong[] { 0x1BD4954F7054C556L, 0xFFDB2EFF7C596CEBL, 0x7C6AC69A1BAB6B5BL, 0x0F037670537FC153L },
                new ulong[] { 0x8825E38897597498L, 0x647CF6EBAF6332C1L, 0x552BD903DC28C917L, 0x72D7632C00BFC5ABL },
                new ulong[] { 0x6880E276601A644DL, 0xB3728B20B10FB7DAL, 0xD0BD12060610D16EL, 0x8AEF14EF33452EF2L },
                new ulong[] { 0xBCE38C9039A1C3FEL, 0x42D56326A3C11289L, 0xE35595F764FCAEA9L, 0xC9B03C6BC9475A99L },
                new ulong[] { 0xF60115CBF034A6E5L, 0x6C36EA75BFCE46D0L, 0x3B17C8D382725990L, 0x7EDAA2ED11007A35L },
                new ulong[] { 0x1326E959EDF9DEA2L, 0xC4776801739F720CL, 0x5169500FD762F62FL, 0x8A0DD0D90A2529ABL },
                new ulong[] { 0x935149D503D442D4L, 0xFF6BB41302DAD144L, 0x339CB012CD9D36ECL, 0xE61D53619ECC2230L },
                new ulong[] { 0x528BC888AA50B696L, 0xB8AEECA36084E1FCL, 0xA158151EC0243476L, 0x02C14AAD097CEC44L },
                new ulong[] { 0xBED688A72217C327L, 0x1EE65114F760873FL, 0x3F5C26B37D3002A6L, 0xDDF2E895631597B9L },
                new ulong[] { 0xE7DB21CF2B0B51ADL, 0xFAFC6324F4B0AB6CL, 0xB0857244C22D9C5BL, 0xF0AD888D1E05849CL },
                new ulong[] { 0x05519793CD4DCB00L, 0x3C594A3163067DEBL, 0xAC75081ACF119E34L, 0x5AC86297805CB094L },
                new ulong[] { 0x09228D8C22B5779EL, 0x19644DB2516B7E84L, 0x2B92C8ABF83141A0L, 0x7F785AD725E19391L },
                new ulong[] { 0x59C42E5D46D0A74BL, 0x5EA53C65CA036064L, 0x48A9916BB635AEB4L, 0xBAE6DF143F54E9D4L },
                new ulong[] { 0x5EB623696D03D0E3L, 0xD53D78BCB41DA092L, 0xFE2348DC52F6B10DL, 0x64802457632C8C11L },
                new ulong[] { 0x43B61BB2C4B85481L, 0xC6318C25717E80A1L, 0x8C4A7F4D6F9C687DL, 0xBD0217E035401D7CL },
                new ulong[] { 0x7F51CA5743824C37L, 0xB04C4D5EB11D703AL, 0x4D511E1ECBF6F369L, 0xD66775EA215456E2L },
                new ulong[] { 0x39B409EEF87E45CCL, 0x52B8E8C459FC79B3L, 0x44920918D1858C24L, 0x80F07B645EEE0149L },
                new ulong[] { 0xCE8694D1BE9AD514L, 0xBFA19026526836E7L, 0x1EA4FDF6E4902A7DL, 0x380C4458D696E1FEL },
                new ulong[] { 0xD189E18BF823A0A4L, 0x1F3B353BE501A7D7L, 0xA24F77B4E02E2884L, 0x7E94646F74F9180CL },
                new ulong[] { 0xAFF8C635D325EC48L, 0x2C2E0AA414038D0BL, 0x4ED37F611A447467L, 0x39EC38E33B501489L },
                new ulong[] { 0x2A2BFDAD5F83F197L, 0x013D3E6EBEF274CCL, 0xE1563C0477726155L, 0xF15A8A5DE932037EL },
                new ulong[] { 0xD5D1F91EC8126332L, 0x10110B9BF9B1FF11L, 0xA175AB26541C6032L, 0x87BADC5728701552L },
                new ulong[] { 0xC7B5A92CD8082884L, 0xDDA62AB61B2EEEFBL, 0x8F9882ECFEAE732FL, 0x6B38BD5CC01F4FFBL },
                new ulong[] { 0xCF6EF275733D32F0L, 0xA3F0822DA2BF7D8BL, 0x304E7435F512406AL, 0x0B28E3EFEBB3172DL },
                new ulong[] { 0xE698F80701B2E9DBL, 0x66AE2A819A8A8828L, 0x14EA9024C9B8F2C9L, 0xA7416170523EB5A4L },
                new ulong[] { 0x3A917E87E307EDB7L, 0x17B4DEDAE34452C1L, 0xF689F162E711CC70L, 0x29CE6BFE789CDD0EL },
                new ulong[] { 0x0EFF3AD8CB155D8EL, 0x47CD9EAD4C0844A2L, 0x46C8E40EE6FE21EBL, 0xDEF3C25DF0340A51L },
                new ulong[] { 0x03FD86E62B82D04DL, 0x32AB0D600717136DL, 0x682B0E832B857A89L, 0x138CE3F1443739B1L },
                new ulong[] { 0x2F77C754C4D7F902L, 0x1053E0A9D9ADBFEAL, 0x58E66368544AE70AL, 0xC48A829C72DD83CAL },
                new ulong[] { 0xF900EB19E466A09FL, 0x31BE9E01A8C7D314L, 0x3AFEC6B8CA08F471L, 0xB8C0EB0F87FFE7FBL },
                new ulong[] { 0xDB277D8FBE3C8EFBL, 0x53CE6877E11AA57BL, 0x719C94D20D9A7E7DL, 0xB345B56392453CC9L },
                new ulong[] { 0x37639C3BDBA4F2C9L, 0x6095E7B336466DC8L, 0x3A8049791E65B88AL, 0x82C988CDE5927CD5L },
                new ulong[] { 0x6B1FB1A714234AE4L, 0x20562E255BA6467EL, 0x3E2B892D40F3D675L, 0xF40CE3FBE41ED768L },
                new ulong[] { 0x8EE11CB1B287C92AL, 0x8FC2AAEFF63D266DL, 0x66643487E6EB9F03L, 0x578AA91DE8D56873L },
                new ulong[] { 0xF5B1F8266A3AEB67L, 0x83B040BE4DEC1ADDL, 0x7FE1C8635B26FBAEL, 0xF4A3A447DEFED79FL },
            };

            for (var idx = 0; idx < data.Length; idx++) {
                CheckHash256(key, data, idx, expected256[idx]);
            }
        }

// MARK: - Private Methods

        private static void CheckHash64(byte[] key, byte[] data, int length, ulong expected)
        {
            var expectedString = ToByteArray(expected).ToUpperHexString();
            var hashString = HighwayHash.Hash64(key, data, 0, length).ToUpperHexString();
            Assert.Equal(expectedString, hashString);
        }

        private static void CheckHash128(byte[] key, byte[] data, int length, ulong[] expected)
        {
            var expectedString = ToByteArray(expected).ToUpperHexString();
            var hashString = HighwayHash.Hash128(key, data, 0, length).ToUpperHexString();
            Assert.Equal(expectedString, hashString);
        }

        private static void CheckHash256(byte[] key, byte[] data, int length, ulong[] expected)
        {
            var expectedString = ToByteArray(expected).ToUpperHexString();
            var hashString = HighwayHash.Hash256(key, data, 0, length).ToUpperHexString();
            Assert.Equal(expectedString, hashString);
        }
    }
}