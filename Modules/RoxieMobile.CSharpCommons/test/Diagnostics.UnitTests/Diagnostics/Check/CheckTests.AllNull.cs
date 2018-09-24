using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        [InlineData("Check.AllNull")]
        public void AllNull(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";

            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException($"{method}_Array",
                () => Check.AllNull(ToArray(nilValue, value)));
            CheckThrowsException($"{method}_Array",
                () => Check.AllNull(ToArray(nilValue, emptyValue)));

            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNull(ToArray(nilValue, nilValue)));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNull(nilArray));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNull(emptyArray));

            // --

            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(value, nilValue).ToList()));
            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(emptyValue, nilValue).ToList()));

            CheckNotThrowsException($"{method}_List",
                () => Check.AllNull(ToArray(nilValue, nilValue).ToList()));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(nilList));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(emptyList));
        }
    }
}