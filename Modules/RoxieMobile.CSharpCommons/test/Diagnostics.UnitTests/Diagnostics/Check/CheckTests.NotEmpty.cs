using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RoxieMobile.CSharpCommons.Extensions;
using Xunit;
using static RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Helpers.Arrays;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ConstantConditionalAccessQualifier")]
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotEmpty")]
        public void NotEmpty(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string? nilValue = null;
            const string emptyValue = "";


            CheckThrowsException(method,
                () => Check.NotEmpty(nilValue));
            CheckThrowsException(method,
                () => Check.NotEmpty(emptyValue));

            CheckNotThrowsException(method,
                () => Check.NotEmpty(value));

            // --

            string[] array = ToArray(value, otherValue);
            string[]? nilArray = null;
            string[] emptyArray = {};

            CheckThrowsException($"{method}_Array",
                () => Check.NotEmpty(nilArray));
            CheckThrowsException($"{method}_Array",
                () => Check.NotEmpty(emptyArray));

            CheckNotThrowsException($"{method}_Array",
                () => Check.NotEmpty(array));

            // --

            List<string> list = ToArray(value, otherValue).ToList();
            List<string>? nilList = null;
            List<string> emptyList = new List<string>();

            CheckThrowsException($"{method}_List",
                () => Check.NotEmpty(nilList?.AsCollection()));
            CheckThrowsException($"{method}_List",
                () => Check.NotEmpty(emptyList.AsCollection()));

            CheckNotThrowsException($"{method}_List",
                () => Check.NotEmpty(list.AsCollection()));

            // --

            CheckThrowsException($"{method}_List",
                () => Check.NotEmpty(nilList?.AsReadOnlyCollection()));
            CheckThrowsException($"{method}_List",
                () => Check.NotEmpty(emptyList.AsReadOnlyCollection()));

            CheckNotThrowsException($"{method}_List",
                () => Check.NotEmpty(list.AsReadOnlyCollection()));

            // --

            Dictionary<string, string> map = list.ToDictionary(item => item, item => item);
            Dictionary<string, string>? nilMap = null;
            Dictionary<string, string> emptyMap = new Dictionary<string, string>();

            CheckThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(nilMap?.AsCollection()));
            CheckThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(emptyMap.AsCollection()));

            CheckNotThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(map.AsCollection()));

            // --

            CheckThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(nilMap?.AsReadOnlyCollection()));
            CheckThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(emptyMap.AsReadOnlyCollection()));

            CheckNotThrowsException($"{method}_Dictionary",
                () => Check.NotEmpty(map.AsReadOnlyCollection()));
        }
    }
}
