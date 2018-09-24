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
            const string nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";


            GuardThrowsError(method,
                () => Guard.Blank(value));

            GuardNotThrowsError(method,
                () => Guard.Blank(nilValue));
            GuardNotThrowsError(method,
                () => Guard.Blank(emptyValue));
            GuardNotThrowsError(method,
                () => Guard.Blank(whitespaceValue));
        }
    }
}