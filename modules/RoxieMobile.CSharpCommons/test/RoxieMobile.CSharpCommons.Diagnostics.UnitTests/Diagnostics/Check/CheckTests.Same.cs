using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.Same")]
        public void Same(string method)
        {
            const string value = "value";
            const string otherString = "otherValue";

            CheckThrowsException(method,
                () => Check.Same(value, otherString));

            CheckNotThrowsException(method,
                () => Check.Same(value, value));
        }
    }
}