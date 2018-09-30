using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
        [InlineData("Check.AllNotNull")]
        public void AllNotNull(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";

            string[] array = ToArray(value, emptyValue);
            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException($"{method}_Array",
                () => Check.AllNotNull(ToArray(value, nilValue)));
            CheckThrowsException($"{method}_Array",
                () => Check.AllNotNull(ToArray(emptyValue, nilValue)));

            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(array));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(nilArray));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(emptyArray));

            // --

            List<string> list = ToArray(value, emptyValue).ToList();
            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(value, nilValue).ToList()));
            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(emptyValue, nilValue).ToList()));

            CheckNotThrowsException($"{method}_List",
                () => Check.AllNotNull(list));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(nilList));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(emptyList));
        }
    }
}