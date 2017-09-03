using System.Diagnostics.CodeAnalysis;
using Xunit;
using static RoxieMobile.CSharpCommons.Extensions.ArrayUtils;

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
            const string nilString = null;
            const string emptyString = "";

            string[] array = ToArray(nilString, emptyString);
            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(value)));
            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(nilString, value)));
            CheckThrowsException(method,
                () => Check.AllEmpty(ToArray(emptyString, value)));

            CheckNotThrowsException(method,
                () => Check.AllEmpty(array));
            CheckNotThrowsException(method,
                () => Check.AllEmpty(nilArray));
            CheckNotThrowsException(method,
                () => Check.AllEmpty(emptyArray));
        }
    }
}