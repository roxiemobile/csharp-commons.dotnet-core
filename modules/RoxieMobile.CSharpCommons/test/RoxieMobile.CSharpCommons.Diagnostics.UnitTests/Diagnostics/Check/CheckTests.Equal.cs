using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.Equal")]
        public void Equal(string method)
        {
            const string value = "value";
            const string nilString = null;


            CheckThrowsException(method,
                () => Check.Equal(1, 2));
            CheckThrowsException(method,
                () => Check.Equal(value, nilString));

            CheckNotThrowsException(method,
                () => Check.Equal(2, 2));
            CheckNotThrowsException(method,
                () => Check.Equal(value, value));
        }
    }
}