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
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Empty")]
        public void Empty(string method)
        {
            const string value = "value";
            const string otherValue = "otherValue";
            const string? nilValue = null;
            const string emptyValue = "";


            GuardThrowsError(method,
                () => Guard.Empty(value));

            GuardNotThrowsError(method,
                () => Guard.Empty(nilValue));
            GuardNotThrowsError(method,
                () => Guard.Empty(emptyValue));

            // --

            string[] array = ToArray(value, otherValue);
            string[]? nilArray = null;
            string[] emptyArray = {};

            GuardThrowsError($"{method}_Array",
                () => Guard.Empty(array));

            GuardNotThrowsError($"{method}_Array",
                () => Guard.Empty(nilArray));
            GuardNotThrowsError($"{method}_Array",
                () => Guard.Empty(emptyArray));

            // --

            List<string> list = ToArray(value, otherValue).ToList();
            List<string>? nilList = null;
            List<string> emptyList = new List<string>();

            GuardThrowsError($"{method}_List",
                () => Guard.Empty(list.AsCollection()));

            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(nilList?.AsCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(emptyList.AsCollection()));

            // --

            GuardThrowsError($"{method}_List",
                () => Guard.Empty(list.AsReadOnlyCollection()));

            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(nilList?.AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(emptyList.AsReadOnlyCollection()));

            // --

            Dictionary<string, string> map = list.ToDictionary(item => item, item => item);
            Dictionary<string, string>? nilMap = null;
            Dictionary<string, string> emptyMap = new Dictionary<string, string>();

            GuardThrowsError($"{method}_Dictionary",
                () => Guard.Empty(map.AsCollection()));

            GuardNotThrowsError($"{method}_Dictionary",
                () => Guard.Empty(nilMap?.AsCollection()));
            GuardNotThrowsError($"{method}_Dictionary",
                () => Guard.Empty(emptyMap.AsCollection()));

            // --

            GuardThrowsError($"{method}_Dictionary",
                () => Guard.Empty(map.AsReadOnlyCollection()));

            GuardNotThrowsError($"{method}_Dictionary",
                () => Guard.Empty(nilMap?.AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_Dictionary",
                () => Guard.Empty(emptyMap.AsReadOnlyCollection()));
        }
    }
}
