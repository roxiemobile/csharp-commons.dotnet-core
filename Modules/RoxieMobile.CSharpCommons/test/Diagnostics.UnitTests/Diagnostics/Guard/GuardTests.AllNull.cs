using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using RoxieMobile.CSharpCommons.Extensions;
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
        [InlineData("Guard.AllNull")]
        public void AllNull(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";

            string[] nilArray = null;
            string[] emptyArray = {};


            GuardThrowsError($"{method}_Array",
                () => Guard.AllNull(ToArray(nilValue, value)));
            GuardThrowsError($"{method}_Array",
                () => Guard.AllNull(ToArray(nilValue, emptyValue)));

            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNull(ToArray(nilValue, nilValue)));
            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNull(nilArray));
            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNull(emptyArray));

            // --

            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(value, nilValue).ToList().AsCollection()));
            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(emptyValue, nilValue).ToList().AsCollection()));

            GuardNotThrowsError($"{method}_List",
                () => Guard.AllNull(ToArray(nilValue, nilValue).ToList().AsCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(nilList.AsCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(emptyList.AsCollection()));

            // --

            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(value, nilValue).ToList().AsReadOnlyCollection()));
            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(emptyValue, nilValue).ToList().AsReadOnlyCollection()));

            GuardNotThrowsError($"{method}_List",
                () => Guard.AllNull(ToArray(nilValue, nilValue).ToList().AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(nilList.AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(emptyList.AsReadOnlyCollection()));
        }
    }
}