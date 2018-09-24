using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.NotBlank")]
        public void NotBlank(string method)
        {
            const string value = "value";
            const string nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";


            GuardThrowsError(method,
                () => Guard.NotBlank(nilValue));
            GuardThrowsError(method,
                () => Guard.NotBlank(emptyValue));
            GuardThrowsError(method,
                () => Guard.NotBlank(whitespaceValue));

            GuardNotThrowsError(method,
                () => Guard.NotBlank(value));
        }
    }
}