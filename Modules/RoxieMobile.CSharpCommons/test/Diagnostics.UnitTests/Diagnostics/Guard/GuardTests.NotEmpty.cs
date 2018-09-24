using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;
using static RoxieMobile.CSharpCommons.Extensions.ArrayUtils;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    [SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
    [SuppressMessage("ReSharper", "SuggestVarOrType_Elsewhere")]
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NotEmpty")]
        public void NotEmpty(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string nilValue = null;
            const string emptyValue = "";


            GuardThrowsError(method,
                () => Guard.NotEmpty(nilValue));
            GuardThrowsError(method,
                () => Guard.NotEmpty(emptyValue));

            GuardNotThrowsError(method,
                () => Guard.NotEmpty(value));

            // --

            string[] array = ToArray(value, otherValue);
            string[] nilArray = null;
            string[] emptyArray = {};

            GuardThrowsError($"{method}_Array",
                () => Guard.NotEmpty(nilArray));
            GuardThrowsError($"{method}_Array",
                () => Guard.NotEmpty(emptyArray));

            GuardNotThrowsError($"{method}_Array",
                () => Guard.NotEmpty(array));

            // --

            List<string> list = ToArray(value, otherValue).ToList();
            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            GuardThrowsError($"{method}_List",
                () => Guard.NotEmpty(nilList));
            GuardThrowsError($"{method}_List",
                () => Guard.NotEmpty(emptyList));

            GuardNotThrowsError($"{method}_List",
                () => Guard.NotEmpty(list));

            // --

            Dictionary<string, string> map = list.ToDictionary(item => item, item => item);
            Dictionary<string, string> nilMap = null;
            Dictionary<string, string> emptyMap = new Dictionary<string, string>();

            GuardThrowsError($"{method}_Dictionary",
                () => Guard.NotEmpty(nilMap));
            GuardThrowsError($"{method}_Dictionary",
                () => Guard.NotEmpty(emptyMap));

            GuardNotThrowsError($"{method}_Dictionary",
                () => Guard.NotEmpty(map));
        }
    }
}