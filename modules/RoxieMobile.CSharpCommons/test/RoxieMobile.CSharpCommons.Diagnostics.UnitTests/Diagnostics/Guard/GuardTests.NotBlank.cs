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
            const string nilString = null;
            const string emptyString = "";
            const string whitespaceString = " \t\r\n";


            GuardThrowsError(method,
                () => Guard.NotBlank(nilString));
            GuardThrowsError(method,
                () => Guard.NotBlank(emptyString));
            GuardThrowsError(method,
                () => Guard.NotBlank(whitespaceString));

            GuardNotThrowsError(method,
                () => Guard.NotBlank(value));
        }
    }
}