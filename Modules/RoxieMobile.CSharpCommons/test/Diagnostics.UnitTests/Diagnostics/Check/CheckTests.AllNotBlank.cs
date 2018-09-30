using System.Diagnostics.CodeAnalysis;
using Xunit;
using static RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers.Arrays;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.AllNotBlank")]
        public void AllNotBlank(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";

            string[] array = ToArray(value, otherValue);
            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException(method,
                () => Check.AllNotBlank(ToArray(nilValue)));
            CheckThrowsException(method,
                () => Check.AllNotBlank(ToArray(emptyValue)));
            CheckThrowsException(method,
                () => Check.AllNotBlank(ToArray(whitespaceValue)));
            CheckThrowsException(method,
                () => Check.AllNotBlank(ToArray(value, whitespaceValue)));

            CheckNotThrowsException(method,
                () => Check.AllNotBlank(array));
            CheckNotThrowsException(method,
                () => Check.AllNotBlank(nilArray));
            CheckNotThrowsException(method,
                () => Check.AllNotBlank(emptyArray));
        }
    }
}