using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotBlank")]
        public void NotBlank(string method)
        {
            const string value = "value";
            const string nilString = null;
            const string emptyString = "";
            const string whitespaceString = " \t\r\n";


            CheckThrowsException(method,
                () => Check.NotBlank(nilString));
            CheckThrowsException(method,
                () => Check.NotBlank(emptyString));
            CheckThrowsException(method,
                () => Check.NotBlank(whitespaceString));

            CheckNotThrowsException(method,
                () => Check.NotBlank(value));
        }
    }
}