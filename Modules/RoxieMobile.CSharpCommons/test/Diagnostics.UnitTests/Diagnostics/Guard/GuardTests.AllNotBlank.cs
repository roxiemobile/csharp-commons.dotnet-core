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
        [InlineData("Guard.AllNotBlank")]
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


            GuardThrowsError(method,
                () => Guard.AllNotBlank(ToArray(nilValue)));
            GuardThrowsError(method,
                () => Guard.AllNotBlank(ToArray(emptyValue)));
            GuardThrowsError(method,
                () => Guard.AllNotBlank(ToArray(whitespaceValue)));
            GuardThrowsError(method,
                () => Guard.AllNotBlank(ToArray(value, whitespaceValue)));

            GuardNotThrowsError(method,
                () => Guard.AllNotBlank(array));
            GuardNotThrowsError(method,
                () => Guard.AllNotBlank(nilArray));
            GuardNotThrowsError(method,
                () => Guard.AllNotBlank(emptyArray));
        }
    }
}