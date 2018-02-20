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
            const string nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";


            CheckThrowsException(method,
                () => Check.Blank(value));

            CheckNotThrowsException(method,
                () => Check.Blank(nilValue));
            CheckNotThrowsException(method,
                () => Check.Blank(emptyValue));
            CheckNotThrowsException(method,
                () => Check.Blank(whitespaceValue));
        }
    }
}