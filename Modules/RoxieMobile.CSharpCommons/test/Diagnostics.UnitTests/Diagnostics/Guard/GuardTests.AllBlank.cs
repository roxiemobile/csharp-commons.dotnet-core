using System.Diagnostics.CodeAnalysis;
using Xunit;
using static RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers.Arrays;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.AllBlank")]
        public void AllBlank(string method)
        {
            const string value = "value";
            const string? nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";

            string?[] array = ToArray(nilValue, emptyValue, whitespaceValue);
            string[]? nilArray = null;
            string[] emptyArray = {};


            GuardThrowsError(method,
                () => Guard.AllBlank(ToArray(value)));
            GuardThrowsError(method,
                () => Guard.AllBlank(ToArray(nilValue, value)));
            GuardThrowsError(method,
                () => Guard.AllBlank(ToArray(emptyValue, value)));
            GuardThrowsError(method,
                () => Guard.AllBlank(ToArray(whitespaceValue, value)));

            GuardNotThrowsError(method,
                () => Guard.AllBlank(array));
            GuardNotThrowsError(method,
                () => Guard.AllBlank(nilArray));
            GuardNotThrowsError(method,
                () => Guard.AllBlank(emptyArray));
        }
    }
}
