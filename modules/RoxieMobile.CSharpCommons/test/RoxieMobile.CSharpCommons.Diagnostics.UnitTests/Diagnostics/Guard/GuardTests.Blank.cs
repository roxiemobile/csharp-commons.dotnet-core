using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class GuardTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Guard.Blank")]
        public void Blank(string method)
        {
            const string value = "value";
            const string nilString = null;
            const string emptyString = "";
            const string whitespaceString = " \t\r\n";


            GuardThrowsError(method,
                () => Guard.Blank(value));

            GuardNotThrowsError(method,
                () => Guard.Blank(nilString));
            GuardNotThrowsError(method,
                () => Guard.Blank(emptyString));
            GuardNotThrowsError(method,
                () => Guard.Blank(whitespaceString));
        }
    }
}