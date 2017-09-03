using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.Blank")]
        public void Blank(string method)
        {
            const string value = "value";
            const string nilString = null;
            const string emptyString = "";
            const string whitespaceString = " \t\r\n";


            CheckThrowsException(method,
                () => Check.Blank(value));

            CheckNotThrowsException(method,
                () => Check.Blank(nilString));
            CheckNotThrowsException(method,
                () => Check.Blank(emptyString));
            CheckNotThrowsException(method,
                () => Check.Blank(whitespaceString));
        }
    }
}