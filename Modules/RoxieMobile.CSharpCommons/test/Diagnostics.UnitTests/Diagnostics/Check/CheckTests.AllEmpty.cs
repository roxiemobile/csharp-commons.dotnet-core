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
        [InlineData("Check.AllEmpty")]
        public void AllEmpty(string method)
        {
            const string value = "value";
            const string? nilValue = null;
            const string emptyValue = "";

            string?[] array = ToArray(nilValue, emptyValue);
            string[]? nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(value)));
            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(nilValue, value)));
            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(emptyValue, value)));

            CheckNotThrowsException(method,
                () => Check.AllEmpty(array));
            CheckNotThrowsException(method,
                () => Check.AllEmpty(nilArray));
            CheckNotThrowsException(method,
                () => Check.AllEmpty(emptyArray));
        }
    }
}
