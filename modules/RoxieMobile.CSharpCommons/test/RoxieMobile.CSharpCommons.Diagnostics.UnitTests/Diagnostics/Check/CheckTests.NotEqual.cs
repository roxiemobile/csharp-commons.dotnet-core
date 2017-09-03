using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotEqual")]
        public void NotEqual(string method)
        {
            const string value = "value";
            const string nilString = null;


            CheckThrowsException(method,
                () => Check.NotEqual(2, 2));
            CheckThrowsException(method,
                () => Check.NotEqual(value, value));

            CheckNotThrowsException(method,
                () => Check.NotEqual(1, 2));
            CheckNotThrowsException(method,
                () => Check.NotEqual(value, nilString));
        }
    }
}