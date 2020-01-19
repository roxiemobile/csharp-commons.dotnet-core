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
        [InlineData("Guard.AllEmpty")]
        public void AllEmpty(string method)
        {
            const string value = "value";
            const string? nilValue = null;
            const string emptyValue = "";

            string?[] array = ToArray(nilValue, emptyValue);
            string[]? nilArray = null;
            string[] emptyArray = {};


            GuardThrowsError(method,
                () => Guard.AllEmpty(ToArray(value)));
            GuardThrowsError(method,
                () => Guard.AllEmpty(ToArray(nilValue, value)));
            GuardThrowsError(method,
                () => Guard.AllEmpty(ToArray(emptyValue, value)));

            GuardNotThrowsError(method,
                () => Guard.AllEmpty(array));
            GuardNotThrowsError(method,
                () => Guard.AllEmpty(nilArray));
            GuardNotThrowsError(method,
                () => Guard.AllEmpty(emptyArray));
        }
    }
}
