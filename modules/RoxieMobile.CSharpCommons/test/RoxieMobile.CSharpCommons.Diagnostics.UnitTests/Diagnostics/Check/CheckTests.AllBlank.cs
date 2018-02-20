using System.Diagnostics.CodeAnalysis;
using Xunit;
using static RoxieMobile.CSharpCommons.Extensions.ArrayUtils;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.AllBlank")]
        public void AllBlank(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";

            string[] array = ToArray(nilValue, emptyValue, whitespaceValue);
            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException(method,
                () => Check.AllBlank(ToArray(value)));
            CheckThrowsException(method,
                () => Check.AllBlank(ToArray(nilValue, value)));
            CheckThrowsException(method,
                () => Check.AllBlank(ToArray(emptyValue, value)));
            CheckThrowsException(method,
                () => Check.AllBlank(ToArray(whitespaceValue, value)));

            CheckNotThrowsException(method,
                () => Check.AllBlank(array));
            CheckNotThrowsException(method,
                () => Check.AllBlank(nilArray));
            CheckNotThrowsException(method,
                () => Check.AllBlank(emptyArray));
        }
    }
}