using System.Diagnostics.CodeAnalysis;
using Xunit;
using static RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers.Arrays;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.AllNotEmpty")]
        public void AllNotEmpty(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string? nilValue = null;
            const string emptyValue = "";

            string[] array = ToArray(value, otherValue);
            string[]? nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException(method,
                () => Check.AllNotEmpty(ToArray(value, nilValue)));
            CheckThrowsException(method,
                () => Check.AllNotEmpty(ToArray(value, emptyValue)));

            CheckNotThrowsException(method,
                () => Check.AllNotEmpty(array));
            CheckNotThrowsException(method,
                () => Check.AllNotEmpty(nilArray));
            CheckNotThrowsException(method,
                () => Check.AllNotEmpty(emptyArray));
        }
    }
}
