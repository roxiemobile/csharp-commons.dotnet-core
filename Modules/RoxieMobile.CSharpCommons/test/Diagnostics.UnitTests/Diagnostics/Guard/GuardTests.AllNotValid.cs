using System.Diagnostics.CodeAnalysis;
using RoxieMobile.CSharpCommons.Abstractions.Models;
using RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Models;
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
        [InlineData("Guard.AllNotValid")]
        public void AllNotValid(string method)
        {
            IValidatable validObject = new ValidModel();
            IValidatable? nilObject = null;
            IValidatable notValidObject = new NotValidModel();

            IValidatable[] array = ToArray(notValidObject);
            IValidatable[]? nilArray = null;
            IValidatable[] emptyArray = {};


            GuardThrowsError(method,
                () => Guard.AllNotValid(ToArray(validObject)));
            GuardThrowsError(method,
                () => Guard.AllNotValid(ToArray(nilObject)));
            GuardThrowsError(method,
                () => Guard.AllNotValid(ToArray(notValidObject, validObject)));

            GuardNotThrowsError(method,
                () => Guard.AllNotValid(array));
            GuardNotThrowsError(method,
                () => Guard.AllNotValid(nilArray));
            GuardNotThrowsError(method,
                () => Guard.AllNotValid(emptyArray));
        }
    }
}
