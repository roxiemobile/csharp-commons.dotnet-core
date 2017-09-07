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
        [InlineData("Check.AllNotNull")]
        public void AllNotNull(string method)
        {
            const string value = "value";
            const string nilString = null;
            const string emptyString = "";

            string[] array = ToArray(value, emptyString);
            string[] nilArray = null;
            string[] emptyArray = {};


            CheckThrowsException($"{method}_Array",
                () => Check.AllNotNull(ToArray(value, nilString)));
            CheckThrowsException($"{method}_Array",
                () => Check.AllNotNull(ToArray(emptyString, nilString)));

            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(array));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(nilArray));
            CheckNotThrowsException($"{method}_Array",
                () => Check.AllNotNull(emptyArray));

            // --

            List<string> list = ToArray(value, emptyString).ToList();
            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(value, nilString).ToList()));
            CheckThrowsException($"{method}_List",
                () => Check.AllNotNull(ToArray(emptyString, nilString).ToList()));

            CheckNotThrowsException($"{method}_List",
                () => Check.AllNotNull(list));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(nilList));
            CheckNotThrowsException($"{method}_List",
                () => Check.Empty(emptyList));
        }
    }
}