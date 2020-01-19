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
            const string? nilValue = null;
            const string emptyValue = "";
            const string whitespaceValue = " \t\r\n";


            CheckThrowsException(method,
                () => Check.NotBlank(nilValue));
            CheckThrowsException(method,
                () => Check.NotBlank(emptyValue));
            CheckThrowsException(method,
                () => Check.NotBlank(whitespaceValue));

            CheckNotThrowsException(method,
                () => Check.NotBlank(value));
        }
    }
}
