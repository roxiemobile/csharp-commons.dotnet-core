using Xunit;

namespace RoxieMobile.CSharpCommons.Diagnostics.UnitTests.Diagnostics
{
    public partial class CheckTests
    {
// MARK: - Tests

        [Theory]
        [InlineData("Check.NotSame")]
        public void NotSame(string method)
        {
            const string value = "value";
            const string otherString = "otherValue";

            CheckThrowsException(method,
                () => Check.NotSame(value, value));

            CheckNotThrowsException(method,
                () => Check.NotSame(value, otherString));
        }
    }
}