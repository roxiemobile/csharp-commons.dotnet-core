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
        [InlineData("Guard.AllNotNull")]
        public void AllNotNull(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";

            string[] array = ToArray(value, emptyValue);
            string[] nilArray = null;
            string[] emptyArray = {};


            GuardThrowsError($"{method}_Array",
                () => Guard.AllNotNull(ToArray(value, nilValue)));
            GuardThrowsError($"{method}_Array",
                () => Guard.AllNotNull(ToArray(emptyValue, nilValue)));

            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNotNull(array));
            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNotNull(nilArray));
            GuardNotThrowsError($"{method}_Array",
                () => Guard.AllNotNull(emptyArray));

            // --

            List<string> list = ToArray(value, emptyValue).ToList();
            List<string> nilList = null;
            List<string> emptyList = new List<string>();

            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(value, nilValue).ToList().AsCollection()));
            GuardThrowsError($"{method}_List",
                () => Guard.AllNotNull(ToArray(emptyValue, nilValue).ToList().AsCollection()));

            GuardNotThrowsError($"{method}_List",
                () => Guard.AllNotNull(list.AsCollection()));
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
                () => Guard.AllNotNull(list.AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(nilList.AsReadOnlyCollection()));
            GuardNotThrowsError($"{method}_List",
                () => Guard.Empty(emptyList.AsReadOnlyCollection()));
        }
    }
}