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
        [InlineData("Guard.AllNotEmpty")]
        public void AllNotEmpty(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string nilValue = null;
            const string emptyValue = "";

            string[] array = ToArray(value, otherValue);
            string[] nilArray = null;
            string[] emptyArray = {};


            GuardThrowsError(method,
                () => Guard.AllNotEmpty(ToArray(value, nilValue)));
            GuardThrowsError(method,
                () => Guard.AllNotEmpty(ToArray(value, emptyValue)));

            GuardNotThrowsError(method,
                () => Guard.AllNotEmpty(array));
            GuardNotThrowsError(method,
                () => Guard.AllNotEmpty(nilArray));
            GuardNotThrowsError(method,
                () => Guard.AllNotEmpty(emptyArray));
        }
    }
}